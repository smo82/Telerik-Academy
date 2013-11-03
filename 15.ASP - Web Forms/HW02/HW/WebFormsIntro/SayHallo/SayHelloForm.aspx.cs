using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayHallo
{
    public partial class SayHelloForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSayHallo_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.TextBoxName.Text))
            {
                this.LiteralSayHallo.Text = String.Format("Hello {0}!", this.TextBoxName.Text);
            }
            else
            {
                this.LiteralSayHallo.Text = "I don't know who you are!";
            }
        }
    }
}