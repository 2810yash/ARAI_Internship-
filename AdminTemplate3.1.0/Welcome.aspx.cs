using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;

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
                WorkPermit_list();
                splWorkPermit_list();
                ViewState["AppendedValues"] = "";
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
            araiEng.DataBind();
            araiEng.Items.Insert(0, new ListItem("-- Select Engineer Name --", "0"));
        }
        protected void WorkPermit_list()
        {
            SqlConnection sqlcon = new SqlConnection(Main_con);
            sqlcon.Open();
            SqlCommand sql_command = new SqlCommand("SELECT Work_Permit FROM [dbo].[JobSafetyAssessment_TBL]", sqlcon);
            sql_command.CommandType = CommandType.Text;
            workPermit.DataSource = sql_command.ExecuteReader();
            workPermit.DataTextField = "Work_Permit";
            workPermit.DataBind();
            workPermit.Items.Insert(0, new ListItem("-- Select Work Permit --", "0"));
        }
        protected void splWorkPermit_list()
        {
            SqlConnection sqlcon = new SqlConnection(Main_con);
            sqlcon.Open();
            SqlCommand sql_command = new SqlCommand("SELECT Work_Permit FROM [dbo].[JobSafetyAssessment_TBL] WHERE Spl_License=1", sqlcon);
            sql_command.CommandType = CommandType.Text;
            spl_Licence.DataSource = sql_command.ExecuteReader();
            spl_Licence.DataTextField = "Work_Permit";
            spl_Licence.DataBind();
            spl_Licence.Items.Insert(0, new ListItem("-- Select Special Work Permit --", "0"));
        }
        protected void special_license_CheckedChanged(object sender, EventArgs e) { }
        protected void confirm_Click(object sender, EventArgs e)
        {
            // Parse the number of workers entered in the TextBox
            int numberOfWorkers;
            if (int.TryParse(numWorkers.Text, out numberOfWorkers))
            {
                // Clear any previous content in the workers div
                workers.Controls.Clear();

                // Create a new table
                Table table = new Table();
                table.CssClass = "table table-bordered"; // Optionally, you can set CSS class for the table

                // Create the first row with headers
                TableRow tableFirstRow = new TableRow();
                string[] headerText = { "Sr. No.", "Name of Workers", "AGE", "Mask", "Safety Shoes/ Gum Boots", "Jackets/ Aprons", "Gloves", "Ear plug/ muffs", "Belt/ Harness", "Remarks" };
                for (int i = 0; i < headerText.Length; i++)
                {
                    TableCell cell = new TableCell();
                    cell.Text = headerText[i];
                    tableFirstRow.Cells.Add(cell);
                }
                table.Rows.Add(tableFirstRow);

                // Create table rows and cells based on the number of workers
                for (int i = 0; i < numberOfWorkers; i++)
                {
                    TableRow row = new TableRow();

                    // Add Sr. No. column with sequential numbers
                    TableCell srNoCell = new TableCell();
                    srNoCell.Text = (i + 1).ToString();
                    row.Cells.Add(srNoCell);

                    // Add TextBox for Name of Workers column
                    TableCell nameCell = new TableCell();
                    nameCell.Controls.Add(new TextBox { ID = "txtName_" + i }); // Assign a unique ID to each TextBox
                    row.Cells.Add(nameCell);

                    // Add a TextBox for Age column
                    TableCell ageCell = new TableCell();
                    TextBox ageTextBox = new TextBox { ID = "txtAge_" + i };
                    ageCell.Controls.Add(ageTextBox);
                    row.Cells.Add(ageCell);

                    // Add RegularExpressionValidator for Age column
                    RegularExpressionValidator ageValidator = new RegularExpressionValidator();
                    ageValidator.ControlToValidate = ageTextBox.ID;
                    ageValidator.ValidationExpression = @"\d+"; // Regular expression to match digits only
                    ageValidator.ErrorMessage = "Please enter a numeric value for Age.";
                    ageValidator.CssClass = "text-danger"; // Optional: Add CSS class for error messages
                    ageCell.Controls.Add(ageValidator);

                    // Add CheckBox for Mask column
                    TableCell maskCell = new TableCell();
                    maskCell.Controls.Add(new CheckBox { ID = "chkMask_" + i, Checked = true }); // Assign a unique ID to each CheckBox
                    row.Cells.Add(maskCell);

                    // Add CheckBox for Safety Shoes/Gum Boots column
                    TableCell safetyShoesCell = new TableCell();
                    safetyShoesCell.Controls.Add(new CheckBox { ID = "chkSafetyShoes_" + i, Checked = true }); // Assign a unique ID to each CheckBox
                    row.Cells.Add(safetyShoesCell);

                    // Add CheckBox for Jackets/Aprons column
                    TableCell jacketsCell = new TableCell();
                    jacketsCell.Controls.Add(new CheckBox { ID = "chkJackets_" + i, Checked = true }); // Assign a unique ID to each CheckBox
                    row.Cells.Add(jacketsCell);

                    // Add CheckBox for Gloves column
                    TableCell glovesCell = new TableCell();
                    glovesCell.Controls.Add(new CheckBox { ID = "chkGloves_" + i, Checked = true }); // Assign a unique ID to each CheckBox
                    row.Cells.Add(glovesCell);

                    // Add CheckBox for Ear plug/muffs column
                    TableCell earPlugsCell = new TableCell();
                    earPlugsCell.Controls.Add(new CheckBox { ID = "chkEarPlugs_" + i, Checked = true }); // Assign a unique ID to each CheckBox
                    row.Cells.Add(earPlugsCell);

                    // Add CheckBox for Belt/Harness column
                    TableCell beltCell = new TableCell();
                    beltCell.Controls.Add(new CheckBox { ID = "chkBelt_" + i, Checked = true }); // Assign a unique ID to each CheckBox
                    row.Cells.Add(beltCell);

                    // Add TextBox for Remarks column
                    TableCell remarksCell = new TableCell();
                    remarksCell.Controls.Add(new TextBox { ID = "txtRemarks_" + i }); // Assign a unique ID to each TextBox
                    row.Cells.Add(remarksCell);

                    table.Rows.Add(row);
                }

                // Add the table to the workers div
                workers.Controls.Add(table);
            }
            else
            {
                // Display a message or take appropriate action if the input is invalid
                // For example: Response.Write("Invalid input for the number of workers.");
            }
        }
        protected void addWorkPermit_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected work permit value
                string selectedWorkPermit = workPermit.SelectedValue;

                // Retrieve the corresponding hazard information from the database
                using (SqlConnection sqlcon = new SqlConnection(Main_con))
                {
                    sqlcon.Open();
                    string query = "SELECT * FROM Hazard_TBL WHERE Hazard_No IN (SELECT Hazard_No FROM JobSafetyAssessment_TBL WHERE Work_Permit = @WorkPermit)";
                    using (SqlCommand command = new SqlCommand(query, sqlcon))
                    {
                        command.Parameters.AddWithValue("@WorkPermit", selectedWorkPermit);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Clear existing content in the panel
                           // Panel1.Controls.Clear();

                            // Create a new table to display the hazard information
                            Table hazardTable = new Table();
                            hazardTable.CssClass = "table table-decoration-none";

                            // Create table header row
                            TableRow headerRow = new TableRow();
                            headerRow.Cells.Add(new TableCell { Text = "Hazard_No" });
                            headerRow.Cells.Add(new TableCell { Text = "Status" });
                            hazardTable.Rows.Add(headerRow);

                            // Add hazard information rows
                            while (reader.Read())
                            {
                                TableRow hazardRow = new TableRow();
                                hazardRow.Cells.Add(new TableCell { Text = reader["Hazard_No"].ToString() });
                                // You can add more cells for other hazard attributes if needed
                                hazardRow.Cells.Add(new TableCell { Text = reader["Fire"].ToString() }); // Replace "Status Value" with the actual value from the database
                                hazardTable.Rows.Add(hazardRow);
                            }

                            // Add the table to the panel
                            Panel1.Controls.Add(hazardTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Response.Write("An error occurred: " + ex.Message);
            }
        }

        //protected void addWorkPermit_Click(object sender, EventArgs e)
        //{
        //    string selectedVal = workPermit.SelectedValue;

        //    // Retrieve previously appended values from ViewState
        //    string appendedValues = ViewState["AppendedValues"].ToString();

        //    // Append the new selected value
        //    appendedValues += selectedVal + "<br />";

        //    // Update the ViewState with the new appended values
        //    ViewState["AppendedValues"] = appendedValues;

        //    // Update the Panel with the appended values
        //    Panel1.Controls.Clear(); // Clear existing controls
        //    Panel1.Controls.Add(new LiteralControl(appendedValues));
        //}
        protected void SubmitFrom(object sender, EventArgs e)
        {
            String siteName = site.SelectedValue;
            String permitNumber = permitNum.Text.Trim();
            DateTime dateOfIssue = Convert.ToDateTime(issueDate.Text.Trim());
            DateTime validFrom = Convert.ToDateTime(perValidFrom.Text.Trim());
            DateTime validTill = Convert.ToDateTime(perValidTill.Text.Trim());
            bool hasSpecialLicenseYES = special_license_yes.Checked;
            String splWork = "NO SPL Licence";
            if (hasSpecialLicenseYES == true)
            {
                splWork = spl_Licence.SelectedValue;
            }
            bool hasSpecialLicenseNO = special_license_no.Checked;
            String esiNumber = esiNUM.Text.Trim();
            DateTime esiValidity = Convert.ToDateTime(esiVali.Text.Trim());
            String contractorName = contractorNam.Text.Trim();
            int workerNum = Convert.ToInt32(numWorkers.Text.Trim());
            String supervisorName = supervisorNam.Text.Trim();
            String supervisorContact = supervisorContactNUM.Text.Trim();
            String engineerName = araiEng.SelectedValue;
            String engiContact = engiContactNUM.Text.Trim();
            String workDescription = describeWork.Text.Trim();
            String workLocation = locateWork.Text.Trim();

            try
            {
                int result = 0;
                using (SqlConnection con = new SqlConnection(Main_con))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_workPermit_tbl", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PermitNumber", permitNumber);
                        cmd.Parameters.AddWithValue("@DateOfIssue", dateOfIssue);
                        cmd.Parameters.AddWithValue("@PermitValidFrom", validFrom);
                        cmd.Parameters.AddWithValue("@PermitValidTill", validTill);
                        cmd.Parameters.AddWithValue("@SpecialLicense", hasSpecialLicenseYES);
                        cmd.Parameters.AddWithValue("@SplLicenseType", splWork);
                        cmd.Parameters.AddWithValue("@ESIInsuranceNo", esiNumber);
                        cmd.Parameters.AddWithValue("@ESIValidity", esiValidity);
                        cmd.Parameters.AddWithValue("@NameofAgency", contractorName);
                        cmd.Parameters.AddWithValue("@NumOfWorkers", workerNum);
                        cmd.Parameters.AddWithValue("@NameofContractor", supervisorName);
                        cmd.Parameters.AddWithValue("@ContractorContact", supervisorContact);
                        cmd.Parameters.AddWithValue("@ARAIEngineer", engineerName);
                        cmd.Parameters.AddWithValue("@EngineerContact", engiContact);
                        cmd.Parameters.AddWithValue("@DescofWork", workDescription);
                        cmd.Parameters.AddWithValue("@Location", workLocation);
                        con.Open();
                        result = cmd.ExecuteNonQuery();
                        con.Close();
                        if (result > 0)
                        {
                            Response.Write("<script>alert('Data added Successfully.');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Data updatation UnSuccessfully. Try Again');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            try {
                sendEmail();
            } catch (Exception ex) {
                Response.Write(ex.Message);
            }
        }

        protected void sendEmail()
        {

            using (SqlConnection con = new SqlConnection(Main_con))
            {
                string query = "select ";
                SqlCommand fetchmail = new SqlCommand();
            }
            string from = "adityaraut1003@gmail.com"; 
            string to = "adityaraut216@gmail.com";
            using (MailMessage mail = new MailMessage(from, to))
            {
                mail.Subject = "New Work Permit Created";
                mail.Body = "Check out the new work permit created! \nAt: " + DateTime.Today.TimeOfDay;
                //if (fileUploader.HasFile)
                //{
                //    string fileName = Path.GetFileName(fileUploader.PostedFile.FileName);
                //    mail.Attachments.Add(new Attachment(fileUploader.PostedFile.InputStream, fileName));
                //}
                mail.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential(from, "jgcb dmvu boae jfhh");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = 587;
                smtp.Send(mail);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Message has been sent successfully.');", true);
            }
        }
    }
}