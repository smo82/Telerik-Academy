using Error_Handler_Control;
using ExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamProject
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Entities context = new Entities();

                IQueryable<Book> books = context.Books.OrderBy(p => p.BookId);
                List<Book> booksAsList = books.ToList<Book>();
                this.FormView_Book.DataSource = booksAsList;

                int bookId = int.Parse(Request.QueryString["id"]);
                Book currentBook = booksAsList.Find(b => b.BookId == bookId);

                int bookIndex = booksAsList.IndexOf(currentBook);
                
                if (bookIndex < 0)
                {
                    throw new ArgumentException("Invalide book id");
                }

                this.FormView_Book.PageIndex = bookIndex;
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
            
            try
            {
                this.Page.DataBind();
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public object FormView_Book_GetItem(int id)
        {
            return null;
        }
    }
}