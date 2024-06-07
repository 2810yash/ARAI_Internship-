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
        public string deptName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"].Equals("admin"))
            {
                Response.Redirect("Homepage.aspx");
            }

            if (Session["deptName"] != null)
            {
                deptName = Session["deptName"].ToString();
            }

            if (!IsPostBack)
            {
                arai_Engineer_list();
                splWorkPermit_list();
            }

            if (!Page.IsPostBack)
            {
                SetInitialRow();
            }

            if (IsPostBack)
            {
                int numberOfWorkers;
                if (int.TryParse(numWorkers.Text, out numberOfWorkers))
                {
                    //CreateWorkerTable(numberOfWorkers);
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
            SqlCommand sql_command = new SqlCommand("SELECT Work_Permit FROM [dbo].[WorkPermit] WHERE Spl_License=1", sqlcon);
            sql_command.CommandType = CommandType.Text;
            spl_Licence.DataSource = sql_command.ExecuteReader();
            spl_Licence.DataTextField = "Work_Permit";
            spl_Licence.DataBind();
            spl_Licence.Items.Insert(0, new ListItem("-- Select Special Work Permit --", "0"));
        }

        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(int)));
            dt.Columns.Add(new DataColumn("Column3", typeof(int)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = 0;
            dr["Column3"] = 0;
            dt.Rows.Add(dr);

            //dr = dt.NewRow;
            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;
            //Gridview1.DataSource = dt;
            //Gridview1.DataBind();
        }

        protected void special_license_CheckedChanged(object sender, EventArgs e) 
        {
            spl_Licence.Visible = special_license_yes.Checked;
        }
        protected void WPcheckBox_Load(object sender, EventArgs e) { }

        protected int validateDates(DateTime dateOfIssue, DateTime validFrom, DateTime validTill)
        {
            int flag = 0;
            TimeSpan diff = validTill.Subtract(validFrom);
            if(dateOfIssue > validTill)
            {
                flag = -1;
                Response.Write("<script> alert('Valid Till Date cannot be earlier than Date of Issue!'); </script>");
            } else if (dateOfIssue.Date > validFrom)
            {
                flag = -1;
                Response.Write("<script> alert('Valid From Date cannot be earlier than Date of Issue!'); </script>");
            } else if (diff.Days > 15) 
            {
                flag = -1;
                Response.Write("<script> alert('Valid Till Date cannot exceed 15 days!'); </script>");
            }
            return flag;
        }

        protected void SubmitFrom(object sender, EventArgs e)
        {
            // Obtain values from the permit form
            String siteName = site.SelectedValue;
            String permitNumber = permitNum.Text.Trim();
            DateTime dateOfIssue = Convert.ToDateTime(issueDate.Text.Trim());
            DateTime validFrom = Convert.ToDateTime(perValidFrom.Text.Trim());
            DateTime validTill = Convert.ToDateTime(perValidTill.Text.Trim());
            int flag = validateDates(dateOfIssue, validFrom, validTill);

            if(flag<0)
            {
                return;
            }

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
            }
            if (check2.Checked)
            {
                check2Txt = check2.Text;
            }
            if (check3.Checked)
            {
                check3Txt = check3.Text;
            }
            if (check4.Checked)
            {
                check4Txt = check4.Text;
            }
            if (check5.Checked)
            {
                check5Txt = check5.Text;
            }
            if (check6.Checked)
            {
                check6Txt = check6.Text;
            }
            if (check7.Checked)
            {
                check7Txt = check7.Text;
            }
            if (check8.Checked)
            {
                check8Txt = check8.Text;
            }
            if(!check1.Checked && !check2.Checked && !check3.Checked && !check4.Checked && !check5.Checked && !check6.Checked && !check7.Checked && !check8.Checked)
            {
                Response.Write("<script>alert('Please select a work permit!');</script>");
                return;
            }
            selectedWorkPer = "|" + check1Txt + "|" + check2Txt + "|" + check3Txt + "|" + check4Txt + "|" + check5Txt + "|" + check6Txt + "|" + check7Txt + "|" + check8Txt + "|";
            
            try
            {
                int result = 0;
                // Insert permit details
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
                        cmd.Parameters.AddWithValue("@DeptIssued", deptName);
                        cmd.Parameters.AddWithValue("@PermitsIssued", selectedWorkPer);
                        cmd.Parameters.AddWithValue("@SiteName", siteName);
                        con.Open();
                        // Execute the command and get the result
                        result = cmd.ExecuteNonQuery();
                        con.Close();

                        if (result > 0)
                        {
                            //storeWorkerDetails(workerNum, permitNumber);
                            Response.Write("<script>alert('Data added Successfully.');</script>");
                            try
                            {
                                SendEmail(dateOfIssue, permitNumber);
                            }
                            catch (Exception ex)
                            {
                                Response.Write("<script> alert("+ex.Message+"); </script>");
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

        protected void SendEmail(DateTime dateOfIssue, string permitNumber)
        {
            PermitDetails permitDetails = GetPermitDetailsByNumber(permitNumber);
            //Response.Write("<script>alert('Dept Name: " + deptName + "');</script>");
            string email;
            int flag = -1;
            using (SqlConnection con = new SqlConnection(Main_con))
            {
                using (SqlCommand cmd = new SqlCommand("usp_fetchEmail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Dept_Name", deptName);
                    cmd.Parameters.Add("@EmailID", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
                    con.Open();
                    flag = cmd.ExecuteNonQuery();

                    // Fetch the output 
                    email = cmd.Parameters["@EmailID"].Value.ToString();
                    //Response.Write("<script>alert('Email: " + email + "');</script>");

                    con.Close();

                }
            }

            string from = "adityaraut1003@gmail.com";
            //string to = email; //Use exception handling here!
            using (MailMessage mail = new MailMessage(from, email))
            {
                mail.Subject = "New Work Permit Created";
                mail.Body = "Check out the new work permit created! \nAt: " + dateOfIssue;
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
                Response.Redirect("Welcome.aspx");
            }
        }
    }
}