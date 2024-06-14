using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public partial class approvedPermit : System.Web.UI.Page
    {
        string permitNum;
        string Main_con = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
        public string deptName; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPermitDetails();
                deptName = Session["DeptName"].ToString();

            }
        }
        private void LoadPermitDetails()
        {
            string query = "SELECT PermitNumber, NameofFirm_Agency, DateofIssue, PermitValidFrom FROM permit_details_tbl_backup WHERE IsClosed = 1 and DeptIssued = '" + deptName + "'";
            using (SqlConnection con = new SqlConnection(Main_con))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reptCard.DataSource = reader;
                    reptCard.DataBind();
                    con.Close();
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchtxt = txtSearch.Value.Trim();
            string query = "SELECT PermitNumber, NameofFirm_Agency, DateofIssue, PermitValidFrom FROM permit_details_tbl_backup WHERE (PermitNumber LIKE '%' + @searchQuery + '%' OR NameofFirm_Agency LIKE '%' + @searchQuery + '%') AND IsClosed = 1";

            using (SqlConnection con = new SqlConnection(Main_con))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@searchQuery", searchtxt);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reptCard.DataSource = reader;
                    reptCard.DataBind();
                    con.Close();
                }
            }
        }
        protected void allPermits_btn(object sender, EventArgs e)
        {
            Response.Redirect("viewWorkPermit.aspx");
        }
        protected void pendingPermit_btn(object sender, EventArgs e)
        {
            Response.Redirect("pendingPermit.aspx");
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
                Response.Redirect("editWorkPermit.aspx?permitNumber=" + permitNum);
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
                                workPermits = reader["workPermits"].ToString()
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