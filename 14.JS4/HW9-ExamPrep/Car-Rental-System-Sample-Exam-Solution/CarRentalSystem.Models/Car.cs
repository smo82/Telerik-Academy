using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Power { get; set; }
        public int Engine { get; set; }

        public virtual CarState State { get; set; }
        public virtual Store Store { get; set; }

        public virtual User RentedBy { get; set; }
    }
}
