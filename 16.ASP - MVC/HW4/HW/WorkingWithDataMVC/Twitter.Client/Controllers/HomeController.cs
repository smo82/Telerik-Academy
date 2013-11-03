using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Models;
using Twitter.Models.ViewModels;

namespace Twitter.Client.Areas.LoggedUsersArea.Controllers
{
    public class HomeController : Controller
    {
        IUowData db;

        public HomeController()
            :this (new UowData())
        {
        }

        public HomeController(IUowData initialDb)
        {
            this.db = initialDb;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            
            var userProfiles = this.db.Users.All().Select(UserProfileViewModel.FromUserProfile).ToList();

            List<TweetViewModel> currentUserTweets = new List<TweetViewModel>();

            UserProfile currentUser = this.db.Users.All().FirstOrDefault();
            if (currentUser != null)
            {
                currentUserTweets = currentUser.Tweets.AsQueryable().Select(TweetViewModel.FromTweet).ToList();
            }

            var tags = this.db.Tags.All().Select(TagViewModel.FromTag).ToList();

            ViewBag.CurrentUserTweets = currentUserTweets;
            ViewBag.UserProfiles = userProfiles;
            ViewBag.Tags = tags;

            return View();
        }
    }
}
