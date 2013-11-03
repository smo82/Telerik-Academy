using Northwind.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.EmployeeDetails
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                NORTHWNDEntities context = new NORTHWNDEntities();
                List<object> employees = context.Employees
                    .Select(emp => new { Name = emp.FirstName + " " + emp.LastName, EmployeeID = emp.EmployeeID }).ToList<object>();
                
                this.GridViewEmployees.DataSource = employees;
                
                this.Page.DataBind();
            }
        }

        protected void GridViewEmployees_PageIndexChanging(object sender,
            System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            NORTHWNDEntities context = new NORTHWNDEntities();
            List<object> employees = context.Employees
                .Select(emp => new { Name = emp.FirstName + " " + emp.LastName, EmployeeID = emp.EmployeeID }).ToList<object>();

            this.GridViewEmployees.PageIndex = e.NewPageIndex;
            this.GridViewEmployees.DataSource = employees;

            this.Page.DataBind();
        }
    }
}