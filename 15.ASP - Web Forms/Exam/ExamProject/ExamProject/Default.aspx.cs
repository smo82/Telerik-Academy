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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Category> ListViewBooks_GetData()
        {
            Entities context = new Entities();

            IQueryable<Category> categories = context.Categories.Include("Books").OrderBy(p => p.CategoryId);
            return categories;
        }
        protected void Search_Command(object sender, CommandEventArgs e)
        {
            TextBox textBoxSearchField = this.ListViewBooks.FindControl("TextBox_SearchField") as TextBox;
            
            try
            {
                if (textBoxSearchField.Text.Length > 8000)
                {
                    throw new ArgumentException("Query string too long!");
                }

                Response.Redirect("Search?q=" + textBoxSearchField.Text, false);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }
    }
}