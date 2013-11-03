using Northwind.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.EmployeeDetailsFormView
{
    public partial class EmployeeData : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            NORTHWNDEntities context = new NORTHWNDEntities();
            List<Employee> employees = context.Employees.ToList<Employee>();

            this.FormViewEmployee.DataSource = employees;

            this.Page.DataBind();
        }

        protected void FormViewEmployee_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            NORTHWNDEntities context = new NORTHWNDEntities();
            List<Employee> employees = context.Employees.ToList<Employee>();

            this.FormViewEmployee.PageIndex = e.NewPageIndex;
            this.FormViewEmployee.DataSource = employees;

            this.Page.DataBind();
        }

        protected void LinkButtonDetail_Click(object sender, EventArgs e)
        {
            this.FormViewEmployee.ChangeMode(FormViewMode.Edit);
            this.FormViewEmployee.AllowPaging = false;
        }

        protected void LinkButtonMain_Click(object sender, EventArgs e)
        {
            this.FormViewEmployee.ChangeMode(FormViewMode.ReadOnly);
            this.FormViewEmployee.AllowPaging = true;
        }
    }
}