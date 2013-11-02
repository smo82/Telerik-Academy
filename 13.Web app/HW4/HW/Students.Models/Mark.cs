using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public decimal Value { get; set; }

        public virtual Student Student { get; set; }
    }
}
