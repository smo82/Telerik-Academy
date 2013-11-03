using Exam.Web.Models;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Exam.Models;

namespace Exam.Web.Controllers
{
    public class CategoriesAdministrationController : AdminBaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadCategories([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.Data.Categories.All()
                .Select(CategoryViewModel.FromCategory);

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var categoryDb = this.Data.Categories.GetById(category.CategoryId);

            categoryDb.Name = category.Name;

            this.Data.SaveChanges();

            return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DestroyCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            Category categoryDb = this.Data.Categories.GetById(category.CategoryId);

            IEnumerable<Ticket> tickets = categoryDb.Tickets.ToList();
            foreach (Ticket ticket in tickets)
            {
                IEnumerable<Comment> comments = ticket.Comments.ToList();

                foreach (Comment comment in comments)
                {
                    this.Data.Comments.Delete(comment);
                }

                this.Data.Tickets.Delete(ticket);
            }

            this.Data.Categories.Delete(categoryDb);
            this.Data.SaveChanges();

            return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null)
            {
                Category categoryDb = new Category()
                {
                    Name = category.Name
                };

                this.Data.Categories.Add(categoryDb);
                this.Data.SaveChanges();

                return Json(new[] { categoryDb }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
	}
}