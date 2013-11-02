using Students.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Students.Client
{
    class ClientMain
    {
        static void Main(string[] args)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:51248/")
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response;

            //------------------------------------------------------------
            // Add schools
            //------------------------------------------------------------
            /*for (int i = 0; i < 10; i++)
            {
                SchoolModel schoolModel = new SchoolModel()
                {
                    Name = "School" + i,
                    Location = "Somewhere"
                };

                response = client.PostAsXmlAsync("api/Schools", schoolModel).Result;
            }*/

            //------------------------------------------------------------
            // Print all schools
            //------------------------------------------------------------
            /*response = client.GetAsync("api/Schools").Result;

            if (response.IsSuccessStatusCode)
            {
                var schools = response.Content.ReadAsAsync<IEnumerable<SchoolModel>>().Result;
                foreach (var school in schools)
                {
                    Console.WriteLine("{0,-4} {1,-20}", school.Name.Trim(), school.Location.Trim());
                }

                if (schools.Count() == 0)
                {
                    Console.WriteLine("No schools available!");
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }*/

            //------------------------------------------------------------
            // Get specific school
            //------------------------------------------------------------
            /*response = client.GetAsync("api/Schools/2").Result;

            if (response.IsSuccessStatusCode)
            {
                var school = response.Content.ReadAsAsync<SchoolModel>().Result;
                Console.WriteLine("{0,-4} {1,-20}", school.Name.Trim(), school.Location.Trim());
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }*/

            //------------------------------------------------------------
            // Add students
            //------------------------------------------------------------
            /*for (int i = 0; i < 10; i++)
            {
                StudentModel studentModel = new StudentModel()
                {
                    FirstName = "Test",
                    LastName = i.ToString(),
                    Age = 15,
                    Grade = 7
                };

                response = client.PostAsXmlAsync("api/students", studentModel).Result;
            }*/

            //------------------------------------------------------------
            // Get all students
            //------------------------------------------------------------
            /*response = client.GetAsync("api/Students").Result;

            if (response.IsSuccessStatusCode)
            {
                var students = response.Content.ReadAsAsync<IEnumerable<StudentModel>>().Result;
                foreach (var student in students)
                {
                    Console.WriteLine("{0,-4} {1,-20}", student.FirstName.Trim(), student.LastName.Trim());
                }

                if (students.Count() == 0)
                {
                    Console.WriteLine("No students available!");
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }*/

            //------------------------------------------------------------
            // Get student 2
            //------------------------------------------------------------
            /*response = client.GetAsync("api/Students/2").Result;

            if (response.IsSuccessStatusCode)
            {
                var student = response.Content.ReadAsAsync<StudentModel>().Result;
                Console.WriteLine("{0,-4} {1,-20}", student.FirstName.Trim(), student.LastName.Trim());
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }*/

            //------------------------------------------------------------
            // Get all students with marks for Math and value > 5.00
            //------------------------------------------------------------
            response = client.GetAsync("api/Students?subject=math&value=5.00").Result;

            if (response.IsSuccessStatusCode)
            {
                var students = response.Content.ReadAsAsync<IEnumerable<StudentModel>>().Result;
                foreach (var student in students)
                {
                    Console.WriteLine("{0,-4} {1,-20}", student.FirstName.Trim(), student.LastName.Trim());
                }

                if (students.Count() == 0)
                {
                    Console.WriteLine("No students available!");
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
