using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Books.Data
{
    public class BooksDAL
    {
        public static IList<ReviewComplexData> FindReviewsByAuthorName(string authorName)
        {
            BookstoreEntities context = new BookstoreEntities();

            // By review author
            var reviewsQuery =
                from r in context.Reviews.Include("Books")
                where r.Author.Name == authorName
                select new ReviewComplexData()
                {
                    Date = r.CreationDate,
                    Content = r.Text,
                    Book = r.Book,
                    Authors = r.Book.Authors
                };

            // By book author
            /*var reviewsQuery =
                from r in context.Reviews
                where r.Book.Authors.Any(a => a.Name == authorName)
                select new ReviewComplexData()
                {
                    Date = r.CreationDate,
                    Content = r.Text,
                    Book = r.Book,
                    Authors = r.Book.Authors
                };*/

            reviewsQuery = reviewsQuery.OrderBy(r => r.Date).ThenBy(r => r.Content);

            return reviewsQuery.ToList<ReviewComplexData>();
        }

        public static IList<ReviewComplexData> FindReviewsByPeriod(DateTime startDate, DateTime endDate)
        {
            BookstoreEntities context = new BookstoreEntities();

            var reviewsQuery =
                from r in context.Reviews
                where r.CreationDate >= startDate && r.CreationDate <= endDate
                select new ReviewComplexData()
                {
                    Date = r.CreationDate,
                    Content = r.Text,
                    Book = r.Book,
                    Authors = r.Book.Authors
                };

            reviewsQuery = reviewsQuery.OrderBy(r => r.Date).ThenBy(r => r.Content);

            return reviewsQuery.ToList<ReviewComplexData>();
        }

        public static List<BookReviewsData> FindBooksAndGetReviews(string title, string authorName, long? isbn)
        {
            BookstoreEntities context = new BookstoreEntities();

            var booksQuery =
                from b in context.Books
                select new
                {
                    title = b.Title,
                    isbn = b.ISBN,
                    reviewCount = b.Reviews.Count(),
                    authors = b.Authors
                };

            if (title != null)
            {
                booksQuery = booksQuery.Where(b => b.title.ToLower() == title.ToLower());
            }

            if (isbn != null)
            {
                booksQuery = booksQuery.Where(b => b.isbn == isbn);
            }

            if (authorName != null)
            {
                booksQuery = booksQuery.Where(
                    b => b.authors.Any(a => a.Name.ToLower() == authorName.ToLower())
                    );
            }

            booksQuery = booksQuery.OrderBy(b => b.title);

            List<BookReviewsData> reviewsData = new List<BookReviewsData>();
            foreach (var book in booksQuery)
            {
                BookReviewsData bookReviewsData = new BookReviewsData()
                {
                    Title = book.title,
                    ReviewsCount = book.reviewCount
                };

                reviewsData.Add(bookReviewsData);
            }

            return reviewsData;
        }

        public static void AddBook(string title, long? isbn, decimal? price, string webSite, List<string> authorNames, List<ReviewData> reviews)
        {
            TransactionScope tran = new TransactionScope(
                TransactionScopeOption.Required,
                    new TransactionOptions()
                    {
                        IsolationLevel = IsolationLevel.RepeatableRead
                    });
            using (tran)
            {
                BookstoreEntities context = new BookstoreEntities();
                Book newBook = new Book()
                {
                    Title = title,
                    ISBN = isbn,
                    Price = price,
                    Website = webSite
                };

                foreach (string authorName in authorNames)
                {
                    Author author = CreateOrLoadAuthor(context, authorName);
                    newBook.Authors.Add(author);
                }

                foreach (ReviewData reviewData in reviews)
                {
                    Review newReview = new Review()
                    {
                        CreationDate = reviewData.CreationDate,
                        Text = reviewData.Text
                    };

                    if (reviewData.AuthorName != null)
                    {
                        Author author = CreateOrLoadAuthor(context, reviewData.AuthorName);
                        newReview.Author = author;
                    }

                    newBook.Reviews.Add(newReview);
                }

                context.Books.Add(newBook);
                context.SaveChanges();

                tran.Complete();
            }
        }

        private static Author CreateOrLoadAuthor(
               BookstoreEntities context, string authorName)
        {
            Author existAuthor =
                (from a in context.Authors
                 where a.Name == authorName
                 select a).FirstOrDefault();

            if (existAuthor != null)
            {
                return existAuthor;
            }

            Author newAuthor = new Author();
            newAuthor.Name = authorName;
            context.Authors.Add(newAuthor);
            context.SaveChanges();

            return newAuthor;
        }

        public static void WriteQueryInLog(string queryXml)
        {
            BookstoreEntities context = new BookstoreEntities();

            SearchLog newLog = new SearchLog()
            {
                Date = DateTime.Now,
                QueryXml = queryXml
            };

            context.SearchLogs.Add(newLog);
            context.SaveChanges();
        }
    }
}
