using Books.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CodeFirst.Data;

namespace Books_Complex_Search
{
    static class BooksComplexSearch
    {

        /*
         * PLEASE NOTE THAT THE SEARCH BY AUTHOR IS IMPLEMENTED USING THE REVIEW AUTHOR
         * 
         * IN THE BooksDAL.FindReviewsByAuthorName I HAVE ALSO AN IMPLEMENTATION USING THE BOOK AUTHOR, WHICH JUST NEEDS TO BE UNCOMMENTED AND WILL WORK
         * 
         */
        static void Main(string[] args)
        {
            string fileName = "../../reviews-search-results.xml";
            using (XmlTextWriter writer =
                new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("search-results");

                ProcessSearchQueries(writer);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private static void ProcessSearchQueries(XmlTextWriter writer)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../reviews-queries.xml");
            string xPathQuery = "/review-queries/query";

            XmlNodeList queriesList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode queryNode in queriesList)
            {
                var queryType = queryNode.Attributes["type"].InnerText;

                IList<ReviewComplexData> reviews;
                if (queryType == "by-period")
                {
                    string startDateString = GetChildText(queryNode, "start-date");
                    string endDateString = GetChildText(queryNode, "end-date");

                    CultureInfo provider = CultureInfo.InvariantCulture;
                    DateTime startDate = DateTime.ParseExact(startDateString, "d-MMM-yyyy", provider);
                    DateTime endDate = DateTime.ParseExact(endDateString, "d-MMM-yyyy", provider);

                    reviews = BooksDAL.FindReviewsByPeriod(startDate, endDate);
                }
                else
                {
                    string authorName = GetChildText(queryNode, "author-name");

                    reviews = BooksDAL.FindReviewsByAuthorName(authorName);
                }

                WriteReviews(writer, reviews);

                //BooksDAL.WriteQueryInLog(queryNode.OuterXml);

                /* USING CODE FIRST */
                SearchLogDAL.WriteQueryInLog(queryNode.OuterXml);
            }
        }

        private static void WriteReviews(XmlTextWriter writer, IList<ReviewComplexData> reviews)
        {
            writer.WriteStartElement("result-set");
            foreach (var review in reviews)
            {
                writer.WriteStartElement("review");
                if (review.Date != null)
                {
                    writer.WriteElementString("date", String.Format("{0:d-MMM-yyyy}", review.Date));
                }

                if (review.Content != null)
                {
                    writer.WriteElementString("content", review.Content);
                }

                writer.WriteStartElement("book");
                
                if (review.Book.Title != null)
                {
                    writer.WriteElementString("title", review.Book.Title);
                }

                ICollection<Author> authors = review.Authors;

                if (authors.Count > 0)
                {
                    string authorsString = string.Join(", ",
                        authors.Select(a => a.Name).OrderBy(t => t));
                    writer.WriteElementString("authors", authorsString);
                }

                if (review.Book.ISBN != null)
                {
                    writer.WriteElementString("isbn", review.Book.ISBN.ToString());
                }
                
                if (review.Book.Website != null)
                {
                    writer.WriteElementString("url", review.Book.Website);
                }

                writer.WriteEndElement();

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
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
