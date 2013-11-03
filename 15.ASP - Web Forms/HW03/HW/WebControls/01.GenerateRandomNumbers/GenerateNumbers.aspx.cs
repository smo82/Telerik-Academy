using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.GenerateRandomNumbers
{
    public partial class GenerateNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int number;
            if (!int.TryParse(this.TextBoxLowerBorder.Value, out number))
            {
                this.TextBoxLowerBorder.Value = "0";
            }

            if (!int.TryParse(this.TextBoxUpperBorder.Value, out number))
            {
                this.TextBoxUpperBorder.Value = "0";
            }
        }

        protected void ButtonGenerateNumbers_Click(object sender, EventArgs e)
        {
            var lowerBorder = 0;
            if (!int.TryParse(this.TextBoxLowerBorder.Value, out lowerBorder))
            {
                lowerBorder = 0;
            };

            var upperBorder = 0;
            if (!int.TryParse(this.TextBoxUpperBorder.Value, out upperBorder))
            {
                upperBorder = 0;
            };

            for (int i = lowerBorder; i <= upperBorder; i++)
            {
                this.PanelWithNumbers.Controls.Add(new Literal() { Text = i + "<br />" });
            }
        }
    }
}