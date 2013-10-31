/*
 * Task04
 * Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_Processing
{
    class XmlManupulator
    {
        // Task04
        public static void DeleteExpensiveAlbums(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNode rootNode = doc.DocumentElement;
            XmlNode albumsNode = rootNode.FirstChild;

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Task04");
            Console.WriteLine("The expensive albums are deleted:");

            List<XmlNode> nodesToDelete = new List<XmlNode>();
            foreach (XmlNode albumNode in albumsNode.ChildNodes)
            {
                if (decimal.Parse(albumNode["price"].InnerText) > 20)
                {
                    nodesToDelete.Add(albumNode);
                }
            }

            for (int i = 0; i < nodesToDelete.Count; i++)
            {
                albumsNode.RemoveChild(nodesToDelete[i]);
            }

            Console.WriteLine("Number of deleted albums: {0}", nodesToDelete.Count);

            doc.Save(fileName);
        }
    }
}
