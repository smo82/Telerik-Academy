using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.LoginRedirect
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            HttpCookie isUserLoggedInCookie = Request.Cookies["IsUserLoggedIn"];
            if (isUserLoggedInCookie != null &&
                isUserLoggedInCookie.Value == "LoggedIn")
            {
                this.LiteralLoginInfoOutput.Text = "You are logged in!";
            }
            else
            {
                this.LiteralLoginInfoOutput.Text = "You are not logged in!";
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("IsUserLoggedIn", "LoggedIn");
            cookie.Expires = DateTime.Now.AddMinutes(1);

            Response.Cookies.Add(cookie);
        }
    }
}