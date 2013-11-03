using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.UserIp
{
    public partial class UserData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LiteralOutput.Text = "<strong>Browser type:</strong> " + Request.Browser.Type + "<br/>";

            string userIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(userIpAddress))
            {
                userIpAddress = Request.ServerVariables["REMOTE_ADDR"];
            }

            string userIpNumbersOnly = userIpAddress.Replace(":", "").Trim();

            if (userIpNumbersOnly == "1")
            {
                userIpAddress = "localhost";
            }

            this.LiteralOutput.Text += "<strong>UserIp:</strong> " + userIpAddress;
        }
    }
}