using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05.ImageCounter
{
    public partial class CounterImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Application["Visits"] == null)
            {
                this.Application["Visits"] = 0;
            }

            this.Application["Visits"] = (int)this.Application["Visits"] + 1;

            Response.Clear();

            Bitmap generatedImage = new Bitmap(200, 50);
            using (generatedImage)
            {
                Graphics gr = Graphics.FromImage(generatedImage);
                using (gr)
                {
                    gr.FillRectangle(Brushes.Green, 0, 0, 200, 50);
                    gr.DrawString(
                        this.Application["Visits"].ToString(), 
                        new Font(FontFamily.GenericSansSerif, 18), 
                        Brushes.Black, 
                        new PointF(80, 10));

                    Response.ContentType = "image/gif";

                    generatedImage.Save(Response.OutputStream, ImageFormat.Gif);
                }
            }
        }
    }
}