using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CacheProject
{
    public class CustomMenuDataItem
    {
        public string Text { get; set; }
        public string Url { get; set; }
    }

    public partial class CustomMenu : System.Web.UI.UserControl
    {
        public IEnumerable<CustomMenuDataItem> DataSource;

        public Color Color
        {
            get
            {
                return this.DataList_Inner.ForeColor;
            }
            set
            {
                this.DataList_Inner.ForeColor = value;
            }
        }

        public string FontName
        {
            get
            {
                return this.DataList_Inner.Font.Name;
            }
            set
            {
                this.DataList_Inner.Font.Name = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void DataBind()
        {
            this.DataList_Inner.DataSource = this.DataSource;
            this.DataList_Inner.DataBind();
            base.DataBind();
        }

        protected void DataList_Inner_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) ||
                (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                HyperLink hyperLinkItem = (HyperLink)e.Item.FindControl("DataList_HyperLinkItem");
                hyperLinkItem.ForeColor = this.Color;
                hyperLinkItem.Font.Name = this.FontName;
            }
        }
    }
}