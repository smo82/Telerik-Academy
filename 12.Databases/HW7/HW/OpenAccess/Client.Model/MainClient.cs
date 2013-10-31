/*
 * Task01
 * Customize code generation
 * Customize the OpenAccess Code Generation T4 templates so that all the generated classes inherit from a single non-persistent class. 
 * Then generate a model out of a Northwind database and demonstrate that with the generated OpenAccessContext and persistent classes you are able to retrieve and 
 * update data in a small console application (under the same solution but in a separate project).
 */
using OpenAccessModel1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    class MainClient
    {
        static void Main(string[] args)
        {
            using (NWEntitiesModel context = new NWEntitiesModel())
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine("All the categories in the Northwind DB are:");
                foreach (Category category in context.Categories)
                {
                    Console.WriteLine("{0}", category.CategoryName);
                }

                Console.WriteLine(new string('*', 20));
                Console.WriteLine("All the customers in the Northwind DB are:");
                foreach (Customer customer in context.Customers)
                {
                    Console.WriteLine("{0}", customer.ContactName);
                }
            }
        }
    }
}
