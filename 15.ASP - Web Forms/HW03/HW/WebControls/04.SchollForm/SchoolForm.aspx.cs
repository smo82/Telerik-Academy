using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.SchollForm
{
    public partial class SchoolForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmitForm_Click(object sender, EventArgs e)
        {
            Panel outputPanel = this.PanelOutput;

            AddPanelLabel(outputPanel, "First name: ", this.TextBoxFirstName.Text);
            AddPanelLabel(outputPanel, "Last name: ", this.TextBoxLastName.Text);
            AddPanelLabel(outputPanel, "Faculty number: ", this.TextBoxFacultyNumber.Text);
            AddPanelLabel(outputPanel, "University: ", this.DropDownListUniversity.SelectedValue);
            AddPanelLabel(outputPanel, "Specialty: ", this.DropDownListSpecialty.SelectedValue);

            outputPanel.Controls.Add(new LiteralControl("<br>"));
            AddPanelLabel(outputPanel, "Courses: ", string.Empty);
            foreach (int courseIndex in this.ListBoxCourses.GetSelectedIndices())
            {
                AddPanelLabel(outputPanel, string.Empty, this.ListBoxCourses.Items[courseIndex].Text);
            }
        }

        private void AddPanelLabel(Panel outputPanel, string labelLeadingText, string labelValueText)
        {
            Label label = new Label()
            {
                Text = labelLeadingText + Server.HtmlEncode(labelValueText)
            };

            outputPanel.Controls.Add(label);
            outputPanel.Controls.Add(new LiteralControl("<br>"));
        }
    }
}