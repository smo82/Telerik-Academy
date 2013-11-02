using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Models
{
    public class CarState
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public CarState()
        {
            this.Cars = new HashSet<Car>();
        }
    }
}
