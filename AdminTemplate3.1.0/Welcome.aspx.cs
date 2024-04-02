using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AdminTemplate3._1._0
{
    public partial class Welcome : System.Web.UI.Page
    {
        string Main_con = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                arai_Engineer_list();
            }
        }

        protected void arai_Engineer_list()
        {
            SqlConnection sqlcon = new SqlConnection(Main_con);
            sqlcon.Open();
            SqlCommand sql_command = new SqlCommand("SELECT * FROM [dbo].[engineer_name_tbl]", sqlcon);
            sql_command.CommandType = CommandType.Text;
            araiEng.DataSource = sql_command.ExecuteReader();
            araiEng.DataTextField = "EngineerName";
            //araiEng.DataValueField = "DeptID";
            araiEng.DataBind();
            araiEng.Items.Insert(0, new ListItem("-- Select Engineer Name --", "0"));
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