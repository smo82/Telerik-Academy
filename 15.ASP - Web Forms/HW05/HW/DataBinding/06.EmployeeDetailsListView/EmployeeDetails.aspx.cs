using Northwind.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.EmployeeDetailsListView
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                NORTHWNDEntities context = new NORTHWNDEntities();
                List<Employee> employees = context.Employees.ToList<Employee>();

                this.ListViewEmployees.DataSource = employees;

                this.Page.DataBind();
            }
        }
    }
}