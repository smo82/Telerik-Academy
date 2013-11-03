using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Twitter.Client.Filters;
using Twitter.Data;
using Twitter.Models;
using WebMatrix.WebData;

namespace Twitter.Client.Areas.LoggedUsersArea.Controllers
{
    [InitializeSimpleMembership]
    public class ProfileController : Controller
    {
        IUowData db;

        public ProfileController()
            : this(new UowData())
        {
        }

        public ProfileController(IUowData initialDb)
        {
            this.db = initialDb;
        }

        public ActionResult Index()
        {
            UserProfile currentUser = db.Users.GetById(WebSecurity.CurrentUserId);
            return View(currentUser.Tweets.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Tweet tweet = db.Tweets.GetById(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tweet tweet)
        {
            if (User.Identity.IsAuthenticated)
            {
                tweet.User = db.Users.GetById(WebSecurity.CurrentUserId);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (tweet.Tags == null)
            {
                tweet.Tags = new HashSet<Tag>();
            }

            if (ModelState.IsValidField("Content"))
            {
                ManageTweetTags(tweet);

                db.Tweets.Add(tweet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tweet);
        }

        public ActionResult Edit(int id = 0)
        {
            Tweet tweet = db.Tweets.GetById(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }

            return View(tweet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tweet tweet)
        {
            if (User.Identity.IsAuthenticated)
            {
                tweet.User = db.Users.GetById(WebSecurity.CurrentUserId);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (tweet.Tags == null)
            {
                tweet.Tags = new HashSet<Tag>();
            }

            if (ModelState.IsValidField("Content"))
            {
                ManageTweetTags(tweet);

                db.Tweets.Update(tweet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tweet);
        }

        public ActionResult Delete(int id = 0)
        {
            Tweet tweet = db.Tweets.GetById(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tweet tweet = db.Tweets.GetById(id);
            db.Tweets.Delete(tweet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        #region Private methods
        private void ManageTweetTags(Tweet tweet)
        {
            Regex regEx = new Regex(@"\s+");
            string[] tags = regEx.Split(tweet.Content);

            foreach (string tag in tags)
            {
                Tag newTag = db.Tags.All().FirstOrDefault(t => t.Name == tag);

                if (newTag == null)
                {
                    newTag = new Tag()
                    {
                        Name = tag
                    };

                    db.Tags.Add(newTag);
                }

                tweet.Tags.Add(newTag);
            }
        }
        #endregion
    }
}
