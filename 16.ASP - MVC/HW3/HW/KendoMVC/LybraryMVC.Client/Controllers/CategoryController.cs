using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LibraryMVC.Data;
using LybraryMVC.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LybraryMVC.Client.Controllers
{
    public class CategoryController : Controller
    {
        LibraryEntities context;

        public CategoryController()
        {
            context = new LibraryEntities();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadCategories([DataSourceRequest] DataSourceRequest request)
        {
            var categories = context.Categories.Select(CategoryDetailModel.FromCategory);

            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCategory([DataSourceRequest] DataSourceRequest request, int categoryId)
        {
            var category = context.Categories.Find(categoryId);
            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryDetailModel updateCategoryData)
        {
            if (updateCategoryData != null)
            {
                var category = context.Categories.Find(updateCategoryData.CategoryId);
                if (category != null)
                {
                    category.Name = updateCategoryData.Name;
                    context.SaveChanges();

                    return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new[] { updateCategoryData }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryDetailModel updateCategoryData)
        {
            if (updateCategoryData != null)
            {
                Category category = new Category()
                {
                    Name = updateCategoryData.Name
                };

                context.Categories.Add(category);
                context.SaveChanges();

                return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return Json(new[] { updateCategoryData }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

    }
}
