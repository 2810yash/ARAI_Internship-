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

        protected void submit_Click(object sender, EventArgs e)
        {
            // String permitNo = TextBox1.Text.Trim();
            // DateTime dateOfIssue = TextBox2.Text.Trim(); // DATE AND TIME
            // DateTime permitValidFrom =// TextBox3.Text.Trim();  // DATE AND TIME
            // DateTime permitValidTill =// TextBox4.Text.Trim();  // DATE AND TIME
            // bool splLicense = special_license_yes.Checked;
            // String splLicenseType = spl_Licence.SelectedValue;
            // String esiNum = TextBox5.Text.Trim();
            // DateTime esiValidity = ; // DATE AND TIME
            // String nameOfAgency = TextBox6.Text.Trim();
            // int numOfWorkes = TextBox7.Text.Trim(); //type conversion STRING TO INT
            // String nameOfContractor = TextBox8.Text.Trim();
            // String contractorContact = TextBox9.Text.Trim();
            // String araiEngineer = araiEng.SelectedValue;
            // String engineerContact = TextBox10.Text.Trim();
            // String descOfWork = TextBox11.Text.Trim();
            // String location = TextBox12.Text.Trim();

            // if ((permitValidTill - permitValidFrom).TotalDays > 15)
            // {
                // Response.Write("<script>alert('Please enter the valid permit dates between 15 days max')</script>");
                // TextBox3.Controls.Clear();
                // TextBox4.Controls.Clear();
            // } else
            // {
                // NewWorkPermit(permitNo, dateOfIssue, permitValidFrom, permitValidTill, splLicense, splLicenseType, esiNum, esiValidity, nameOfAgency, numOfWorkes, nameOfContractor, contractorContact, araiEngineer, engineerContact, descOfWork, location);
            // }
        }
        protected void NewWorkPermit(String permitNo, DateTime dateOfIssue, DateTime permitValidFrom, DateTime permitValidTill, bool splLicense, string splLicenseType, String esiNum, DateTime esiValidity, String nameofAgency, int numOfWorkers, String nameofContractor, String contractorContact, String araiEngg, String engineerContact, String descOfWork, String location)
        {
            //SqlConnection con = new SqlConnection(strconn2);
            try
            {
                int result = 0;
                using (SqlConnection con = new SqlConnection(Main_con))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_register_tbl", con))
                    {
                    }
                }
            }
            catch
            {

            }
        } 
    } 
}