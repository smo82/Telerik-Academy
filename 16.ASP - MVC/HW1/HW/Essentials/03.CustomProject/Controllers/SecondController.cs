using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03.CustomProject.Controllers
{
    public class SecondController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Second controller.";

            return View();
        }

    }
}
