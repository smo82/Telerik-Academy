using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Services.Models
{
    public class SchoolDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public IEnumerable<StudentModel> Students { get; set; }
    }
}