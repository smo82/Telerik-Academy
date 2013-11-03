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
    public class LibraryController : Controller
    {
        LibraryEntities context;

        public LibraryController()
        {
            context = new LibraryEntities();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
