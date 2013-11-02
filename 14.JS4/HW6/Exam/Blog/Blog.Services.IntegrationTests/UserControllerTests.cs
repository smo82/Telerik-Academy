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
    public class UserControllerTests
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
        public void PostUsersRegister_WhenDataCorrect_Test()
        {
            string username = "testuser";
            string displayName = "Test User._-";
            string authCode = new String('*', 40);

            UserModel initialUser = new UserModel()
            {
                Username = username,
                DisplayName = displayName,
                AuthCode = authCode
            };

            var response = this.httpServer.CreatePostRequest("api/users/register", initialUser);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(userModel);
            Assert.IsTrue(userModel.SessionKey != null);
            Assert.AreEqual(initialUser.DisplayName, userModel.DisplayName);

            User user = this.context.Set<User>().FirstOrDefault(u => u.Username == username && u.DisplayName == displayName && u.AuthCode == authCode);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void PostUsersRegister_WhenNameTooShort_Test()
        {
            string username = "test";
            string displayName = "Test User._-";
            string authCode = new String('*', 40);

            UserModel initialUser = new UserModel()
            {
                Username = username,
                DisplayName = displayName,
                AuthCode = authCode
            };

            var response = this.httpServer.CreatePostRequest("api/users/register", initialUser);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            User user = this.context.Set<User>().FirstOrDefault(u => u.Username == username && u.DisplayName == displayName && u.AuthCode == authCode);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void PostUsersRegister_WhenDisplayNameTooShort_Test()
        {
            string username = "testUser";
            string displayName = "Test";
            string authCode = new String('*', 40);

            UserModel initialUser = new UserModel()
            {
                Username = username,
                DisplayName = displayName,
                AuthCode = authCode
            };

            var response = this.httpServer.CreatePostRequest("api/users/register", initialUser);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            User user = this.context.Set<User>().FirstOrDefault(u => u.Username == username && u.DisplayName == displayName && u.AuthCode == authCode);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void PostUsersRegister_WhenUsernameHasIncorrectSymbols_Test()
        {
            string username = "testUser;";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            UserModel initialUser = new UserModel()
            {
                Username = username,
                DisplayName = displayName,
                AuthCode = authCode
            };

            var response = this.httpServer.CreatePostRequest("api/users/register", initialUser);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            User user = this.context.Set<User>().FirstOrDefault(u => u.Username == username && u.DisplayName == displayName && u.AuthCode == authCode);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void PostUsersRegister_WhenDisplayNameHasIncorrectSymbols_Test()
        {
            string username = "testUser";
            string displayName = "Test User;";
            string authCode = new String('*', 40);

            UserModel initialUser = new UserModel()
            {
                Username = username,
                DisplayName = displayName,
                AuthCode = authCode
            };

            var response = this.httpServer.CreatePostRequest("api/users/register", initialUser);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            User user = this.context.Set<User>().FirstOrDefault(u => u.Username == username && u.DisplayName == displayName && u.AuthCode == authCode);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void PostUsersRegister_WhenAuthCodeIncorrect_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 20);

            UserModel initialUser = new UserModel()
            {
                Username = username,
                DisplayName = displayName,
                AuthCode = authCode
            };

            var response = this.httpServer.CreatePostRequest("api/users/register", initialUser);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            User user = this.context.Set<User>().FirstOrDefault(u => u.Username == username && u.DisplayName == displayName && u.AuthCode == authCode);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void PostUsersRegister_WhenUsernameAlreadyExist_Test()
        {
            string username = "testUser";
            AddUser(username, "Some User");

            UserModel initialUser = new UserModel()
            {
                Username = username,
                DisplayName = "Test User",
                AuthCode = new String('*', 40)
            };

            var response = this.httpServer.CreatePostRequest("api/users/register", initialUser);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            
            IQueryable<User> usersFound = this.context.Set<User>().Where(u => u.Username == username);
            Assert.AreEqual(1, usersFound.Count());
        }

        [TestMethod]
        public void PostUsersRegister_WhenDisplayNamAlreadyExist_Test()
        {
            string displayName = "Test User";
            AddUser("testUser1", displayName);

            UserModel initialUser = new UserModel()
            {
                Username = "testUser",
                DisplayName = displayName,
                AuthCode = new String('*', 40)
            };

            var response = this.httpServer.CreatePostRequest("api/users/register", initialUser);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            IQueryable<User> usersFound = this.context.Set<User>().Where(u => u.DisplayName == displayName);
            Assert.AreEqual(1, usersFound.Count());
        }

        [TestMethod]
        public void PutUsersLogout_WhenDataCorrect_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            AddUser(username, displayName);
            string sessionKey = LoginUser(username, authCode);

            var response = this.httpServer.CreatePutRequest("api/users/logout?sessionKey=" + sessionKey, null);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            User user = this.context.Set<User>().FirstOrDefault(u => u.Username == username);
            Assert.IsNull(user.SessionKey);
        }

        [TestMethod]
        public void PutUsersLogout_WhenSessionKeyIncorrect_Test()
        {
            string username = "testUser";
            string displayName = "Test User";
            string authCode = new String('*', 40);

            AddUser(username, displayName);
            LoginUser(username, authCode);
            string sessionKey = new string('*', 50);

            var response = this.httpServer.CreatePutRequest("api/users/logout?sessionKey=" + sessionKey, null);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            User user = this.context.Set<User>().FirstOrDefault(u => u.Username == username);
            Assert.IsNotNull(user.SessionKey);
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