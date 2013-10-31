/*
 * Task02
 * Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. Write a testing class.
 * 
 * Task03
 * Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
 * 
 * Task04
 * Implement previous by using native SQL query and executing it through the DbContext.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NWEntityFramework;

namespace HW.ORM
{
    class MainTest
    {
        static void Main(string[] args)
        {
            // Task02
            TestDAOCustomers();

            // Task03
            FindAndPrintCustemersWhoShippedToCanadaIn1997();

            // Task04
            FindCustemersNativeSQL();
        }

        private static void FindCustemersNativeSQL()
        {
            // Task04
            Console.WriteLine();
            Console.WriteLine(new string('*', 30));
            Console.WriteLine("The customers found true native SQL query are:");
            IEnumerable<Customer> customers;

            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                string nativeSqlQuery =
                    "SELECT * " +
                    "FROM dbo.Customers c " +
                    "JOIN dbo.Orders o " +
                    "ON c.CustomerID = o.CustomerID " +
                    @"WHERE o.ShipCountry = N'Canada' AND o.ShippedDate >= '1997-01-01' AND o.ShippedDate <= '1997-12-31'";

                object[] parameters = { };
                customers = dbContext.Database.SqlQuery<Customer>(
                    nativeSqlQuery, parameters);

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer);
                }
            }
        }

        private static void FindAndPrintCustemersWhoShippedToCanadaIn1997()
        {
            //Task03
            List<Customer> result;

            result = GetCustomersHowShippedToCanadaIn1997();

            Console.WriteLine();
            Console.WriteLine(new string('*', 30));
            Console.WriteLine("The customers found are:");

            foreach (Customer customer in result)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        private static List<Customer> GetCustomersHowShippedToCanadaIn1997()
        {
            List<Customer> result;
            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                result =
                    (from c in dbContext.Customers
                     join o in dbContext.Orders
                         on c.CustomerID equals o.CustomerID
                     where o.ShipCountry == "Canada" && o.ShippedDate >= new DateTime(1997, 1, 1) && o.ShippedDate <= new DateTime(1997, 12, 31)
                     select c).ToList<Customer>();
            }
            return result;
        }

        private static void TestDAOCustomers()
        {
            // Task02
            Customer newCustomer = new Customer()
            {
                CustomerID = "SSSSS",
                CompanyName = "Telerik",
                ContactName = "NewCustomer",
                ContactTitle = "Senior Developer",
                Address = "Mladost1",
                City = "Sofia",
                Region = "Sofia",
                PostalCode = "1000",
                Country = "Bulgaria",
                Phone = "0888-888-888",
                Fax = "0888-888-888"
            };


            string newCustomerID = DAOCustomers.Insert(newCustomer);

            Console.WriteLine("Inserted customer data {0}:", newCustomerID);
            Console.WriteLine(newCustomer);

            newCustomer.ContactName = "NewCustomerUpdated";

            DAOCustomers.Update(newCustomer);
            Console.WriteLine();
            Console.WriteLine(new string('*', 30));
            Console.WriteLine("Updated customer data:");
            Console.WriteLine(newCustomer);

            Console.WriteLine();
            Console.WriteLine(new string('*', 30));
            try
            {
                DAOCustomers.Delete(newCustomer);
                Console.WriteLine("Customer record deleted!");
            }
            catch (Exception)
            {
                Console.WriteLine("Customer record NOT deleted.");
            }
        }
    }
}
