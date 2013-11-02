using Forum.Data;
using Forum.Services.Models;
using Forum.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Forum.Services.Controllers
{
    public class UsersController : BaseApiController
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const int MinDisplayNameLength = 6;
        private const int MaxDisplayNameLength = 30;
        private const string ValidUsernameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";
        private const string ValidDisplayNameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_. -";

        private const string SessionKeyChars =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
        private static readonly Random rand = new Random();

        private const int SessionKeyLength = 50;

        private const int Sha1Length = 40;

        private AllRepositories data;

        public UsersController()
        {
            data = new AllRepositories(new ForumDbEntities());
        }

        public UsersController(AllRepositories data)
        {
            this.data = data;
        }

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            HttpResponseMessage responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    this.ValidateUsername(model.Username);
                    this.ValidateDisplayName(model.DisplayName);
                    this.ValidateAuthCode(model.AuthCode);
                    var usernameToLower = model.Username.ToLower();
                    var displayNameToLower = model.DisplayName.ToLower();

                    IRepository<User> userRepository = this.data.GetUserRepository();

                    IQueryable<User> usersFound = userRepository.GetConstraint((usr => (usr.Username == usernameToLower
                        || usr.DisplayName.ToLower() == displayNameToLower)));

                    if (usersFound.Count() != 0)
                    {
                        throw new InvalidOperationException("User exists");
                    }

                    User user = new User()
                    {
                        Username = usernameToLower,
                        DisplayName = model.DisplayName,
                        AuthCode = model.AuthCode
                    };

                    userRepository.Add(user);

                    user.SessionKey = this.GenerateSessionKey(user.UserId);
                    userRepository.Update(user.UserId, user);

                    LoggedUserModel loggedModel = new LoggedUserModel()
                    {
                        DisplayName = user.DisplayName,
                        SessionKey = user.SessionKey
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);
                    return response;
                });

            return responseMsg;
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  this.ValidateUsername(model.Username);
                  this.ValidateAuthCode(model.AuthCode);
                  var usernameToLower = model.Username.ToLower();

                  IRepository<User> userRepository = this.data.GetUserRepository();

                  IQueryable<User> usersFound = userRepository.GetConstraint(
                      usr => usr.Username == usernameToLower && usr.AuthCode == model.AuthCode);

                  User user = usersFound.FirstOrDefault();

                  if (user == null)
                  {
                      throw new InvalidOperationException("Invalid username or password");
                  }

                  if (user.SessionKey == null)
                  {
                      user.SessionKey = this.GenerateSessionKey(user.UserId);
                      userRepository.Update(user.UserId, user);
                  }

                  var loggedModel = new LoggedUserModel()
                  {
                      DisplayName = user.DisplayName,
                      SessionKey = user.SessionKey
                  };

                  var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);

                  return response;
              });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage PutLogoutUser(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  IRepository<User> userRepository = this.data.GetUserRepository();

                  IQueryable<User> usersFound = userRepository.GetConstraint(
                      usr => usr.SessionKey == sessionKey);

                  if (usersFound.Count() == 0)
                  {
                      throw new InvalidOperationException("No user with such session key");
                  }

                  User user = usersFound.First();
                  user.SessionKey = null;

                  userRepository.Update(user.UserId, user);

                  var response = this.Request.CreateResponse(HttpStatusCode.OK);

                  return response;
              });

            return responseMsg;
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder skeyBuilder = new StringBuilder(SessionKeyLength);
            skeyBuilder.Append(userId);
            while (skeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyChars.Length);
                skeyBuilder.Append(SessionKeyChars[index]);
            }
            return skeyBuilder.ToString();
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != Sha1Length)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted");
            }
        }

        private void ValidateDisplayName(string displayName)
        {
            if (displayName == null)
            {
                throw new ArgumentNullException("The display name cannot be null");
            }
            else if (displayName.Length < MinDisplayNameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("The display name must be at least {0} characters long",
                    MinUsernameLength));
            }
            else if (displayName.Length > MaxDisplayNameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("The display name must be less than {0} characters long",
                    MaxUsernameLength));
            }
            else if (displayName.Any(ch => !ValidDisplayNameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "The display name must contain only Latin letters, digits, spaces ._-");
            }
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null");
            }
            else if (username.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be at least {0} characters long",
                    MinUsernameLength));
            }
            else if (username.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be less than {0} characters long",
                    MaxUsernameLength));
            }
            else if (username.Any(ch => !ValidUsernameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Username must contain only Latin letters, digits .,_");
            }
        }
    }
}
