using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Exam.Web.Controllers
{
    public class CommentsAdministrationController : AdminBaseController
    {
        public ActionResult Index()
        {
            var comments = this.Data.Comments.All();
            return View(comments.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = this.Data.Comments.GetById(id.GetValueOrDefault(0));
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = this.Data.Comments.GetById(id.GetValueOrDefault(0));
            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                this.Data.Comments.Update(comment);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comment);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Comment comment = this.Data.Comments.GetById(id.GetValueOrDefault(0));
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = this.Data.Comments.GetById(id);
            this.Data.Comments.Delete(comment);
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}