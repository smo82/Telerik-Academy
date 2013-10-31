/*
 * Task02
 * Write program that extracts all different artists which are found in the catalog.xml. 
 * For each author you should print the number of albums in the catalogue. Use the DOM parser and a hash-table.
 * 
 * Task03
 * Implement the previous using XPath.
 * 
 * Task05
 * Write a program, which using XmlReader extracts all song titles from catalog.xml.
 * 
 * Task06
 * Rewrite the same using XDocument and LINQ query.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XML_Processing
{
    class XmlParser
    {
        // Task02
        public static void PrintAuthorsInCatalog(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNode rootNode = doc.DocumentElement;
            XmlNode albumsNode = rootNode.FirstChild;

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Task02");
            Console.WriteLine("For each artist the number of albums is:");

            Dictionary<string, int> autorAlbums = new Dictionary<string, int>();
            foreach (XmlNode albumNode in albumsNode.ChildNodes)
            {
                string authorName = albumNode["artist"].InnerText;
                if (autorAlbums.ContainsKey(authorName))
                {
                    autorAlbums[authorName]++;
                }
                else
                {
                    autorAlbums.Add(authorName, 1);
                }
            }

            foreach (KeyValuePair<string,int> autorData in autorAlbums)
            {
                Console.WriteLine("{0} - {1}", autorData.Key, autorData.Value);
            }
        }

        // Task03
        public static void PrintAuthorsInCatalogXPath(string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            string xPathQuery = "/catalog/albums/album";
            XmlNodeList albumsList = xmlDoc.SelectNodes(xPathQuery);

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Task03");
            Console.WriteLine("For each artist the number of albums is:");

            Dictionary<string, int> autorAlbums = new Dictionary<string, int>();
            foreach (XmlNode albumNode in albumsList)
            {
                string authorName = albumNode["artist"].InnerText;
                if (autorAlbums.ContainsKey(authorName))
                {
                    autorAlbums[authorName]++;
                }
                else
                {
                    autorAlbums.Add(authorName, 1);
                }
            }

            foreach (KeyValuePair<string, int> autorData in autorAlbums)
            {
                Console.WriteLine("{0} - {1}", autorData.Key, autorData.Value);
            }
        }

        // Task05
        public static void PrintAllSongTitles(string fileName)
        {
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Task05");
            Console.WriteLine("All song names are:");
            using (XmlReader reader = XmlReader.Create(fileName))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }

        // Task06
        public static void PrintAllSongTitlesWithLinq(string fileName)
        {
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Task06");
            Console.WriteLine("All song names are (extracted with Rewrite the same using XDocument and LINQ query):");

            XDocument xmlDoc = XDocument.Load(fileName);
            var songs =
                from song in xmlDoc.Descendants("song")
                select new
                {
                    Title = song.Element("title").Value
                };

            foreach (var song in songs)
            {
                Console.WriteLine(song.Title);
            }
        }
    }
}
