using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02.SumNumberWithMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            
            return View();
        }

        public decimal ProcessSumClick(decimal? firstNumber, decimal? secondNumber)
        {
            decimal firstNumberValue = firstNumber.GetValueOrDefault(0);
            decimal secondNumberValue = secondNumber.GetValueOrDefault(0);

            decimal sum = firstNumberValue + secondNumberValue;
            return sum;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
