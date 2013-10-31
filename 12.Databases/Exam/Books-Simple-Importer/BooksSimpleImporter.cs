using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Transactions;
using Books.Data;

namespace Books_Simple_Importer
{
    static class BooksSimpleImporter
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../simple-books.xml");
            string xPathQuery = "/catalog/book";

			XmlNodeList booksList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode bookNode in booksList)
            {
                string title = bookNode.GetObligatoryChildText("title");
                string isbnString = bookNode.GetChildText("isbn");
                long? isbn = null;
                if (isbnString != null)
                {
                    isbn = long.Parse(isbnString);
                }

                string priceString = bookNode.GetChildText("price");
                decimal? price = null;
                if (priceString != null)
                {
                    price = decimal.Parse(priceString);
                }

                string webSite = bookNode.GetChildText("web-site");
                
                string authorName = bookNode.GetObligatoryChildText("author");

                BooksDAL.AddBook(title, isbn, price, webSite, new List<string>() { authorName }, new List<ReviewData> (){ });
            }
        }

        private static string GetObligatoryChildText(this XmlNode node, string tagName)
        {
            XmlNode childNode = node.SelectSingleNode(tagName);
            if (childNode == null)
            {
                throw new ArgumentNullException(string.Format("The {} tag is mandatory!", tagName));
            }
            return childNode.InnerText.Trim();
        }

        private static string GetChildText(this XmlNode node, string tagName)
        {
            XmlNode childNode = node.SelectSingleNode(tagName);
            if (childNode == null)
            {
                return null;
            }
            return childNode.InnerText.Trim();
        }
    }
}
