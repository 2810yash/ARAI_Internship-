using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                splWorkPermit_list();
            }

            if (IsPostBack)
            {
                int numberOfWorkers;
                if (int.TryParse(numWorkers.Text, out numberOfWorkers))
                {
                    CreateWorkerTable(numberOfWorkers);
                }
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

        protected void special_license_CheckedChanged(object sender, EventArgs e) 
        {
            spl_Licence.Visible = special_license_yes.Checked;
        }
        protected void WPcheckBox_Load(object sender, EventArgs e) { }

        protected void CreateWorkerTable(int numberOfWorkers)
        {
            workers.Controls.Clear();
            Table table = new Table();
            table.CssClass = "table table-bordered";

            TableRow tableFirstRow = new TableRow();
            string[] headerText = { "Sr. No.", "Name of Workers", "AGE", "Mask", "Safety Shoes/ Gum Boots", "Jackets/ Aprons", "Gloves", "Ear plug/ muffs", "Belt/ Harness", "Helmet", "Remarks" };
            for (int i = 0; i < headerText.Length; i++)
            {
                TableCell cell = new TableCell();
                cell.Text = headerText[i];
                tableFirstRow.Cells.Add(cell);
            }
            table.Rows.Add(tableFirstRow);

            for (int i = 0; i < numberOfWorkers; i++)
            {
                TableRow row = new TableRow();

                TableCell srNoCell = new TableCell();
                srNoCell.Text = (i + 1).ToString();
                row.Cells.Add(srNoCell);

                TableCell nameCell = new TableCell();
                nameCell.Controls.Add(new TextBox { ID = "txtName_" + i });
                row.Cells.Add(nameCell);

                TableCell ageCell = new TableCell();
                TextBox ageTextBox = new TextBox { ID = "txtAge_" + i };
                ageCell.Controls.Add(ageTextBox);
                row.Cells.Add(ageCell);

                RegularExpressionValidator ageValidator = new RegularExpressionValidator();
                ageValidator.ControlToValidate = ageTextBox.ID;
                ageValidator.ValidationExpression = @"\d+";
                ageValidator.ErrorMessage = "Please enter a numeric value for Age.";
                ageValidator.CssClass = "text-danger";
                ageCell.Controls.Add(ageValidator);

                TableCell maskCell = new TableCell();
                maskCell.Controls.Add(new CheckBox { ID = "chkMask_" + i, Checked = true });
                row.Cells.Add(maskCell);

                TableCell safetyShoesCell = new TableCell();
                safetyShoesCell.Controls.Add(new CheckBox { ID = "chkSafetyShoes_" + i, Checked = true });
                row.Cells.Add(safetyShoesCell);

                TableCell jacketsCell = new TableCell();
                jacketsCell.Controls.Add(new CheckBox { ID = "chkJackets_" + i, Checked = true });
                row.Cells.Add(jacketsCell);

                TableCell glovesCell = new TableCell();
                glovesCell.Controls.Add(new CheckBox { ID = "chkGloves_" + i, Checked = true });
                row.Cells.Add(glovesCell);

                TableCell earPlugsCell = new TableCell();
                earPlugsCell.Controls.Add(new CheckBox { ID = "chkEarPlugs_" + i, Checked = true });
                row.Cells.Add(earPlugsCell);

                TableCell beltCell = new TableCell();
                beltCell.Controls.Add(new CheckBox { ID = "chkBelt_" + i, Checked = true });
                row.Cells.Add(beltCell);

                TableCell helmetCell = new TableCell();
                helmetCell.Controls.Add(new CheckBox { ID = "chkHelmet_" + i, Checked = true });
                row.Cells.Add(helmetCell);

                TableCell remarksCell = new TableCell();
                remarksCell.Controls.Add(new TextBox { ID = "txtRemarks_" + i });
                row.Cells.Add(remarksCell);

                table.Rows.Add(row);
            }

            workers.Controls.Add(table);
        }

        protected void confirm_Click(object sender, EventArgs e)
        {
            int numberOfWorkers;
            if (int.TryParse(numWorkers.Text, out numberOfWorkers))
            {
                CreateWorkerTable(numberOfWorkers);
            }
        }

        protected void SubmitFrom(object sender, EventArgs e)
        {
            // Obtain values from the permit form
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
            string check1Txt = "";
            string check2Txt = "";
            string check3Txt = "";
            string check4Txt = "";
            string check5Txt = "";
            string check6Txt = "";
            string check7Txt = "";
            string check8Txt = "";
            string selectedWorkPer = "";
            //CheckBox bottons
            if (check1.Checked)
            {
                check1Txt = check1.Text;
            }if (check2.Checked)
            {
                check2Txt = check2.Text;
            }if (check3.Checked)
            {
                check3Txt = check3.Text;
            }if (check4.Checked)
            {
                check4Txt = check4.Text;
            }if (check5.Checked)
            {
                check5Txt = check5.Text;
            }if (check6.Checked)
            {
                check6Txt = check6.Text;
            }if (check7.Checked)
            {
                check7Txt = check7.Text;
            }if (check8.Checked)
            {
                check8Txt = check8.Text;
            }
            selectedWorkPer = "|" + check1Txt + "|" + check2Txt + "|" + check3Txt + "|" + check4Txt + "|" + check5Txt + "|" + check6Txt + "|" + check7Txt + "|" + check8Txt + "|";

            try
            {
                string permitID;
                int result = 0;
                // Insert permit details
                using (SqlConnection con = new SqlConnection(Main_con))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_workPermit_tbl", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Add parameters for permit details
                        cmd.Parameters.AddWithValue("@SiteName", siteName);
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
                        cmd.Parameters.AddWithValue("@workPermits", selectedWorkPer);

                        con.Open();
                        // Execute the command and get the result
                        result = cmd.ExecuteNonQuery();

                        // If the permit details insertion was successful
                        if (result > 0)
                        {
                            permitID = permitNumber;

                            // Insert worker details for each worker
                            for (int i = 0; i < workerNum; i++)
                            {
                                // Obtain worker details from the form
                                TextBox txtName = (TextBox)workers.FindControl("txtName_" + i);
                                TextBox txtAge = (TextBox)workers.FindControl("txtAge_" + i);

                                if (txtName == null || txtAge == null)
                                {
                                    Response.Write($"<script>console.log('Worker details control not found: txtName_{i}, txtAge_{i}');</script>");
                                    continue; // Skip this iteration if controls are not found
                                }

                                String workerName = txtName.Text;
                                int workerAge = 0;
                                if (!int.TryParse(txtAge.Text, out workerAge))
                                {
                                    Response.Write($"<script>console.log('Invalid age input for worker {i + 1}');</script>");
                                    continue; // Skip this iteration if age is not a valid integer
                                }

                                // Insert worker details using the stored procedure
                                using (SqlCommand cmdWorker = new SqlCommand("InsertWorkerDetails", con))
                                {
                                    cmdWorker.CommandType = CommandType.StoredProcedure;
                                    // Add parameters for worker details
                                    cmdWorker.Parameters.AddWithValue("@PermitID", permitID);
                                    cmdWorker.Parameters.AddWithValue("@WorkerName", workerName);
                                    cmdWorker.Parameters.AddWithValue("@WorkerAge", workerAge);
                                    // Add other worker details parameters similarly...

                                    // Execute the command to insert worker details
                                    result = cmdWorker.ExecuteNonQuery();
                                }
                            }

                            // If worker details insertion was successful
                            if (result > 0)
                            {
                                // Inform the user that data was added successfully
                                Response.Write("<script>alert('Data added Successfully.');</script>");
                                // Attempt to send email
                                try
                                {
                                    sendEmail(permitNumber);
                                }
                                catch (Exception ex)
                                {
                                    Response.Write("<script>alert('Error sending email: ' + ex.Message);console.log('" + ex.Message + "')</script>");
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Data updatation UnSuccessfully. Try Again');</script>");
                            }
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
                Response.Write($"<script>alert('Exception: {ex.Message}');</script>");
            }
        }

        protected PermitDetails GetPermitDetailsByNumber(string permitNumber)
        {
            PermitDetails permitDetails = null;
            using (SqlConnection con = new SqlConnection(Main_con))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM permit_details_tbl WHERE PermitNumber = @PermitNumber", con))
                {
                    cmd.Parameters.AddWithValue("@PermitNumber", permitNumber);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            permitDetails = new PermitDetails
                            {
                                SiteName = reader["SiteName"].ToString(),
                                PermitNumber = reader["PermitNumber"].ToString(),
                                DateofIssue = reader["DateofIssue"].ToString(),
                                PermitValidFrom = reader["PermitValidFrom"].ToString(),
                                PermitValidTill = reader["PermitValidTill"].ToString(),
                                SpecialLicense = reader["SpecialLicense"].ToString(),
                                SpecialLicenseType = reader["SpecialLicenseType"].ToString(),
                                InsuranceNo = reader["InsuranceNo"].ToString(),
                                InsuranceValidity = reader["InsuranceValidity"].ToString(),
                                AgencyName = reader["AgencyName"].ToString(),
                                WorkerNo = reader["WorkerNo"].ToString(),
                                ContractorName = reader["ContractorName"].ToString(),
                                ContractorNo = reader["ContractorNo"].ToString(),
                                EngineerName = reader["EngineerName"].ToString(),
                                EngineerNo = reader["EngineerNo"].ToString(),
                                Description = reader["Description"].ToString(),
                                Location = reader["Location"].ToString(),
                                workPermits = reader["workPermits"].ToString()
                            };

                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>console.log('Error reading from database: " + ex.Message + "');</script>");
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }
            return permitDetails;
        }
        protected void sendEmail(string permitNumber)
        {
            PermitDetails permitDetails = GetPermitDetailsByNumber(permitNumber);

            if (permitDetails != null)
            {
                string from = "yash2810203@gmail.com";
                string to = "yash2810203@gmail.com";
                try
                {
                    using (MailMessage mail = new MailMessage(from, to))
                    {
                        mail.Subject = "New Work Permit Created";

                        string body = $@"
                            <div class='card'>
                                <div>
                                    <h3>Permit Details</h3>
                                    <h6 style='color:gray;'>{permitDetails.SiteName}</h6>
                                    <h6 style='color:gray;'><b>Date of Issue: </b>{permitDetails.DateofIssue:dd-MM-yyyy}</h6>
                                </div>
                                <div class='card-body'>
                                    <h5 class='card-title'>
                                        <strong>Permit Number:</strong> {permitDetails.PermitNumber}
                                    </h5>
                                    <p class='card-text d-block'>
                                        <table class='table table-bordered' style='width: 100%;'>
                                            <tr>
                                                <td><p><strong>Permit Valid From:</strong> {permitDetails.PermitValidFrom:dd-MM-yyyy}</p></td>
                                                <td><p><strong>Permit Valid Till:</strong> {permitDetails.PermitValidTill:dd-MM-yyyy}</p></td>
                                            </tr>
                                            <tr>
                                                <td><p><strong>Special License:</strong> {permitDetails.SpecialLicense}</p></td>
                                                <td><p><strong>Special License Type:</strong> {permitDetails.SpecialLicenseType}</p></td>
                                            </tr>
                                            <tr>
                                                <td><p><strong>ESI/Insurance No:</strong> {permitDetails.InsuranceNo}</p></td>
                                                <td><p><strong>ESI/Insurance Validity:</strong> {permitDetails.InsuranceValidity:dd-MM-yyyy}</p></td>
                                            </tr>
                                            <tr>
                                                <td><p><strong>Name of Vendor or Contractor Firm/Agency:</strong> {permitDetails.AgencyName}</p></td>
                                                <td><p><strong>Number of workers:</strong> {permitDetails.WorkerNo}</p></td>
                                            </tr>
                                            <tr>
                                                <td><p><strong>Worker Details:</strong> permitDetails.WorkerDetails</p></td>
                                            </tr>
                                            <tr>
                                                <td><p><strong>Name of Vendor/Contractor Supervisor:</strong> {permitDetails.ContractorName}</p></td>
                                                <td><p><strong>Contact Number (Contractor):</strong> {permitDetails.ContractorNo}</p></td>
                                            </tr>
                                            <tr>
                                                <td><p><strong>ARAI Engineer:</strong> {permitDetails.EngineerName}</p></td>
                                                <td><p><strong>Contact Number (Engineer):</strong> {permitDetails.EngineerNo}</p></td>
                                            </tr>
                                            <tr>
                                                <td><p><strong>Brief Description of Work:</strong> {permitDetails.Description}</p></td>
                                                <td><p><strong>Location of Work:</strong> {permitDetails.Location}</p></td>
                                            </tr>
                                            <tr>
                                                <td>WorkPermits selected: {permitDetails.workPermits}</td>
                                            </tr>
                                        </table>
                                    </p>
                                </div>
                            </div>";

                        mail.Body = body;
                        mail.IsBodyHtml = true;

                        SmtpClient smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            EnableSsl = true,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(from, "ohfm hsdv qgxq vmej"),
                            Port = 587
                        };

                        smtp.Send(mail);

                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Message has been sent successfully.');", true);
                    }
                }
                catch (SmtpException smtpEx)
                {
                    Response.Write($"<script>alert('SMTP Exception: {smtpEx.Message}');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('General Exception: {ex.Message}');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Permit details not found.');</script>");
            }
        }

    }
}