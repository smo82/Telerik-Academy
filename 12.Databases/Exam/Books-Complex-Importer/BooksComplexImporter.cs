using Books.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Books_Complex_Importer
{
    static class BooksComplexImporter
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../complex-books.xml");
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
                
                List<string> authorNames = GetAuthors(bookNode, "authors/author");

                List<ReviewData> reviews = GerReviews(bookNode, "reviews/review");

                BooksDAL.AddBook(title, isbn, price, webSite, authorNames, reviews);
            }
        }

        private static List<ReviewData> GerReviews(XmlNode bookNode, string xPathQuery)
        {
            List<ReviewData> reviewsData = new List<ReviewData>();

            XmlNodeList reviewsList = bookNode.SelectNodes(xPathQuery);
            foreach (XmlNode reviewNode in reviewsList)
            {
                string reviewText = reviewNode.InnerText.Trim();

                var reviewAuthorAttribute = reviewNode.Attributes["author"];
                string reviewAuthor = null;
                if (reviewAuthorAttribute != null)
                {
                    reviewAuthor = reviewAuthorAttribute.InnerText.Trim();
                }

                var reviewCreationDateAttribute = reviewNode.Attributes["date"];
                DateTime reviewCreationDate = DateTime.Now;
                if (reviewCreationDateAttribute != null)
                {
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    string reviewCreationDateString = reviewCreationDateAttribute.InnerText;
                    reviewCreationDate = DateTime.ParseExact(reviewCreationDateString, "d-MMM-yyyy", provider); 
                }

                ReviewData reviewData = new ReviewData()
                {
                    CreationDate = reviewCreationDate,
                    Text = reviewText,
                    AuthorName = reviewAuthor
                };

                reviewsData.Add(reviewData);
            }

            return reviewsData;
        }

        private static List<string> GetAuthors(XmlNode bookNode, string xPathQuery)
        {
            List<string> authorNames = new List<string>();

            XmlNodeList authorsList = bookNode.SelectNodes(xPathQuery);
            foreach (XmlNode authorNode in authorsList)
            {
                string authorName = authorNode.InnerText;
                authorNames.Add(authorName);
            }

            return authorNames;
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
