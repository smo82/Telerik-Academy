using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.InternationalCompany
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LanguageChange(object sender, CommandEventArgs e)
        {
            string commandName = e.CommandName.ToString();

            HttpContext.Current.Session["language"] = commandName;
        }
    }
}