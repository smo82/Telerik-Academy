using Books.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Books_Simple_Search
{
    static class BooksSimpleSearch
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../simple-query.xml");

            XmlNode query = xmlDoc.SelectSingleNode("/query");

            string title = GetChildText(query, "title");
            string author = GetChildText(query, "author");
            string isbnString = GetChildText(query, "isbn");
            long? isbn = null;
            if (isbnString != null)
            {
                isbn = long.Parse(isbnString);
            }

            List<BookReviewsData> booksReviewsData = BooksDAL.FindBooksAndGetReviews(title, author, isbn);

            if (booksReviewsData.Count == 0)
            {
                Console.WriteLine("Nothing found");
            }
            else
            {
                foreach (BookReviewsData bookData in booksReviewsData)
                {
                    string reviewsCount = "Nothing found";
                    if (bookData.ReviewsCount > 0)
                    {
                        reviewsCount = bookData.ReviewsCount.ToString();
                    }

                    Console.WriteLine("{0} --> {1}", bookData.Title, reviewsCount);
                }
            }
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
