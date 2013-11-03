using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.MobileBg.Models
{
    public class Producer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Model> Models { get; set; }
    }
}