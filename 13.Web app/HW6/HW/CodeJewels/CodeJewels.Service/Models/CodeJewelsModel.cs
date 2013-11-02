using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeJewels.Service.Models
{
    public class CodeJewelModel
    {
        public int CodeJewelId { get; set; }

        public int CategoryId { get; set; }

        public string SourseCode { get; set; }

        public string AuthorEmail { get; set; }

        public int Rating { get; set; }
    }
}