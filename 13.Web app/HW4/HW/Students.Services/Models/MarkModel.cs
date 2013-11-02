using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Services.Models
{
    public class MarkModel 
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public decimal Value { get; set; }
        public int StudentId { get; set; }
    }
}