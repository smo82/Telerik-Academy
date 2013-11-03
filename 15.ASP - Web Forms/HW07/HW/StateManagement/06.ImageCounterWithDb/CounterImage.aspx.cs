using ImageCounter.DataLayer;
using ImageCounter.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.ImageCounterWithDb
{
    public partial class CounterImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ImageCounterContext context = new ImageCounterContext())
            {
                if (context.Applications.Count() == 0)
                {
                    ApplicationData application = new ApplicationData()
                    {
                        NumberOfVisits = 0
                    };

                    context.Applications.Add(application);

                    context.SaveChanges();
                }

                ApplicationData singleApplication = context.Applications.FirstOrDefault();

                singleApplication.NumberOfVisits++;

                context.SaveChanges();

                Response.Clear();

                Bitmap generatedImage = new Bitmap(200, 50);
                using (generatedImage)
                {
                    Graphics gr = Graphics.FromImage(generatedImage);
                    using (gr)
                    {
                        gr.FillRectangle(Brushes.Green, 0, 0, 200, 50);
                        gr.DrawString(
                            singleApplication.NumberOfVisits.ToString(),
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
}