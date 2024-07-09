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
    public partial class pendingPermit : System.Web.UI.Page
    {
        string permitNum;
        string Main_con = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
        public string deptName, loginID;
        public int deptCode, roleID;

        protected void Page_Load(object sender, EventArgs e)
        {
            loginID = Session["LoginID"].ToString();
            deptName = Session["DeptName"].ToString();
            deptCode = (int)Session["DeptCode"];
            roleID = (int)Session["RoleID"];

            if (!IsPostBack)
            {
                loginID = Session["LoginID"].ToString();
                deptName = Session["DeptName"].ToString();
                deptCode = (int)Session["DeptCode"];
                roleID = (int)Session["RoleID"];

                LoadPermitDetails();
            }
        }
        private void LoadPermitDetails()
        {
            //string query = "SELECT PermitNumber, NameofFirm_Agency, DateofIssue, PermitValidFrom FROM permit_details_tbl_backup WHERE IsClosed = 0 and DeptIssuedCode = " + deptCode;
            using (SqlConnection con = new SqlConnection(Main_con))
            {
                //using (SqlCommand cmd = new SqlCommand(query, con))
                //{
                //    con.Open();
                //    SqlDataReader reader = cmd.ExecuteReader();
                //    reptCard.DataSource = reader;
                //    reptCard.DataBind();
                //    con.Close();
                //}

                using (SqlCommand cmd = new SqlCommand("usp_fetchPermitDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleID", roleID);
                    cmd.Parameters.AddWithValue("@PermitType", "Pending");

                    if (roleID == 1 || roleID == 3 || roleID == 4 || roleID == 5)
                    {
                        cmd.Parameters.AddWithValue("@Dept_Code", deptCode);
                    }
                    else if (roleID == 2)
                    {
                        cmd.Parameters.AddWithValue("@LoginID", loginID);
                    }

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        reptCard.DataSource = reader;
                        reptCard.DataBind();
                        con.Close();
                    }
                }
            }
        }

        protected void hideButtons(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Find the button within the Repeater item
                Button approvePermit = (Button)e.Item.FindControl("approvePermit");
                Button rejectPermit = (Button)e.Item.FindControl("rejectPermit");
                if (approvePermit != null && rejectPermit != null)
                {

                    // Set the visibility based on the role ID
                    if (roleID == 1 || roleID == 3 || roleID == 4 || roleID == 5)
                    {
                        approvePermit.Visible = true;
                        rejectPermit.Visible = true;
                    }
                }
            }
        }

        public PermitDetails GetPermitDetailsByNumber(string permitNumber)
        {
            string Main_con = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
            PermitDetails permitDetails = null;
            using (SqlConnection con = new SqlConnection(Main_con))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM permit_details_tbl_backup WHERE PermitNumber = @PermitNumber", con))
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
                                InsuranceNo = reader["ESI_InsuranceNo"].ToString(),
                                InsuranceValidity = reader["ESI_Validity"].ToString(),
                                AgencyName = reader["NameofFirm_Agency"].ToString(),
                                WorkerNo = reader["NumberofWorkers"].ToString(),
                                ContractorName = reader["NameofSupervisor"].ToString(),
                                ContractorNo = reader["ContractorContactNumber"].ToString(),
                                EngineerName = reader["ARAIEngineer"].ToString(),
                                EngineerNo = reader["EngineerContactNumber"].ToString(),
                                Description = reader["BriefDescriptionofWork"].ToString(),
                                Location = reader["LocationofWork"].ToString(),
                                DeptIssued = reader["DeptIssued"].ToString(),
                                workPermits = reader["PermitsIssued"].ToString()
                            };

                        }
                    }
                    catch (Exception ex)
                    {
                        //Response.Write("<script>console.log('Error reading from database: " + ex.Message + "');</script>");
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error reading from database: " + ex.Message + "');", true);
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }
            return permitDetails;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchtxt = txtSearch.Value.Trim();
            string permitType = "Pending";
            SearchPermitDetails(roleID, deptCode, loginID, searchtxt, permitType);
            //string query = "SELECT PermitNumber, NameofFirm_Agency, DateofIssue, PermitValidFrom FROM permit_details_tbl_backup WHERE (PermitNumber LIKE '%' + @searchQuery + '%' OR NameofFirm_Agency LIKE '%' + @searchQuery + '%') AND IsClosed = 0 AND DeptIssuedCode = " + deptCode;

            //using (SqlConnection con = new SqlConnection(Main_con))
            //{
            //    using (SqlCommand cmd = new SqlCommand(query, con))
            //    {
            //        cmd.Parameters.AddWithValue("@searchQuery", searchtxt);
            //        con.Open();
            //        SqlDataReader reader = cmd.ExecuteReader();
            //        reptCard.DataSource = reader;
            //        reptCard.DataBind();
            //        con.Close();
            //    }
            //}
        }

        protected void SearchPermitDetails(int roleID, int deptCode, string loginID, string searchQuery, string permitType)
        {

            using (SqlConnection con = new SqlConnection(Main_con))
            {
                using (SqlCommand cmd = new SqlCommand("usp_SearchPermitDetails", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleID", roleID);
                    cmd.Parameters.AddWithValue("@PermitType", permitType);

                    if (roleID == 1)
                    {
                        cmd.Parameters.AddWithValue("@DeptCode", deptCode);
                    }
                    else if (roleID == 2)
                    {
                        cmd.Parameters.AddWithValue("@LoginID", loginID);
                    }

                    cmd.Parameters.AddWithValue("@SearchQuery", searchQuery);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reptCard.DataSource = reader;
                        reptCard.DataBind();
                        con.Close();
                    }
                }
            }
            
        }


        protected void allPermits_btn(object sender, EventArgs e)
        {
            Response.Redirect("viewWorkPermit.aspx");
        }
        protected void approvePermit_btn(object sender, EventArgs e)
        {
            Response.Redirect("approvedPermit.aspx");
        }
        protected void approvePermit_btn(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ApproveDetails")
            {
                string permitNumber = e.CommandArgument.ToString();

                using (SqlConnection con = new SqlConnection(Main_con))
                {
                    using (SqlCommand command = new SqlCommand("usp_approvePermits", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@RoleID", roleID);
                        command.Parameters.AddWithValue("@PermitNumber", permitNumber);
                        command.Parameters.AddWithValue("@Date", DateTime.Today.Date);
                        try
                        {
                            con.Open();

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                //SendMail(permitNumber);
                                //Response.Write($"<script>alert('Update successful. Number of rows affected: {rowsAffected}');</script>");
                                try
                                {
                                    //var welcome = new Welcome();
                                    SendEmail(permitNumber, "Approved", "");
                                }
                                catch (Exception ex)
                                {
                                    Response.Write("<script> alert('" + ex.Message + "'); </script>");
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('No rows were updated.');</script>");
                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Write($"<script>alert('An error occurred: {ex.Message}');</script>");
                        }
                        finally
                        {
                            con.Close();
                            Response.Redirect("pendingPermit.aspx");
                        }
                    }
                    

                }

            }
        }

        protected void SendEmail(string permitNumber, string permitType, string remark)
        {
            string emailTo;
            int flag;
            //PermitDetails permitDetails = GetPermitDetailsByNumber(permitNumber);
            string emailFrom, smtp_host, networkCredentials;
            Boolean isBodyHTML, enableSSL, useDefaultCredentials;
            int smtp_port;
            string role = Session["Role"].ToString();

            using (SqlConnection con = new SqlConnection(Main_con))
            {
                using (SqlCommand cmd = new SqlCommand("usp_fetchEmail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FormStatus", permitType);
                    cmd.Parameters.AddWithValue("@Dept_Code", deptCode);
                    cmd.Parameters.AddWithValue("RoleID", (int)Session["RoleID"]);

                    if (permitType.Equals("Rejected"))
                    {
                        cmd.Parameters.AddWithValue("@PermitNumber", permitNumber);
                    }
                    cmd.Parameters.Add("@EmailID", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
                    con.Open();
                    flag = cmd.ExecuteNonQuery();

                    // Fetch the output 
                    emailTo = cmd.Parameters["@EmailID"].Value.ToString();
                    //Response.Write("<script>alert('Email: " + email + "');</script>");
                    con.Close();

                }

                DataTable dt = new DataTable();
                
                using (SqlCommand cmd = new SqlCommand("exec usp_getSMTPDetails", con))
                {

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    DataRow row = dt.Rows[0];
                    emailFrom = row["EmailFrom"].ToString();
                    isBodyHTML = (Boolean)row["IsBodyHTML"];
                    smtp_host = row["SMTP_HOST"].ToString();
                    enableSSL = (Boolean)row["SMTP_EnableSSL"];
                    networkCredentials = row["NetworkCredentials"].ToString();
                    useDefaultCredentials = (Boolean)row["UseDefaultCredentials"];
                    smtp_port = Convert.ToInt32(row["SMTP_Port"]);

                }

            }

            //string from = "adityaraut1003@gmail.com";
            //string to = email; //Use exception handling here!
            try
            {
                using (MailMessage mail = new MailMessage(emailFrom, emailTo))
                {
                   
                    
                    string body;
                    if (permitType.Equals("Approved"))
                    {
                        if (roleID == 5)
                        {
                            mail.Subject = "Work Permit: " + permitNumber + " Closed";
                            body = "\nWork permit " + permitNumber + " has been closed by " + role + ". \nRegards";
                            mail.Body = body;
                        } else
                        {
                            mail.Subject = "Work Permit: " + permitNumber + " Approved";
                            body = "\nWork permit " + permitNumber + " has been approved by " + role + ". \nKindly take further action if necessary. \nRegards";
                            mail.Body = body;
                        }
                    } else if (permitType.Equals("Rejected"))
                    {
                        mail.Subject = "Work Permit: " + permitNumber + " Rejected";
                        body = "Dear User, \nYour permit " + permitNumber + " has been rejected by " + role + ". \nKindly take further action. \nRegards";
                        mail.Body = body;
                    }

                    mail.IsBodyHtml = isBodyHTML; //false
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = smtp_host; //"smtp.gmail.com"
                    smtp.EnableSsl = enableSSL; //true
                    NetworkCredential networkCredential = new NetworkCredential(emailFrom, networkCredentials);
                    smtp.UseDefaultCredentials = useDefaultCredentials; //true
                    smtp.Credentials = networkCredential;
                    smtp.Port = smtp_port; //587
                    smtp.Send(mail);
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Message has been sent successfully.');", true);
                    Response.Redirect("pendingPermit.aspx");
                }
            }
            catch (SmtpException smtpEx)
            {
                //Response.Write($"<script>alert('SMTP Exception: {smtpEx.Message}');</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('SMTP Exception : " + smtpEx.Message + "');", true);
            }
            catch (Exception ex)
            {
                //Response.Write($"<script>alert('General Exception: {ex.Message}');</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('General Exception : " + ex.Message + "');", true);
            }
        }


        protected void rejectPermit_btn(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "RejectDetails")
            {
                string permitNumber = e.CommandArgument.ToString();
                ViewState["PermitNumber"] = permitNumber;
                permitNum = permitNumber;
                remarkContaineer.Visible = true;
                reptCard.Visible = false;
                permitnumPara.InnerHtml = $"<storng>Reject Permit:</storng> {permitNum}";
            }
        }
        protected void submitRemarkBtn_Click(object sender, EventArgs e)
        {
            string remark = remarkText.InnerText.Trim();
            string permitNumber = ViewState["PermitNumber"] as String;
            SubmitRemark(permitNumber, remark);
            //SendEmail(permitNumber, "Rejected");

        }

        protected void SubmitRemark(string permitNumber, string remark)
        {
            try
            {
                int result = 0;
                using (SqlConnection con = new SqlConnection(Main_con))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_updateRemark", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@permitNum", permitNumber);
                        cmd.Parameters.AddWithValue("@Remark", remark);
                        con.Open();
                        result = cmd.ExecuteNonQuery();
                        con.Close();
                        if (result > 0)
                        {
                            Response.Write($"<script>alert('Selected Permit has been Rejected. Permit Number: {permitNumber}');</script>");
                            SendEmail(permitNumber, "Rejected", remark);
                            Response.Redirect("pendingPermit.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Data updatation UnSuccessfully.');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Exception: {ex.Message}');</script>");
            }
        }

        protected void closeBtn_Click(object sender, EventArgs e)
        {
            remarkContaineer.Visible = false;
            reptCard.Visible = true;
        }

        protected void rejectedPermit_btn(object sender, EventArgs e)
        {
            Response.Redirect("rejected.aspx");
        }

        protected void ViewPermit_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                string permitNumber = e.CommandArgument.ToString();
                permitNum = permitNumber;
                var permitDetails = GetPermitDetailsByPermitNumber(permitNumber);

                if (permitDetails != null)
                {
                    GetData();
                    DisplayPermitDetails(permitDetails);
                }
            }
        }
        protected void EditViewPermit_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "EditDetails")
            {
                string permitNum = e.CommandArgument.ToString();
                Session["PermitNumber"] = permitNum;
                Response.Redirect("editPermitForm.aspx");
            }
        }
        private PermitDetails GetPermitDetailsByPermitNumber(string permitNumber)
        {
            PermitDetails permitDetails = null;
            string query = @"
            SELECT 
                SiteName, 
                PermitNumber, 
                DateofIssue, 
                PermitValidFrom, 
                PermitValidTill, 
                SpecialLicense, 
                SpecialLicenseType, 
                ESI_InsuranceNo AS InsuranceNo, 
                ESI_Validity AS InsuranceValidity, 
                NameofFirm_Agency AS AgencyName, 
                NumberofWorkers AS WorkerNo, 
                NameofSupervisor AS ContractorName, 
                ContractorContactNumber AS ContractorNo, 
                ARAIEngineer AS EngineerName, 
                EngineerContactNumber AS EngineerNo, 
                BriefDescriptionofWork AS Description, 
                LocationofWork AS Location,
                PermitsIssued
            FROM permit_details_tbl_backup 
            WHERE PermitNumber = @PermitNumber";

            using (SqlConnection con = new SqlConnection(Main_con))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PermitNumber", permitNumber);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
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
                                workPermits = reader["PermitsIssued"].ToString()
                            };
                        }
                    }
                }
            }
            return permitDetails;
        }
        private void DisplayPermitDetails(PermitDetails permitDetails)
        {
            string permitDetailsJson = Newtonsoft.Json.JsonConvert.SerializeObject(permitDetails);
            string script = $"showPermitDetails({permitDetailsJson});";
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowDetailsScript", script, true);
        }
        private void GetData()
        {
            string permitNumber = permitNum;
            DataTable table = new DataTable();

            // Replace with your connection string information
            using (SqlConnection con = new SqlConnection(Main_con))
            {
                string sql = "SELECT * FROM [Demo].[dbo].[Workers] WHERE PermitNumber = @PermitNumber";

                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@PermitNumber", permitNumber); // Add parameter for permit number

                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }

            workerDetails.DataSource = table;
            workerDetails.DataBind();
        }
        protected void deleteViewPermit_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "DeleteDetails")
            {
                string permitNumber = e.CommandArgument.ToString();

                if (!string.IsNullOrEmpty(permitNumber))
                {
                    string query = "DELETE FROM permit_details_tbl_backup WHERE PermitNumber = @PermitNumber";

                    using (SqlConnection con = new SqlConnection(Main_con))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@PermitNumber", permitNumber);
                            try
                            {
                                con.Open();
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                // Log or handle the exception as needed
                                throw; // or handle the error appropriately
                            }
                            finally
                            {
                                con.Close();
                                Response.Redirect("viewWorkPermit.aspx");
                            }
                        }
                    }
                }
            }
        }
    }
}