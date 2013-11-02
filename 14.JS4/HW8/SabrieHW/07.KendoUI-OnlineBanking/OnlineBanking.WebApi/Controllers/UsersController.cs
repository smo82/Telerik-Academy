using OnlineBanking.Context;
using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace OnlineBanking.WebApi.Controllers
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

        public UsersController()
        {
        }

        /*
        {   "username": "DonchoMinkov",
            "authCode":   "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e" }

        */

        // api/users/register
        [ActionName("register")]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new OnlineBankContext();
                    using (context)
                    {
                        this.ValidateUsername(model.DisplayName);
                        this.ValidateAuthCode(model.AuthCode);
                        var displayNameToLower = model.DisplayName.ToLower();

                        var user = context.Users.FirstOrDefault(
                            usr => usr.Username == displayNameToLower
                            || usr.AuthCode == model.AuthCode);

                        if (user != null)
                        {
                            throw new InvalidOperationException("User exists");
                        }

                        user = new User()
                        {
                            Username = displayNameToLower,
                            AuthCode = model.AuthCode
                        };

                        context.Users.Add(user);
                        context.SaveChanges();

                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        context.SaveChanges();

                        var loggedModel = new LoggedUserModel()
                        {
                            DisplayName = user.Username,
                            SessionKey = user.SessionKey
                        };

                        var response =
                            this.Request.CreateResponse(HttpStatusCode.Created,
                                            loggedModel);
                        return response;
                    }
                });

            return responseMsg;
        }

        // api/users/login
        [ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  var context = new OnlineBankContext();
                  using (context)
                  {
                      this.ValidateUsername(model.DisplayName);
                      this.ValidateAuthCode(model.AuthCode);
                      var usernameToLower = model.DisplayName.ToLower();
                      var user = context.Users.FirstOrDefault(
                          usr => usr.Username == usernameToLower
                          && usr.AuthCode == model.AuthCode);

                      if (user == null)
                      {
                          throw new InvalidOperationException("Invalid username or password");
                      }
                      if (user.SessionKey == null)
                      {
                          user.SessionKey = this.GenerateSessionKey(user.Id);
                          context.SaveChanges();
                      }

                      var loggedModel = new LoggedUserModel()
                      {
                          DisplayName = user.Username,
                          SessionKey = user.SessionKey
                      };

                      var response =
                          this.Request.CreateResponse(HttpStatusCode.Created,
                                          loggedModel);
                      return response;
                  }
              });

            return responseMsg;
        }

        // api/users/logout?sessionKey=1amGUjtrsYtfTgamfraSxzxCxuYAmbiFebfTlxAvlnLxVwbUoJ
        [ActionName("logout")]
        public HttpResponseMessage PutLogoutUser(string sessionKey)
        {
            var context = new OnlineBankContext();

            var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);

            user.SessionKey = null;
            context.SaveChanges();

            var response =
                          this.Request.CreateResponse(HttpStatusCode.OK);
            return response;
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
                throw new ArgumentNullException("Display name cannot be null");
            }
            else if (displayName.Length < MinDisplayNameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Display name must be at least {0} characters long",
                    MinDisplayNameLength));
            }
            else if (displayName.Length > MaxDisplayNameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Display name must be less than {0} characters long",
                    MaxDisplayNameLength));
            }
            else if (displayName.Any(ch => !ValidDisplayNameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Display name must contain only Latin letters, digits .,_");
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
