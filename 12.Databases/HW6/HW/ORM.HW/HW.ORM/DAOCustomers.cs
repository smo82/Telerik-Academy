/*
 * Task02
 * Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. Write a testing class.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NWEntityFramework;

namespace HW.ORM
{
    class DAOCustomers
    {
        public static Customer GetCustomerById(string customerId)
        {
            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                Customer resultCustomer = dbContext.Customers.Find(customerId);

                return resultCustomer;
            }
        }

        public static string Insert(Customer newCustomer)
        {
            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                dbContext.Customers.Add(newCustomer);
                dbContext.SaveChanges();

                return newCustomer.CustomerID;
            }
        }

        public static void Update(Customer updatedCustomer)
        {
            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                dbContext.Customers.Attach(updatedCustomer);
                dbContext.SaveChanges();
            }
        }

        public static void Delete(Customer deletedCustomer)
        {
            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                dbContext.Customers.Attach(deletedCustomer);
                dbContext.Customers.Remove(deletedCustomer);
                dbContext.SaveChanges();
            }
        }
    }
}
