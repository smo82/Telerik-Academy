using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.UserInputInSession
{
    public partial class UserInput : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["UserInput"] == null)
            {
                Session["UserInput"] = new List<string>();
            }

            this.LiteralOutput.Text = Server.HtmlEncode(string.Join(" ", (Session["UserInput"] as List<string>).ToArray()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSendInput_Click(object sender, EventArgs e)
        {
            (Session["UserInput"] as List<string>).Add(this.TextBoxUserInput.Text);
        }
    }
}