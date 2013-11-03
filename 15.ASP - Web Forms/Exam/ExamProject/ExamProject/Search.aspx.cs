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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string queryString = Request.QueryString["q"].ToString();

                this.Literal_Query.Text = Server.HtmlEncode(queryString);

                Entities context = new Entities();

                IQueryable<Book> books = context.Books.Include("Category")
                    .Where(b => b.Title.Contains(queryString) || b.Author.Contains(queryString))
                    .OrderBy(b => b.Title).ThenBy(b => b.Author);

                this.Repeater_Books.DataSource = books.ToList<Book>();
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
    }
}