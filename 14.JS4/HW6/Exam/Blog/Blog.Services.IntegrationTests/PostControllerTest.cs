using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Newtonsoft.Json;
using System.Web.Http;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Blog.Data;
using Blog.Services.Repositories;
using Blog.Services.Models;
using System.Net.Http;

namespace Blog.Services.IntegrationTests
{
    [TestClass]
    public class PostControllerTest
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;
        private DbContext context;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
            DbContext context = new BlogEntities();
            this.context = context;
            AllRepositories allRepositories = new AllRepositories(context);
            this.httpServer = new InMemoryHttpServer("http://localhost/", allRepositories);
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void PostCreatePost_WhenDataCorrect_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            AddUser(username, displayName);
            string sessionKey = LoginUser(username, authCode);

            string title = "New post";
            string text = "This is just a new post";
            string[] tags = new string[] {"tag1", "tag2"};

            PostWithTagsModel initialPost = new PostWithTagsModel()
            {
                Title = title,
                Text = text,
                Tags = tags
            };

            var response = this.httpServer.CreatePostRequest("api/posts?sessionKey=" + sessionKey, initialPost);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var postModel = JsonConvert.DeserializeObject<PostSimpleModel>(contentString);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(postModel);
            Assert.IsTrue(postModel.Id != 0);
            Assert.AreEqual(initialPost.Title, postModel.Title);

