/*
 * Task02
 * Create console application and demonstrate the use of all service operations using the HttpClient class (with both JSON and XML)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using DataModel;
using Newtonsoft.Json;

namespace WebApiClient
{
    class ClientMain
    {
        static void Main(string[] args)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5289/")
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Print all artists:");
            PrintArtists(client);

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Create new artist:");

            Artist newArtist = new Artist()
            {
                Name = "Metallica",
                Country = "USA",
                DateOfBirth = new DateTime()
            };

            //try
            //{
            Console.WriteLine(JsonConvert.SerializeObject(newArtist));
                Task response = client.PostAsync("api/Artists/", new StringContent(JsonConvert.SerializeObject(newArtist)))
                    .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                Console.WriteLine("Artist created successfully");
            //}
            //catch (exception e)
            //{
            //    console.writeline(e);
            //}

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Print data for artist with id=1:");
            PrintSpecificArtist(client, 1);

            Console.ReadLine();
        }

        private static void PrintSpecificArtist(HttpClient client, int id)
        {
            HttpResponseMessage response = client.GetAsync("api/Artists/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<Artist>().Result;

                Console.WriteLine("{0,-4} {1,-20} {2} : {3:dd-MM-yyyy}", artist.ArtistId, artist.Name.Trim(), artist.Country.Trim(), artist.DateOfBirth);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void PrintArtists(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/Artists").Result;

            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
                foreach (var artist in artists)
                {
                    Console.WriteLine("{0,-4} {1,-20} {2} : {3:dd-MM-yyyy}", artist.ArtistId, artist.Name.Trim(), artist.Country.Trim(), artist.DateOfBirth);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
