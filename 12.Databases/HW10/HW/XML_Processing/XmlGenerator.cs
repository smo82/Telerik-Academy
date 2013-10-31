/*
 * Task01
 * Create a XML file representing catalogue. 
 * The catalogue should contain albums of different artists. For each album you should define: name, artist, year, producer, price and a list of songs. Each song should be described by title and duration.
 * 
 * Task07
 * In a text file we are given the name, address and phone number of given person (each at a single line). 
 * Write a program, which creates new XML document, which contains these data in structured XML format.
 * 
 * Task08
 * Write a program, which (using XmlReader and XmlWriter) reads the file catalog.xml and creates the file album.xml, 
 * in which stores in appropriate way the names of all albums and their authors.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_Processing
{
    class XmlGenerator
    {
        // Task08
        public static void ExtractAlbumFile(string inputFileName, string outputFileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(inputFileName);

            string xPathQuery = "/catalog/albums/album";
            XmlNodeList albumsList = xmlDoc.SelectNodes(xPathQuery);

            using (XmlTextWriter writer = new XmlTextWriter(outputFileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();

                writer.WriteStartElement("albums-data");

                foreach (XmlNode album in albumsList)
                {
                    writer.WriteStartElement("album");
                    writer.WriteElementString("name", album["name"].InnerText);
                    writer.WriteElementString("artist", album["artist"].InnerText);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();

                writer.WriteEndDocument();
            }
            
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Task08");
            Console.WriteLine("The file with the album details is generated: {0}", outputFileName);
        }

        // Task07
        public static void GeneratePersonFromText(string inputFileName, string outputFileName)
        {
            using (StreamReader reader = new StreamReader(inputFileName))
            {
                using (XmlTextWriter writer = new XmlTextWriter(outputFileName, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = '\t';
                    writer.Indentation = 1;
                    writer.WriteStartDocument();
                    
                    writer.WriteStartElement("person");

                    string personName = reader.ReadLine();
                    writer.WriteElementString("name", personName);

                    string personAddress = reader.ReadLine();
                    writer.WriteElementString("address", personAddress);

                    string personPhone = reader.ReadLine();
                    writer.WriteElementString("phone", personPhone);

                    writer.WriteEndElement();

                    writer.WriteEndDocument();
                }
            }

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Task07");
            Console.WriteLine("Person data file generated: {0}", outputFileName);
        }

        // Task01
        public static void GenerateCatalogFile(string fileName)
        {
            using (XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                CreateCatalog(writer);
                writer.WriteEndDocument();
            }

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Task01");
            Console.WriteLine("Catalog file generated: {0}", fileName);
        }

        private static void CreateCatalog(XmlTextWriter writer)
        {
            writer.WriteStartElement("catalog");
            CreateAlbums(writer);
            writer.WriteEndElement();
        }

        private static void CreateAlbums(XmlTextWriter writer)
        {
            writer.WriteStartElement("albums");

            Album album1 = new Album()
            {
                Name = "Heaven And Hell",
                Artist = "Black Sabbath",
                Year = 1982,
                Producer = "Unknown",
                Price = 100,
                Songs = new List<Song>()
                {
                    new Song()
                    {
                        Title = "Heaven And Hell",
                        Duration = 320
                    },
                    new Song()
                    {
                        Title = "Neon Knights",
                        Duration = 315
                    },
                    new Song()
                    {
                        Title = "Children Of The Sea",
                        Duration = 295
                    },
                    new Song()
                    {
                        Title = "Lady Evil",
                        Duration = 290
                    },
                }
            };

            Album album2 = new Album()
            {
                Name = "Painkiller",
                Artist = "Judas Priest",
                Year = 1990,
                Producer = "Unknown",
                Price = 21,
                Songs = new List<Song>()
                {
                    new Song()
                    {
                        Title = "Painkiller",
                        Duration = 270
                    },
                    new Song()
                    {
                        Title = "Hell Patrol",
                        Duration = 300
                    },
                    new Song()
                    {
                        Title = "All Guns Blazing",
                        Duration = 340
                    },
                    new Song()
                    {
                        Title = "Leather Rebel",
                        Duration = 297
                    },
                }
            };

            Album album3 = new Album()
            {
                Name = "Jugulator",
                Artist = "Judas Priest",
                Year = 1997,
                Producer = "Unknown",
                Price = 18,
                Songs = new List<Song>()
                {
                    new Song()
                    {
                        Title = "Jugulator",
                        Duration = 273
                    },
                    new Song()
                    {
                        Title = "Blood Stained",
                        Duration = 305
                    },
                    new Song()
                    {
                        Title = "Dead Meat",
                        Duration = 291
                    },
                }
            };

            CreateAlbum(writer, album1);
            CreateAlbum(writer, album2);
            CreateAlbum(writer, album3);

            writer.WriteEndElement();
        }

        private static void CreateAlbum(XmlTextWriter writer, Album album)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("name", album.Name);
            writer.WriteElementString("artist", album.Artist);
            writer.WriteElementString("year", album.Year.ToString());
            writer.WriteElementString("producer", album.Producer);
            writer.WriteElementString("price", album.Price.ToString());

            if (album.Songs.Count > 0)
            {
                writer.WriteStartElement("songs");
                foreach (Song song in album.Songs)
                {
                    CreateSong(writer, song);
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        private static void CreateSong(XmlTextWriter writer, Song song)
        {
            writer.WriteStartElement("song");
            writer.WriteElementString("title", song.Title);
            writer.WriteElementString("duration", song.Duration.ToString());
            writer.WriteEndElement();
        }
    }
}
