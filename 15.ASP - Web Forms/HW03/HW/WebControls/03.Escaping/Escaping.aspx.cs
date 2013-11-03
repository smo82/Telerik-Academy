using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.Escaping
{
    public partial class Escaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonEscapeText_Click(object sender, EventArgs e)
        {
            string inputText = this.TextBoxInputText.Text;

            this.TextBoxEscapedText.Text = inputText;
            this.LabelEscapedText.Text = Server.HtmlEncode(inputText);
        }
    }
}