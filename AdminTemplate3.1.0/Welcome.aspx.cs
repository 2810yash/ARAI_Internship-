using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if checkbox was previously checked and item needs to be added on load (optional)
            if (!IsPostBack)
            {
                //if (/* Your logic to check if item should be pre-selected */) 
                //{
                //  CheckBox1.Checked = true;
                //  AddListItem();
                //}
            }
        }

        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var selectedCheckBox = (CheckBox)sender;
            var selectedWorkText = FindControl("selectedWorkText") as HtmlGenericControl;

            if (selectedWorkText != null)
            {
                if (selectedCheckBox.Checked)
                {
                    selectedWorkText.InnerHtml = selectedCheckBox.Text;
                }
                else
                {
                    selectedWorkText.InnerHtml = "";
                }
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                AddListItem();
            }
            else
            {
                RemoveListItem();
            }
        }

        private void AddListItem()
        {
            var listItem = new HtmlGenericControl("li");
            listItem.ID = "pr1";
            listItem.Attributes["class"] = "form-check-label col-sm-9 m-lg-1 border-bottom-0";
            listItem.InnerHtml = "Remove Flammable and explosive materials.";
            CheckBox1.Text = "Remove Flammable and explosive materials";
            var list = GetUlElement(); // Dynamically find the ul element
            if (list != null)
            {
                list.Controls.Add(listItem);
            }
        }

        private void RemoveListItem()
        {
            var list = GetUlElement(); // Dynamically find the ul element
            if (list != null)
            {
                var itemToRemove = list.FindControl("pr1") as HtmlGenericControl;
                if (itemToRemove != null)
                {
                    list.Controls.Remove(itemToRemove);
                }
            }
        }

        private HtmlGenericControl GetUlElement()
        {
            // Search for the ul element within dynamicList (or any other container)
            foreach (Control control in dynamicList.Controls)
            {
                if (control is HtmlGenericControl && control.TagName == "ul")
                {
                    return (HtmlGenericControl)control;
                }
            }
            return null;
        }
    }
}
