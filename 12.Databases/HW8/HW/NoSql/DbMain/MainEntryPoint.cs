/*
 * Task01
 * Write a simple "Dictionary" application in C# or JavaScript to perform the following in MongoDB:
 *  - Add a dictionary entry (word + translation)
 *  - List all words and their translations
 *  - Find the translation of given word
 * The UI of the application is up to you (it could be Web-based, GUI or console-based).
 * You may use MongoDB-as-a-Service@ MongoLab.
 * You may install the "Official MongoDB C# Driver" from NuGet or download it from its publisher: http://docs.mongodb.org/ecosystem/drivers/csharp/
 * 
 */

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMain
{
    public class MainEntryPoint
    {
        /*
         * The application uses local installation of MongoDb
         * Database name: "Dictionary"
         * Table with entries name: "Entry"
         */

        public static void Main()
        {
            string mongoDbConnectionString = Settings.Default.MongoDbConnectionString;
            MongoDatabase mongoDb = Connector.GetDb(mongoDbConnectionString, "Dictionary");
            MongoCollection entryMongoDb = mongoDb.GetCollection("entry");

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Please enter a word:");
            string newWord = Console.ReadLine();

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Please enter the word translation:");
            string newWordTranslation = Console.ReadLine();

            BsonDocument newEntry = new BsonDocument()
            {
                {"word", newWord},
                {"translation", newWordTranslation}
            };

            entryMongoDb.Insert(newEntry);

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("All words in the dictionary are:");
            MongoCursor<BsonDocument> allWordsInDicitonary = mongoDb.GetCollection("entry").FindAll();

            foreach (var word in allWordsInDicitonary)
            {
                string wordText = word.Elements.Single(x => x.Name == "word").Value.ToString();
                string wordTranslation = word.Elements.Single(x => x.Name == "translation").Value.ToString();
                Console.WriteLine("{0} - {1}", wordText, wordTranslation);
            }

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Please enter the word you are searching for:");
            string searchedWord = Console.ReadLine();

            var searchedWordResult = allWordsInDicitonary.FirstOrDefault(x => x.Elements.Single(e => e.Name == "word").Value.ToString() == searchedWord);

            if (searchedWordResult != null)
            {
                Console.WriteLine("Your word translation is: {0}", searchedWordResult.Single(x => x.Name == "translation").Value.ToString());
            }
            else
            {
                Console.WriteLine("No such word in the dictionary");
            }
        }
    }
}
