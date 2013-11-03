using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace _02.Calculator.Models
{
    public class CalculatorData
    {
        public Dictionary<string, string> Types { get; set; }

        public List<string> Kilos { get; set; }

        public string Type { get; set; }

        public string Kilo { get; set; }

        public string Quantity { get; set; }

        public double StartValue { get; set; }

        public Dictionary<string, string> Amounts { get; set; }
    }
}