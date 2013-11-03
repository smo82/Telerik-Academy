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
    public class BookController : Controller
    {
        LibraryEntities context;

        public BookController()
        {
            context = new LibraryEntities();
        }

        public ActionResult Index()
        {
            var categories = context.Categories.Select(CategoryDetailModel.FromCategory).ToList();

            ViewData["categories"] = categories;
            return View(categories);
        }

        public JsonResult ReadBooks([DataSourceRequest] DataSourceRequest request)
        {
            var books = context.Books.Select(BookDetailModel.FromBook);

            return Json(books.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteBook([DataSourceRequest] DataSourceRequest request, int bookId)
        {
            var book = context.Books.Find(bookId);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }

            return Json(new[] { book }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateBook([DataSourceRequest] DataSourceRequest request, BookDetailModel updateBookData)
        {
            if (updateBookData != null)
            {
                var book = context.Books.Find(updateBookData.BookId);
                if (book != null)
                {
                    book.Title = updateBookData.Title;
                    book.Author = updateBookData.Author;
                    book.Content = updateBookData.Content;
                    book.CategoryId = updateBookData.CategoryId;
                    context.SaveChanges();

                    return Json(new[] { BookDetailModel.FromBook.Compile()(book) }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new[] { updateBookData }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateBook([DataSourceRequest] DataSourceRequest request, BookDetailModel updateBookData)
        {
            if (updateBookData != null)
            {
                updateBookData.CategoryId = updateBookData.CategoryId == 0 ? context.Categories.First().CategoryId : updateBookData.CategoryId;
                Book book = new Book()
                {
                    Title = updateBookData.Title,
                    Author = updateBookData.Author,
                    Content = updateBookData.Content,
                    CategoryId = updateBookData.CategoryId
                };

                context.Books.Add(book);
                context.SaveChanges();

                return Json(new[] { BookDetailModel.FromBook.Compile()(book) }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return Json(new[] { updateBookData }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

    }
}
