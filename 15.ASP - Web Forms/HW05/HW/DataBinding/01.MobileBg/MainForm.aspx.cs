using _01.MobileBg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.MobileBg
{
    public partial class MainForm : System.Web.UI.Page
    {
        static List<Producer> producers;
        static List<Extra> extras;
        static List<string> engineTypes;

        public MainForm()
        {
            producers = new List<Producer>(){
                    new Producer(){
                        Id = 1,
                        Name = "VW",
                        Models = new List<Model>(){
                            new Model(){Name = "Passat"},
                            new Model(){Name = "Golf"},
                            new Model(){Name = "Sharan"},
                        }
                    },
                    new Producer(){
                        Id = 2,
                        Name = "BMW",
                        Models = new List<Model>(){
                            new Model(){Name = "M3"},
                            new Model(){Name = "M5"},
                            new Model(){Name = "M7"},
                        }
                    },
                };

            extras = new List<Extra>(){
                new Extra{ Name = "Vertical liftoff" },
                new Extra{ Name = "Sonic cannon" },
                new Extra{ Name = "Nitro" },
            };

            engineTypes = new List<string>{ "Diesel", "Gas", "Electrical", "Hybrid" };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Bind producers
                this.DropDownProducers.DataSource = producers;

                // Bind models
                this.DropDownModels.DataSource = producers[0].Models;

                // Bind extras
                this.CheckBoxListExtras.DataSource = extras;

                // Bind engine types
                this.RadioButtonListEngineType.DataSource = engineTypes;
                Page.DataBind();
            }

        }

        protected void DropDownProducers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int producerId = int.Parse(this.DropDownProducers.SelectedValue);

            List<Model> models = producers.Where(p => p.Id == producerId).Select(p => p.Models).FirstOrDefault();
            this.DropDownModels.DataSource = models;

            Page.DataBind();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            List<string> selectedExtras = this.CheckBoxListExtras.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToList();

            string selectedExtrasAsString = String.Join(", ", selectedExtras);

            var selection = new
            {
                Producer = this.DropDownProducers.SelectedItem.Text,
                Model = this.DropDownModels.SelectedItem.Text,
                Extras = selectedExtrasAsString,
                EngineType = this.RadioButtonListEngineType.SelectedValue
            };

            this.DetailsViewSelection.DataSource = new List<object>{ selection };
            
            Page.DataBind();
        }        
    }
}