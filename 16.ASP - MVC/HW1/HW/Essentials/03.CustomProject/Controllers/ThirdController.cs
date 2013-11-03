using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03.CustomProject.Controllers
{
    public class ThirdController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Third controller - Home";

            return View();
        }

        public ActionResult Subpage2()
        {
            ViewBag.Title = "Third controller - Subpage2";

            return View();
        }

        public ActionResult Subpage3()
        {
            ViewBag.Title = "Third controller - Subpage3";

            return View();
        }
    }
}
