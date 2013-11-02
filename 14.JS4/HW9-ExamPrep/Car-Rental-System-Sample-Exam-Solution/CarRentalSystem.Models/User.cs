using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string AuthenticationCode { get; set; }
        public string SessionKey { get; set; }

        public virtual ICollection<Car> RentedCars { get; set; }
    }
}
