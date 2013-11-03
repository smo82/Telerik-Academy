using LibraryMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LybraryMVC.Client.ViewModels
{
    public class BookDetailModel
    {
        public static Expression<Func<Book, BookDetailModel>> FromBook
        {
            get
            {
                return book => new BookDetailModel
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    Content = book.Content,
                    Author = book.Author,
                    CategoryId = book.CategoryId
                };
            }
        }

        public int CategoryId { get; set; }

        public int BookId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }
    }
}