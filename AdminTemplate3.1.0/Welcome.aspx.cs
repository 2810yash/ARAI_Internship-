using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string labelText = checkBox.Text;

            // Get the list container
            ListBox listContainer = (ListBox)FindControl("listContainer");

            if (listContainer != null)
            {
                if (checkBox.Checked)
                {
                    // Add the checkbox text to the list container
                    listContainer.Items.Add(new ListItem(labelText));
                }
                else
                {
                    // Remove the checkbox text from the list container if it exists
                    ListItem itemToRemove = listContainer.Items.FindByText(labelText);
                    if (itemToRemove != null)
                    {
                        listContainer.Items.Remove(itemToRemove);
                    }
                }
            }
        }
    }
}