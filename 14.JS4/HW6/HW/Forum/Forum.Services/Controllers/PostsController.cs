using Forum.Data;
using Forum.Services.Models;
using Forum.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace Forum.Services.Controllers
{
    public class PostsController : BaseApiController
    {
        private AllRepositories data;

        public PostsController()
        {
            data = new AllRepositories(new ForumDbEntities());
        }

        public PostsController(AllRepositories data)
        {
            this.data = data;
        }

        public IQueryable<PostDetailModel> Get(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  VerifySessionKey(sessionKey);

                  IRepository<Post> postRepository = this.data.GetPostsRepository();

                  IQueryable<Post> posts = postRepository.All();

                  IQueryable<PostDetailModel> postsModels = ModelFunctions.GetPostsDetails(posts);

                  return postsModels.OrderByDescending(p => p.PostDate);
              });

            return responseMsg;
        }

        public PostDetailModel Get(string sessionKey, int id)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  VerifySessionKey(sessionKey);

                  IRepository<Post> postRepository = this.data.GetPostsRepository();

                  Post post = postRepository.Get(id);

                  PostDetailModel postModel = ModelFunctions.GetSinglePostDetails(post);

                  return postModel;
              });

            return responseMsg;
        }

        public IQueryable<PostDetailModel> Get(string keyword, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  VerifySessionKey(sessionKey);

                  IRepository<Post> postRepository = this.data.GetPostsRepository();

                  IQueryable<Post> posts = postRepository.GetConstraint(p => p.Title.ToLower().IndexOf(keyword.ToLower()) != -1);

                  IQueryable<PostDetailModel> postsModels = ModelFunctions.GetPostsDetails(posts);

                  return postsModels.OrderByDescending(p => p.PostDate);
              });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("get")]
        public IQueryable<PostDetailModel> GetByTags(string tags, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  VerifySessionKey(sessionKey);

                  if (tags == null)
                  {
                      throw new InvalidOperationException("Incorrect tags data");
                  }

                  string[] tagsConstraintSplit = tags.ToLower().Split(new string[] { "," }, StringSplitOptions.None);

                  if (tagsConstraintSplit.Length == 0)
                  {
                      throw new InvalidOperationException("Incorrect tags data");
                  }

                  HashSet<string> tagsConstraint = new HashSet<string>();
                  tagsConstraint.UnionWith(tagsConstraintSplit);

                  IRepository<Post> postRepository = this.data.GetPostsRepository();

                  IQueryable<Post> posts = postRepository.GetConstraint(p => p.Tags.Select(t => t.Name).Intersect(tagsConstraint).Count() == tagsConstraint.Count());

                  IQueryable<PostDetailModel> postsModels = ModelFunctions.GetPostsDetails(posts);

                  return postsModels.OrderByDescending(p => p.PostDate);
              });

            return responseMsg;
        }

        public IQueryable<PostDetailModel> Get(int page, int count, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  VerifySessionKey(sessionKey);

                  var models = this.Get(sessionKey)
                      .Skip(page * count)
                      .Take(count);

                  return models;
              });

            return responseMsg;
        }

        [HttpPost]
        [ActionName("post")]
        public HttpResponseMessage CreatePost(string sessionKey, PostWithTagsModel postModel)
        {
            HttpResponseMessage responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    User user = VerifySessionKey(sessionKey);

                    if (postModel.Title.Trim() == string.Empty)
                    {
                        throw new InvalidOperationException("The post title cannot be empty");
                    }

                    if (postModel.Text.Trim() == string.Empty)
                    {
                        throw new InvalidOperationException("The post text cannot be empty");
                    }

                    if (postModel.Tags == null)
                    {
                        throw new InvalidOperationException("Incorrect tags data");
                    }

                    Post post = new Post()
                    {
                        Title = postModel.Title,
                        Content = postModel.Text,
                        User = user,
                        PostDate = DateTime.Now
                    };

                    IRepository<Post> postRepository = this.data.GetPostsRepository();
                    postRepository.Add(post);

                    string[] tagsFromTitle = postModel.Title.ToLower().Split(new string[] { " ", ".", ",", "-", "!", "?", ";", ":", "'" }, StringSplitOptions.None);

                    HashSet<string> tags = new HashSet<string>();
                    tags.UnionWith(tagsFromTitle);

                    string[] postTagsToLower = postModel.Tags.Select(x => x.ToLower()).ToArray();
                    tags.UnionWith(postTagsToLower);

                    IRepository<Tag> tagRepository = this.data.GetTagsRepository();
                    foreach (string tag in tags)
                    {
                        IQueryable<Tag> tagsQuery = tagRepository.GetConstraint(t => t.Name == tag);

                        Tag postTag;
                        if (tagsQuery.Count() == 0)
                        {
                            postTag = new Tag()
                            {
                                Name = tag
                            };

                            postTag.Posts.Add(post);

                            tagRepository.Add(postTag);
                        }
                        else
                        {
                            postTag = tagsQuery.First();

                            postTag.Posts.Add(post);

                            tagRepository.Update(postTag.TagId, postTag);
                        }
                    }

                    var postResultModel = new PostSimpleModel()
                    {
                        Id = post.PostId,
                        Title = post.Title
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, postResultModel);

                    return response;
                });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("comment")]
        public HttpResponseMessage PutComment(int id, string sessionKey, CommentSimpleModel commentModel)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  User user = VerifySessionKey(sessionKey);

                  IRepository<Post> postRepository = this.data.GetPostsRepository();

                  Post post = postRepository.Get(id);

                  if (post == null)
                  {
                      throw new InvalidOperationException("No such post");
                  }

                  if (commentModel == null)
                  {
                      throw new InvalidOperationException("Invalid comment data");
                  }

                  if (commentModel.Text.Trim() == string.Empty)
                  {
                      throw new InvalidOperationException("The comment cannot be empty");
                  }

                  IRepository<Comment> commentRepository = this.data.GetCommentsRepository();

                  Comment comment = new Comment()
                  {
                      Content = commentModel.Text,
                      Post = post,
                      User = user
                  };

                  commentRepository.Add(comment);

                  var response = this.Request.CreateResponse(HttpStatusCode.OK);

                  return response;
              });

            return responseMsg;
        }

        private User VerifySessionKey(string sessionKey)
        {
            IRepository<User> userRepository = this.data.GetUserRepository();

            IQueryable<User> usersFound = userRepository.GetConstraint(usr => usr.SessionKey == sessionKey);

            if (usersFound.Count() == 0)
            {
                throw new InvalidOperationException("Invalid username or password");
            }

            return usersFound.First();
        }
    }
}
