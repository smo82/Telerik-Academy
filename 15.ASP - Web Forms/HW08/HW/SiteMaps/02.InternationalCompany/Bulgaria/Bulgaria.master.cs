using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.InternationalCompany
{
    public partial class BulgariaMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        /*
         * Please note that the same way the language specific content is done for the Nested master page
         * it can be done for every inner page (Home, About, Contacts)
         */
        protected void Page_PreRender(object sender, EventArgs e)
        {
            string language = "EN";

            if (HttpContext.Current.Session["language"] != null)
            {
                language = HttpContext.Current.Session["language"].ToString();
            }

            switch (language)
            {
                case "EN":
                    this.languageSpecificContent.Text = "English Content!";
                    break;
                case "BG":
                    this.languageSpecificContent.Text = "Bulgarian Content!";
                    break;
                default:
                    this.languageSpecificContent.Text = "Unsupperted language!";
                    break;
            }
        }
    }
}