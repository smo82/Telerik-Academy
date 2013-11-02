using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Service.Models
{
    public class StudentModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Grade { get; set; }

        public int Age { get; set; }

        public IEnumerable<MarkModel> Marks { get; set; }
    }
}