            Post post = this.context.Set<Post>().FirstOrDefault(p => p.PostId == postModel.Id);
            Assert.IsNotNull(post);
        }

        [TestMethod]
        public void PostCreatePost_WhenSessionKeyIncorrect_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            AddUser(username, displayName);
            LoginUser(username, authCode);
            string sessionKey = new string('*', 50);

            string title = "New post";
            string text = "This is just a new post";
            string[] tags = new string[] { "tag1", "tag2" };

            PostWithTagsModel initialPost = new PostWithTagsModel()
            {
                Title = title,
                Text = text,
                Tags = tags
            };

            var response = this.httpServer.CreatePostRequest("api/posts?sessionKey=" + sessionKey, initialPost);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var postModel = JsonConvert.DeserializeObject<PostSimpleModel>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            
            Post post = this.context.Set<Post>().FirstOrDefault(p => p.Title == title && p.User.SessionKey == sessionKey);
            Assert.IsNull(post);
        }

        [TestMethod]
        public void PostCreatePost_WhenTitleEmpty_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            AddUser(username, displayName);
            string sessionKey = LoginUser(username, authCode);

            string title = "  ";
            string text = "This is just a new post";
            string[] tags = new string[] { "tag1", "tag2" };

            PostWithTagsModel initialPost = new PostWithTagsModel()
            {
                Title = title,
                Text = text,
                Tags = tags
            };

            var response = this.httpServer.CreatePostRequest("api/posts?sessionKey=" + sessionKey, initialPost);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var postModel = JsonConvert.DeserializeObject<PostSimpleModel>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Post post = this.context.Set<Post>().FirstOrDefault(p => (p.Title == title || p.Title == string.Empty) && p.User.SessionKey == sessionKey);
            Assert.IsNull(post);
        }

        [TestMethod]
        public void PostCreatePost_WhenTextEmpty_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            AddUser(username, displayName);
            string sessionKey = LoginUser(username, authCode);

            string title = "New post";
            string text = "    ";
            string[] tags = new string[] { "tag1", "tag2" };

            PostWithTagsModel initialPost = new PostWithTagsModel()
            {
                Title = title,
                Text = text,
                Tags = tags
            };

            var response = this.httpServer.CreatePostRequest("api/posts?sessionKey=" + sessionKey, initialPost);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var postModel = JsonConvert.DeserializeObject<PostSimpleModel>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Post post = this.context.Set<Post>().FirstOrDefault(p => p.Title == title && p.User.SessionKey == sessionKey);
            Assert.IsNull(post);
        }

        [TestMethod]
        public void PostCreatePost_WhenTagsNull_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            AddUser(username, displayName);
            string sessionKey = LoginUser(username, authCode);

            string title = "New post";
            string text = "This is just a new post";
            string[] tags = null;

            PostWithTagsModel initialPost = new PostWithTagsModel()
            {
                Title = title,
                Text = text,
                Tags = tags
            };

            var response = this.httpServer.CreatePostRequest("api/posts?sessionKey=" + sessionKey, initialPost);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var postModel = JsonConvert.DeserializeObject<PostSimpleModel>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Post post = this.context.Set<Post>().FirstOrDefault(p => p.Title == title && p.User.SessionKey == sessionKey);
            Assert.IsNull(post);
        }

        [TestMethod]
        public void GetPostsByTags_WhenSuchExist_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            AddUser(username, displayName);
            string sessionKey = LoginUser(username, authCode);

            string title = "New post";
            string text = "This is just a new post";
            string[] tags = new string[] { "web", "services" };
            PostSimpleModel post = CreatePost(sessionKey, title, text, tags);

            var response = this.httpServer.CreateGetRequest("api/posts?tags=web,services&sessionKey=" + sessionKey);
            var contentString = response.Content.ReadAsStringAsync().Result;
            IEnumerable<PostDetailModel> postModels = JsonConvert.DeserializeObject<IEnumerable<PostDetailModel>>(contentString);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, postModels.Count());
        }

        [TestMethod]
        public void GetPostsByTags_WhenNotAllPosts_MeetCriteria_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            AddUser(username, displayName);
            string sessionKey = LoginUser(username, authCode);

            string title = "New post";
            string text = "This is just a new post";
            string[] tags1 = new string[] { "web", "services" };
            PostSimpleModel post1 = CreatePost(sessionKey, title, text, tags1);

            PostSimpleModel post2 = CreatePost(sessionKey, title, text, tags1);

            string[] tags2 = new string[] { "web", "services1" };
            PostSimpleModel post3 = CreatePost(sessionKey, title, text, tags2);

            var response = this.httpServer.CreateGetRequest("api/posts?tags=web,services&sessionKey=" + sessionKey);
            var contentString = response.Content.ReadAsStringAsync().Result;
            IEnumerable<PostDetailModel> postModels = JsonConvert.DeserializeObject<IEnumerable<PostDetailModel>>(contentString);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(2, postModels.Count());
        }

        [TestMethod]
        public void GetPostsByTags_WhenNone_MeetCriteria_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            AddUser(username, displayName);
            string sessionKey = LoginUser(username, authCode);

            string title = "New post";
            string text = "This is just a new post";
            string[] tags1 = new string[] { "web", "services" };
            PostSimpleModel post1 = CreatePost(sessionKey, title, text, tags1);

            string[] tags2 = new string[] { "web2", "services2" };
            PostSimpleModel post2 = CreatePost(sessionKey, title, text, tags2);

            string[] tags3 = new string[] { "web3", "services3" };
            PostSimpleModel post3 = CreatePost(sessionKey, title, text, tags3);

            var response = this.httpServer.CreateGetRequest("api/posts?tags=web4,services4&sessionKey=" + sessionKey);
            var contentString = response.Content.ReadAsStringAsync().Result;
            IEnumerable<PostDetailModel> postModels = JsonConvert.DeserializeObject<IEnumerable<PostDetailModel>>(contentString);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(0, postModels.Count());
        }

        [TestMethod]
        public void GetPostsByTags_WhenNoPostInDb_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            AddUser(username, displayName);
            string sessionKey = LoginUser(username, authCode);
            
            var response = this.httpServer.CreateGetRequest("api/posts?tags=web4,services4&sessionKey=" + sessionKey);
            var contentString = response.Content.ReadAsStringAsync().Result;
            IEnumerable<PostDetailModel> postModels = JsonConvert.DeserializeObject<IEnumerable<PostDetailModel>>(contentString);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(0, postModels.Count());
        }

        [TestMethod]
        public void GetPostsByTags_WhenSessionKeyIncorrect_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            AddUser(username, displayName);
            LoginUser(username, authCode);
            string sessionKey = new string('*', 50);

            string title = "New post";
            string text = "This is just a new post";
            string[] tags1 = new string[] { "web", "services" };
            PostSimpleModel post1 = CreatePost(sessionKey, title, text, tags1);

            string[] tags2 = new string[] { "web2", "services2" };
            PostSimpleModel post2 = CreatePost(sessionKey, title, text, tags2);

            string[] tags3 = new string[] { "web3", "services3" };
            PostSimpleModel post3 = CreatePost(sessionKey, title, text, tags3);

            var response = this.httpServer.CreateGetRequest("api/posts?tags=web4,services4&sessionKey=" + sessionKey);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void GetPostsByTags_WhenTagsListIncorrect_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            AddUser(username, displayName);
            LoginUser(username, authCode);
            string sessionKey = new string('*', 50);

            string title = "New post";
            string text = "This is just a new post";
            string[] tags1 = new string[] { "web", "services" };
            PostSimpleModel post1 = CreatePost(sessionKey, title, text, tags1);

            string[] tags2 = new string[] { "web2", "services2" };
            PostSimpleModel post2 = CreatePost(sessionKey, title, text, tags2);

            string[] tags3 = new string[] { "web3", "services3" };
            PostSimpleModel post3 = CreatePost(sessionKey, title, text, tags3);

            var response = this.httpServer.CreateGetRequest("api/posts?tags=&sessionKey=" + sessionKey);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PutCommentForPosts_WhenDataCorrect_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            AddUser(username, displayName);
            string sessionKey = LoginUser(username, authCode);

            string title = "New post";
            string text = "This is just a new post";
            string[] tags1 = new string[] { "web", "services" };
            PostSimpleModel post = CreatePost(sessionKey, title, text, tags1);
            
            string commentText = "Abe kefi me toq post";
            CommentSimpleModel initialComment = new CommentSimpleModel()
            {
                Text = commentText
            };

            var response = this.httpServer.CreatePutRequest("api/posts/" + post.Id + "/comment?sessionKey=" + sessionKey, initialComment);

            var content = response.Content;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNull(content);

            Comment comment = this.context.Set<Comment>().FirstOrDefault(c => c.Post.PostId == post.Id && c.User.SessionKey == sessionKey);
            Assert.IsNotNull(comment);
        }

        [TestMethod]
        public void PutCommentForPosts_WhenSessionKeyIncorrect_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            AddUser(username, displayName);
            string sessionKey = LoginUser(username, authCode);

            string title = "New post";
            string text = "This is just a new post";
            string[] tags1 = new string[] { "web", "services" };
            PostSimpleModel post = CreatePost(sessionKey, title, text, tags1);

            string commentText = "Abe kefi me toq post";
            CommentSimpleModel initialComment = new CommentSimpleModel()
            {
                Text = commentText
            };

            string sessionKeyComment = new string('*', 50);

            var response = this.httpServer.CreatePutRequest("api/posts/" + post.Id + "/comment?sessionKey=" + sessionKeyComment, initialComment);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Comment comment = this.context.Set<Comment>().FirstOrDefault(c => c.Post.PostId == post.Id && c.User.SessionKey == sessionKey);
            Assert.IsNull(comment);
        }

        [TestMethod]
        public void PutCommentForPosts_WhenCommentNull_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            AddUser(username, displayName);
            string sessionKey = LoginUser(username, authCode);

            string title = "New post";
            string text = "This is just a new post";
            string[] tags1 = new string[] { "web", "services" };
            PostSimpleModel post = CreatePost(sessionKey, title, text, tags1);
            
            var response = this.httpServer.CreatePutRequest("api/posts/" + post.Id + "/comment?sessionKey=" + sessionKey, null);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Comment comment = this.context.Set<Comment>().FirstOrDefault(c => c.Post.PostId == post.Id && c.User.SessionKey == sessionKey);
            Assert.IsNull(comment);
        }

        [TestMethod]
        public void PutCommentForPosts_WhenCommentEmpty_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            AddUser(username, displayName);
            string sessionKey = LoginUser(username, authCode);

            string title = "New post";
            string text = "This is just a new post";
            string[] tags1 = new string[] { "web", "services" };
            PostSimpleModel post = CreatePost(sessionKey, title, text, tags1);

            string commentText = "   ";
            CommentSimpleModel initialComment = new CommentSimpleModel()
            {
                Text = commentText
            };

            var response = this.httpServer.CreatePutRequest("api/posts/" + post.Id + "/comment?sessionKey=" + sessionKey, initialComment);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Comment comment = this.context.Set<Comment>().FirstOrDefault(c => c.Post.PostId == post.Id && c.User.SessionKey == sessionKey);
            Assert.IsNull(comment);
        }

        private PostSimpleModel CreatePost(string sessionKey, string title, string text, string[] tags)
        {
            PostWithTagsModel initialPost = new PostWithTagsModel()
            {
                Title = title,
                Text = text,
                Tags = tags
            };

            var response = this.httpServer.CreatePostRequest("api/posts?sessionKey=" + sessionKey, initialPost);
            var contentString = response.Content.ReadAsStringAsync().Result;
            PostSimpleModel postModel = JsonConvert.DeserializeObject<PostSimpleModel>(contentString);
            return postModel;
        }

        private string LoginUser(string username, string authCode)
        {
            UserModel userLogin = new UserModel()
            {
                Username = username,
                AuthCode = authCode
            };

            var response = this.httpServer.CreatePostRequest("api/users/login", userLogin);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            return userModel.SessionKey;
        }

        private UserModel AddUser(string username, string displayname)
        {
            UserModel initialUser = new UserModel()
            {
                Username = username,
                DisplayName = displayname,
                AuthCode = new String('*', 40)
            };

            var response = this.httpServer.CreatePostRequest("api/users/register", initialUser);

            return initialUser;
        }
    }
}