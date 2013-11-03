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
    public partial class Categories : System.Web.UI.Page
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

        public IQueryable<ExamProject.Models.Category> GridViewCategories_GetData()
        {
            Entities context = new Entities();

            IQueryable<Category> categories = context.Categories.OrderBy(q => q.CategoryId);
            return categories;
        }

        protected void Create_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.TextBox_CreateCategoryName.Text = string.Empty;

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
                int categoryId = Convert.ToInt32(e.CommandArgument);

                Entities context = new Entities();
                Category category = context.Categories.Find(categoryId);

                this.TextBox_CategoryName.Text = category.CategoryName;
                this.LinkButton_SaveEdit.CommandArgument = categoryId.ToString();

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
                int categoryId = Convert.ToInt32(e.CommandArgument);

                Entities context = new Entities();
                Category category = context.Categories.Find(categoryId);

                this.TextBox_DeleteCategoryName.Text = category.CategoryName;
                this.LinkButton_YesDelete.CommandArgument = categoryId.ToString();

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
                int categoryId = Convert.ToInt32(e.CommandArgument);

                Entities context = new Entities();
                Category category = context.Categories.Find(categoryId);

                category.CategoryName = this.TextBox_CategoryName.Text != string.Empty ? this.TextBox_CategoryName.Text : null;
                context.SaveChanges();

                this.pageMode = Mode.View;
                ErrorSuccessNotifier.AddSuccessMessage("The category was edited successfully!");
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
                int categoryId = Convert.ToInt32(e.CommandArgument);

                Entities context = new Entities();
                Category category = context.Categories.Find(categoryId);

                context.Books.RemoveRange(category.Books);
                context.Categories.Remove(category);

                context.SaveChanges();

                this.pageMode = Mode.View;
                ErrorSuccessNotifier.AddSuccessMessage("The category was deleted successfully!");
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

                Category category = new Category()
                {
                    CategoryName = this.TextBox_CreateCategoryName.Text != string.Empty ? this.TextBox_CreateCategoryName.Text : null
                };

                context.Categories.Add(category);
                context.SaveChanges();

                this.pageMode = Mode.View;
                ErrorSuccessNotifier.AddSuccessMessage("The category was created successfully!");
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