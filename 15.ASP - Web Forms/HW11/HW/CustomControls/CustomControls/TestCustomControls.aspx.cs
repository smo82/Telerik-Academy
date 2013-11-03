using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomControls
{
    public partial class TestCustomControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<CustomMenuDataItem> data = new List<CustomMenuDataItem>()
            {
                new CustomMenuDataItem{
                    Text = "Telerik",
                    Url = "http://www.telerik.com/"
                },                
                new CustomMenuDataItem{
                    Text = "Telerik Academy",
                    Url = "http://www.telerikacademy.com/"
                },                
                new CustomMenuDataItem{
                    Text = "Google",
                    Url = "https://www.google.bg/"
                },                
                new CustomMenuDataItem{
                    Text = "Yahoo",
                    Url = "http://www.yahoo.com/"
                }
            };


            this.CustomMenu.Color = Color.FromName("Green");
            this.CustomMenu.FontName = "Fantasy";

            this.CustomMenu.DataSource = data;
            this.CustomMenu.DataBind();
        }
    }
}