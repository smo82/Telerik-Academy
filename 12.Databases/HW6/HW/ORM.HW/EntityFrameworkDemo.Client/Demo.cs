using NWEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Client
{
    class Demo
    {
        static void Main()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                foreach (var customer in db.Customers.Where(x => x.Country == "Mexico"))
                {
                    Console.WriteLine(customer.ContactName);
                }

                var customers = db.Customers.Where(c => c.Country == "UK")
                    .OrderBy(x => x.ContactName)
                    .Where(x => x.City == "London")
                    .Select(x => new { x.Address });

                var customers2 = db.Customers;

                Console.WriteLine(customers.ToString());
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.Address);
                }

                var region = new Region
                {
                    RegionDescription = "Central"
                };

                db.Regions.Add(region);
                db.SaveChanges();

                Customer newCustomer = new Customer
                {
                    CompanyName = "Telerik"
                };

                db.Customers.Add(newCustomer);
                db.SaveChanges();
            }
        }
    }
}
