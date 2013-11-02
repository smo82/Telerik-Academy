using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SearchNewsArticles
{
    class SearchArticlesMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your search string:");
            string searchString = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Please enter the number of articles you want: ");
            int numberOfArticles = int.Parse(Console.ReadLine());

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://api.feedzilla.com/v1/articles/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Console.Clear();
            Console.WriteLine("Receiving data...");

            GetArticles(searchString, numberOfArticles, httpClient);

            Console.ReadLine();
        }

        private static async void GetArticles(string searchString, int numberOfArticles, HttpClient httpClient)
        {
            HttpResponseMessage response = await httpClient.GetAsync("search.json?q=" + searchString + "&count=" + numberOfArticles);
            string articlesAsString = await response.Content.ReadAsStringAsync();
            ArticlesData articlesData = JsonConvert.DeserializeObject<ArticlesData>(articlesAsString);

            PrintArticles(articlesData);

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Press Enter for exit.");
        }

        private static void PrintArticles(ArticlesData articlesData)
        {
            Console.Clear();
            Console.WriteLine("The articles are:");
            foreach (Article article in articlesData.Articles)
            {
                Console.WriteLine();
                Console.WriteLine(new string('*', 20));
                Console.WriteLine("Name: {0}", article.Title);
                Console.WriteLine();
                Console.WriteLine("Url: {0}", article.Url);
            }
        }
    }
}
