using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.RegistrationForm
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.LiteralMessage.Text = "The page is valid!";
            }
            this.LiteralMessage.Visible = Page.IsValid;
        }

        protected void CheckBoxTermsRequired_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            e.IsValid = this.checkBoxTerms.Checked;
        }
    }
}