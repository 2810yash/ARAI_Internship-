using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public class PermitDetails
    {
        public string SiteName { get; set; }
        public string PermitNumber { get; set; }
        public static string PermitNUM { get; set; }
        public string DateofIssue { get; set; }
        public string PermitValidFrom { get; set; }
        public string PermitValidTill { get; set; }
        public string SpecialLicense { get; set; }
        public string SpecialLicenseType { get; set; }
        public string InsuranceNo { get; set; }
        public string InsuranceValidity { get; set; }
        public string AgencyName { get; set; }
        public string WorkerNo { get; set; }
        public string ContractorName { get; set; }
        public string ContractorNo { get; set; }
        public string EngineerName { get; set; }
        public string EngineerNo { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string DeptIssued { get; set; }
        public string workPermits { get; set; }
        public string workerName { get; set; }
        public string workerAge { get; set; }
        public string maskIssued { get; set; }
        public string shoesIssued { get; set; }
        public string jacketIssued { get; set; }
        public string glovesIssued { get; set; }
        public string earplugIssued { get; set; }
        public string beltIssued { get; set; }
        public string helmetIssued { get; set; }
        public string Remarks { get; set; }


    }

    public partial class viewWorkPermit : System.Web.UI.Page
    {
        string permitNum;
        string Main_con = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
        public string deptName;
        public int deptCode;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                deptName = Session["DeptName"].ToString();
                deptCode = (int)Session["DeptCode"];
                LoadPermitDetails();
            }
        }

        private void LoadPermitDetails()
        {
            string query;
            string loginID = Session["LoginID"].ToString();
            
            using (SqlConnection con = new SqlConnection(Main_con))
            {
                //if ((int)Session["RoleID"] == 2)
                //{
                //    query = "SELECT PermitNumber, NameofFirm_Agency, DateofIssue, PermitValidFrom FROM permit_details_tbl_backup where CreatedBy  " + loginID;
                //    using (SqlCommand cmd = new SqlCommand(query, con))
                //    {
                //        //Dataset 
                //        con.Open();
                //        //cmd.Parameters.AddWithValue("@CreatedBy", loginID);
                //        SqlDataReader reader = cmd.ExecuteReader();
                //        reptCard.DataSource = reader;
                //        reptCard.DataBind();
                //        con.Close();
                //    }
                //}
                //else
                //{
                //    query = "SELECT PermitNumber, NameofFirm_Agency, DateofIssue, PermitValidFrom FROM permit_details_tbl_backup where DeptIssuedCode = " + deptCode;
                //}
                //using (SqlCommand cmd = new SqlCommand(query, con))
                //{
                //    con.Open();
                //    //cmd.Parameters.AddWithValue("@DeptName", deptName);
                //    SqlDataReader reader = cmd.ExecuteReader();
                //    reptCard.DataSource = reader;
                //    reptCard.DataBind();
                //    con.Close();
                //}

                query = "SELECT PermitNumber, NameofFirm_Agency, DateofIssue, PermitValidFrom FROM permit_details_tbl_backup WHERE DeptIssuedCode = " + deptCode;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    //Dataset 
                    con.Open();
                    //cmd.Parameters.AddWithValue("@CreatedBy", loginID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reptCard.DataSource = reader;
                    reptCard.DataBind();
                    con.Close();
                }
            }
        }

        protected void pendingBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("pendingPermit.aspx");
        }
        protected void approvePermit_btn(object sender, EventArgs e)
        {
            Response.Redirect("approvedPermit.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchtxt = txtSearch.Value.Trim();
            string query = "SELECT PermitNumber, NameofFirm_Agency, DateofIssue, PermitValidFrom FROM permit_details_tbl_backup WHERE  DeptIssuedCode = " + deptCode + " AND PermitNumber LIKE '%' + @searchQuery + '%' OR NameofFirm_Agency LIKE '%' + @searchQuery + '%'";

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