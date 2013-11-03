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
        
        protected void ButtonValidateLogin_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupLogin");
            if (Page.IsValid)
            {
                this.LableLoginValidMessage.Text = "The login information is valid!";
            }
            this.LableLoginValidMessage.Visible = Page.IsValid;
        }

        protected void ButtonValidatePersonalInformation_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupPersonalInformation");
            if (Page.IsValid)
            {
                this.LablePersonalInformationValidMessage.Text = "The personal information is valid!";
            }
            this.LablePersonalInformationValidMessage.Visible = Page.IsValid;
        }

        protected void ButtonValidateAddressInformation_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupAddressInformation");
            if (Page.IsValid)
            {
                this.LableAddressInformationValidMessage.Text = "The address information is valid!";
            }
            this.LableAddressInformationValidMessage.Visible = Page.IsValid;
        }    
               
        protected void CheckBoxTermsRequired_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            e.IsValid = this.checkBoxTerms.Checked;
        }
    }
}