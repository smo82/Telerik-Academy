using Error_Handler_Control;
using ExamProject.BusinessLogic;
using ExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamProject.LoggedUsers
{
    public partial class Books : System.Web.UI.Page
    {
        private Mode pageMode = Mode.View;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.MainContent_PanelCreate.Visible = false;
            this.MainContent_PanelEdit.Visible = false;
            this.MainContent_PanelDelete.Visible = false;
            this.LinkButton_Create.Visible = true;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            switch (pageMode)
            {
                case Mode.Create:
                    this.LinkButton_Create.Visible = false;
                    this.MainContent_PanelCreate.Visible = true;
                    break;

                case Mode.Edit:
                    this.LinkButton_Create.Visible = false;
                    this.MainContent_PanelEdit.Visible = true;
                    break;

                case Mode.Delete:
                    this.LinkButton_Create.Visible = false;
                    this.MainContent_PanelDelete.Visible = true;
                    break;

                default:
                    break;
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

        public IQueryable<BookViewModel> GridViewBooks_GetData()
        {
            Entities context = new Entities();

            IQueryable<BookViewModel> books = context.Books.Include("Category")
                .Select(b => new BookViewModel { 
                    BookId = b.BookId,
                    Title = b.Title,
                    Author = b.Author,
                    ISBN = b.ISBN,
                    WebSite = b.WebSite,
                    CategoryName = b.Category.CategoryName
                })
                .OrderBy(p => p.BookId);

            return books;
        }
        public IQueryable<Category> DropDownListCategories_GetData()
        {
            Entities context = new Entities();

            IQueryable<Category> categories = context.Categories.OrderBy(q => q.CategoryId);
            return categories;
        }        

        protected void Create_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.TextBox_CreateTitle.Text = string.Empty;
                this.TextBox_CreateAuthor.Text = string.Empty;
                this.TextBox_CreateISBN.Text = string.Empty;
                this.TextBox_CreateWebSite.Text = string.Empty;
                this.TextBox_CreateDescription.Text = string.Empty;
                this.DropDown_CategoriesCreate.SelectedValue = null;

                this.pageMode = Mode.Create;
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        protected void Edit_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int bookId = Convert.ToInt32(e.CommandArgument);

                Entities context = new Entities();
                Book book = context.Books.Find(bookId);

                this.TextBox_EditTitle.Text = book.Title;
                this.TextBox_EditAuthor.Text = book.Author;
                this.TextBox_EditISBN.Text = book.ISBN;
                this.TextBox_EditWebSite.Text = book.WebSite;
                this.TextBox_EditDescription.Text = book.Description;
                this.DropDown_CategoriesEdit.SelectedValue = book.CategoryId.ToString();

                this.LinkButton_SaveEdit.CommandArgument = bookId.ToString();

                this.pageMode = Mode.Edit;
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        protected void Delete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int bookId = Convert.ToInt32(e.CommandArgument);

                Entities context = new Entities();
                Book book = context.Books.Find(bookId);

                this.TextBox_DeleteTitle.Text = book.Title;
                this.LinkButton_YesDelete.CommandArgument = bookId.ToString();

                this.pageMode = Mode.Delete;
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        protected void SaveEdit_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int bookId = Convert.ToInt32(e.CommandArgument);

                if (!Uri.IsWellFormedUriString(this.TextBox_EditWebSite.Text, UriKind.RelativeOrAbsolute))
                {
                    throw new ArgumentException("Invalide URL");
                }

                Entities context = new Entities();
                Book book = context.Books.Find(bookId);

                book.Title = this.TextBox_EditTitle.Text != string.Empty ? this.TextBox_EditTitle.Text : null;
                book.Author = this.TextBox_EditAuthor.Text != string.Empty ? this.TextBox_EditAuthor.Text : null;
                book.ISBN = this.TextBox_EditISBN.Text;
                book.WebSite = this.TextBox_EditWebSite.Text;
                book.Description = this.TextBox_EditDescription.Text;

                int categoryId = int.Parse(this.DropDown_CategoriesEdit.SelectedValue);
                book.CategoryId = categoryId;

                context.SaveChanges();

                this.pageMode = Mode.View;
                ErrorSuccessNotifier.AddSuccessMessage("The book was edited successfully!");
            }
            catch (Exception ex)
            {
                this.pageMode = Mode.Edit;
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        protected void CancelEdit_Command(object sender, CommandEventArgs e)
        {
            this.pageMode = Mode.View;
        }

        protected void YesDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int bookId = Convert.ToInt32(e.CommandArgument);

                Entities context = new Entities();
                Book book = context.Books.Find(bookId);

                context.Books.Remove(book);

                context.SaveChanges();

                this.pageMode = Mode.View;
                ErrorSuccessNotifier.AddSuccessMessage("The book was deleted successfully!");
            }
            catch (Exception ex)
            {
                this.pageMode = Mode.Delete;
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        protected void NoDelete_Command(object sender, CommandEventArgs e)
        {
            this.pageMode = Mode.View;
        }

        protected void SaveCreate_Command(object sender, CommandEventArgs e)
        {
            try
            {
                Entities context = new Entities();

                if (!Uri.IsWellFormedUriString(this.TextBox_CreateWebSite.Text, UriKind.RelativeOrAbsolute))
                {
                    throw new ArgumentException("Invalide URL");
                }

                Book book = new Book()
                {
                    Title = this.TextBox_CreateTitle.Text != string.Empty ? this.TextBox_CreateTitle.Text : null,
                    Author = this.TextBox_CreateAuthor.Text != string.Empty ? this.TextBox_CreateAuthor.Text : null,
                    ISBN = this.TextBox_CreateISBN.Text,
                    WebSite = this.TextBox_CreateWebSite.Text,
                    Description = this.TextBox_CreateDescription.Text,
                };

                int categoryId = int.Parse(this.DropDown_CategoriesCreate.SelectedValue);
                book.CategoryId = categoryId;

                context.Books.Add(book);
                context.SaveChanges();

                this.pageMode = Mode.View;
                ErrorSuccessNotifier.AddSuccessMessage("The book was created successfully!");
            }
            catch (Exception ex)
            {
                this.pageMode = Mode.Create;
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        protected void CancelCreate_Command(object sender, CommandEventArgs e)
        {
            this.pageMode = Mode.View;
        }
    }
}