using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Models;
using Twitter.Models.ViewModels;

namespace Twitter.Client.Controllers
{
    public class TweetsController : Controller
    {
        IUowData db;

        public TweetsController()
            :this (new UowData())
        {
        }

        public TweetsController(IUowData initialDb)
        {
            this.db = initialDb;
        }

        public ActionResult GetByUser(int userId)
        {
            IEnumerable<TweetViewModel> tweets = this.db.Tweets.All().Where(tweet => tweet.User.UserId == userId).Select(TweetViewModel.FromTweet).ToList();

            return PartialView("_DisplayTweets", tweets);
        }

        public ActionResult GetByTag(int tagId)
        {
            IEnumerable<TweetViewModel> tweets = this.db.Tweets.All().Where(tweet => tweet.Tags.Any(t => t.TagId == tagId)).Select(TweetViewModel.FromTweet).ToList();

            return PartialView("_DisplayTweets", tweets);
        }
    }
}
