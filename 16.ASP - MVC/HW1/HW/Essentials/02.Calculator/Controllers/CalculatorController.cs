using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using _02.Calculator.Models;
using System.Numerics;

namespace _02.Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        public ActionResult Index(CalculatorData @calculatorInputData)
        {
            string kiloAsString = @calculatorInputData.Kilo != null ? @calculatorInputData.Kilo : "1000";
            string typeAsString = @calculatorInputData.Type != null ? @calculatorInputData.Type : "b";
            string quantityAsString = @calculatorInputData.Quantity != null ? @calculatorInputData.Quantity : "1";
            
            int quantity = 1;
            int.TryParse(quantityAsString, out quantity);

            double startValue = quantity;

            int kilo = 1000;
            if (@calculatorInputData.Kilo != null)
            {
                int.TryParse(@calculatorInputData.Kilo, out kilo);
            }

            bool isBit = true;
            bool firstPass = true;

            foreach (KeyValuePair<string, string> type in CalculatorController.Types)
            {
                if (isBit && !firstPass)
                {
                    startValue = startValue * kilo;
                }

                if (type.Key == typeAsString)
                {
                    break;
                }

                firstPass = false;
                isBit = !isBit;
            }

            if (!isBit)
            {
                startValue = startValue * 8;
            }

            isBit = true;
            double power = 1;
            Dictionary<string, string> amounts = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> type in CalculatorController.Types)
            {
                if (isBit)
                {
                    double result = startValue / power;
                    amounts.Add(type.Key, result.ToString());
                }
                else
                {
                    double result = startValue / (power * 8);
                    amounts.Add(type.Key, result.ToString());
                    power = power * kilo;
                }

                isBit = !isBit;
            }

            CalculatorData calculatorData = new CalculatorData()
            {
                Types = CalculatorController.Types,
                Kilos = CalculatorController.Kilos,
                Type = typeAsString,
                Kilo = kiloAsString,
                Quantity = quantityAsString,
                StartValue = startValue,
                Amounts = amounts
            };

            return View(calculatorData);
        }

        public static readonly Dictionary<string, string> Types = new Dictionary<string, string>()
        {
            {"b", "Bit"},
            {"B", "Byte"},
            {"Kb", "Kilobit"},
            {"KB", "Kilobyte"},
            {"Mb", "Megabit"},
            {"MB", "Megabyte"},
            {"Gb", "Gigabit"},
            {"GB", "Gigabyte"},
            {"Tb", "Terabit"},
            {"TB", "Terabyte"},
            {"Pb", "Petabit"},
            {"PB", "Petabyte"},
            {"Eb", "Exabit"},
            {"EB", "Exabyte"},
            {"Zb", "Zettabit"},
            {"ZB", "Zettabyte"},
            {"Yb", "Yottabit"},
            {"YB", "Yottabyte"},
        };

        public static readonly List<string> Kilos = new List<string>()
        {
            "1000",
            "1024"
        };
    }
}
