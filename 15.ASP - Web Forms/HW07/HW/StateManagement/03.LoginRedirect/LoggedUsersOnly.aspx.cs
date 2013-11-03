using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.LoginRedirect
{
    public partial class LoggedUsersOnly : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie isUserLoggedInCookie = Request.Cookies["IsUserLoggedIn"];
            if (isUserLoggedInCookie == null ||
                isUserLoggedInCookie.Value != "LoggedIn")
            {
                Page.Response.Redirect("LoginPage.aspx");
            }
        }
    }
}