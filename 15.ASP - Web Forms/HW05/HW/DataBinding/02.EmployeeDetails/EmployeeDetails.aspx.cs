using Northwind.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.EmployeeDetails
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NORTHWNDEntities context = new NORTHWNDEntities();
            List<object> employees = context.Employees.ToList<object>();

            this.DetailsViewEmployeeDetails.DataSource = employees;
            
            if (Request.Params["Id"] != null)
            {
                this.DetailsViewEmployeeDetails.PageIndex = int.Parse(Request.Params["id"]);
            }

            this.Page.DataBind();
        }

        protected void DetailsViewEmployeeDetails_PageIndexChanging(object sender,
            System.Web.UI.WebControls.DetailsViewPageEventArgs e)
        {
            NORTHWNDEntities context = new NORTHWNDEntities();
            List<object> employees = context.Employees.ToList<object>();

            this.DetailsViewEmployeeDetails.PageIndex = e.NewPageIndex;
            this.DetailsViewEmployeeDetails.DataSource = employees;
            this.DetailsViewEmployeeDetails.DataBind();
        }
    }
}