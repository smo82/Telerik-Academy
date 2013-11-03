using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using World.Data;

namespace _01.World.Client
{
    public partial class WorldMainForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GridViewCountries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Country country = (Country)e.Row.DataItem;
                List<int> countryLanguageIds = country.Languages.Select(l => l.LanguageId).ToList<int>();

                ListBox listboxLanguages = e.Row.FindControl("ListBoxLanguages") as ListBox;

                foreach (ListItem item in listboxLanguages.Items)
                {
                    if (countryLanguageIds.Contains(int.Parse(item.Value)))
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        protected void GridViewCountries_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            using (WorldDbEntities context = new WorldDbEntities())
            {
                var gridRow = this.GridViewCountries.Rows[e.RowIndex];

                string countryId = this.GridViewCountries.DataKeys[e.RowIndex].Value.ToString();
                Country country = context.Countries.Find(countryId);

                ListBox listboxLanguages = gridRow.FindControl("ListBoxLanguages") as ListBox;
                foreach (ListItem item in listboxLanguages.Items)
                {
                    Language language = context.Languages.Find(int.Parse(item.Value));

                    if (item.Selected)
                    {
                        country.Languages.Add(language);
                    }
                    else
                    {
                        country.Languages.Remove(language);
                    }
                }

                context.SaveChanges();
            }
        }

        protected void GridViewCountries_PreRender(object sender, EventArgs e)
        {
            if (this.GridViewCountries.FooterRow != null)
            {
                TableCell insertFooterCell = this.GridViewCountries.FooterRow.Cells[1];
                this.GridViewCountries.FooterRow.Cells.RemoveAt(1);
                this.GridViewCountries.FooterRow.Cells.AddAt(0, insertFooterCell);
            }
        }

        protected void GridViewCountries_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                this.Page.Validate("CountryValidation");
                if (this.Page.IsValid == false)
                {
                    return;
                }

                using (WorldDbEntities context = new WorldDbEntities())
                {
                    TextBox insertCountryId = this.GridViewCountries.FooterRow.FindControl("InsertCountryId") as TextBox;
                    TextBox insertCountryName = this.GridViewCountries.FooterRow.FindControl("InsertCountryName") as TextBox;
                    TextBox insertLatitude = this.GridViewCountries.FooterRow.FindControl("InsertLatitude") as TextBox;
                    TextBox insertLongitude = this.GridViewCountries.FooterRow.FindControl("InsertLongitude") as TextBox;
                    TextBox insertSurfaceArea = this.GridViewCountries.FooterRow.FindControl("InsertSurfaceArea") as TextBox;
                    TextBox insertPopulation = this.GridViewCountries.FooterRow.FindControl("InsertPopulation") as TextBox;
                    DropDownList dropDownListContinentInsert = this.GridViewCountries.FooterRow.FindControl("DropDownListContinentInsert") as DropDownList;
                    ListBox listBoxLanguagesInsert = this.GridViewCountries.FooterRow.FindControl("ListBoxLanguagesInsert") as ListBox;

                    Country newCountry = new Country()
                    {
                        CountryId = insertCountryId.Text,
                        CountryName = insertCountryName.Text,
                        Latitude = double.Parse(insertLatitude.Text),
                        Longitude = double.Parse(insertLongitude.Text),
                        SurfaceArea = double.Parse(insertSurfaceArea.Text),
                        Population = int.Parse(insertPopulation.Text),
                        ContinentId = int.Parse(dropDownListContinentInsert.SelectedValue),
                    };

                    foreach (ListItem item in listBoxLanguagesInsert.Items)
                    {
                        if (item.Selected)
                        {
                            Language language = context.Languages.Find(int.Parse(item.Value));
                            newCountry.Languages.Add(language);
                        }
                    }

                    context.Countries.Add(newCountry);

                    context.SaveChanges();
                }

                this.GridViewCountries.DataBind();
            }
            else if (e.CommandName == "CancelNew")
            {
                this.GridViewCountries.DataBind();
            }
        }

        protected void GridViewCountries_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string countryId = e.Keys["CountryId"].ToString();
            
            using (WorldDbEntities context = new WorldDbEntities())
            {
                Country country = context.Countries.Find(countryId);
                List<Language> languages = country.Languages.ToList<Language>();
                foreach (var language in languages)
                {
                    country.Languages.Remove(language);
                }

                context.SaveChanges();
            }
        }

        protected void ValidatorContryIdTaken_ServerValidate(object source, ServerValidateEventArgs args)
        {
            using (WorldDbEntities context = new WorldDbEntities())
            {
                TextBox insertCountryId = this.GridViewCountries.FooterRow.FindControl("InsertCountryId") as TextBox;
                if (context.Countries.Find(insertCountryId.Text) != null)
                {
                    args.IsValid = false;
                    return;
                }

                args.IsValid = true;
                return;
            }
        }

        protected void ListViewCities_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            this.Page.Validate("CityValidation");
            if (this.Page.IsValid == false)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}