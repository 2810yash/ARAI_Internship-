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
    }

    public partial class viewWorkPermit : System.Web.UI.Page
    {
        string Main_con = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPermitDetails();
                //agency_list_toSearch();
            }
            if (IsPostBack)
            {
                string eventTarget = Request["__EVENTTARGET"];
                if (eventTarget == "LoadWorkerDetails")
                {
                    string permitNumber = Request["__EVENTARGUMENT"];
                    BindWorkerDetails(permitNumber);
                }
            }
        }
        private void BindWorkerDetails(string permitNumber)
        {
            string query = "SELECT NameOfWorkers, Age, Mask, SafetyShoesGumBoots, JacketsAprons, Gloves, EarPlugMuffs, BeltHarness, Helmet, Remarks FROM Workers WHERE PermitNumber = @PermitNumber";
            using (SqlConnection conn = new SqlConnection(Main_con))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PermitNumber", permitNumber);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        //protected void agency_list_toSearch()
        //{
        //    SqlConnection sqlcon = new SqlConnection(Main_con);
        //    sqlcon.Open();
        //    SqlCommand sql_command = new SqlCommand("SELECT [NameofFirm_Agency] FROM [permit_details_tbl]", sqlcon);
        //    sql_command.CommandType = CommandType.Text;
        //    agencyNames.DataSource = sql_command.ExecuteReader();
        //    agencyNames.DataTextField = "NameofFirm_Agency";
        //    agencyNames.DataBind();
        //    agencyNames.Items.Insert(0, new ListItem("Search Agency Name here...", "0"));
        //}
        private void LoadPermitDetails()
        {
            string query = "SELECT PermitNumber, NameofFirm_Agency, DateofIssue, PermitValidFrom FROM permit_details_tbl";
            SqlConnection con = new SqlConnection(Main_con);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reptCard.DataSource = reader;
            reptCard.DataBind();
            con.Close();
        }

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    string searchtxt = txtSearch.Value.Trim();
        //    //string searchAgency = agencyNames.SelectedValue.Trim();

        //    // Construct the SQL query
        //    string query = "SELECT PermitNumber, NameofFirm_Agency, DateofIssue, PermitValidFrom FROM permit_details_tbl WHERE ";

        //    // Check if search text and agency are both provided
        //    if (!string.IsNullOrEmpty(searchtxt) && !string.IsNullOrEmpty(searchAgency))
        //    {
        //        query += " (PermitNumber LIKE '%' + @searchQuery + '%' OR NameofFirm_Agency LIKE '%' + @searchQuery + '%') AND NameofFirm_Agency = @searchAgency";
        //    }
        //    else if (!string.IsNullOrEmpty(searchtxt))
        //    {
        //        query += " PermitNumber LIKE '%' + @searchQuery + '%' OR NameofFirm_Agency LIKE '%' + @searchQuery + '%'";
        //    }
        //    else if (!string.IsNullOrEmpty(searchAgency))
        //    {
        //        query += " NameofFirm_Agency = @searchAgency";
        //    }
        //    else
        //    {
        //        // Both search text and agency are empty, do nothing
        //        return;
        //    }

        //    // Execute the query
        //    using (SqlConnection con = new SqlConnection(Main_con))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(query, con))
        //        {
        //            if (!string.IsNullOrEmpty(searchtxt))
        //            {
        //                cmd.Parameters.AddWithValue("@searchQuery", searchtxt);
        //            }

        //            if (!string.IsNullOrEmpty(searchAgency))
        //            {
        //                cmd.Parameters.AddWithValue("@searchAgency", searchAgency);
        //            }

        //            con.Open();
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            reptCard.DataSource = reader;
        //            reptCard.DataBind();
        //        }
        //    }
        //}
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchtxt = txtSearch.Value.Trim();

            // Construct the SQL query
            string query = "SELECT PermitNumber, NameofFirm_Agency, DateofIssue, PermitValidFrom FROM permit_details_tbl WHERE ";

            // Check if search text is provided
            if (!string.IsNullOrEmpty(searchtxt))
            {
                query += "PermitNumber LIKE '%' + @searchQuery + '%' OR NameofFirm_Agency LIKE '%' + @searchQuery + '%'";
            }
            else
            {
                // Search text is empty, do nothing
                return;
            }

            // Execute the query
            using (SqlConnection con = new SqlConnection(Main_con))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(searchtxt))
                    {
                        cmd.Parameters.AddWithValue("@searchQuery", searchtxt);
                    }

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reptCard.DataSource = reader;
                    reptCard.DataBind();
                }
            }
        }

        protected void ViewPermit_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                string permitNumber = e.CommandArgument.ToString();
                var permitDetails = GetPermitDetailsByPermitNumber(permitNumber);
                var workerDetails = GetWorkerDetailsByPermitNumber(permitNumber);

                GridView1.DataSource = workerDetails;
                GridView1.DataBind();

                if (permitDetails != null)
                {
                    DisplayPermitDetails(permitDetails);
                }
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
                workPermits
            FROM permit_details_tbl 
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

        private DataTable GetWorkerDetailsByPermitNumber(string permitNumber)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Main_con))
            {
                string query = "SELECT NameOfWorkers, Age, Mask, SafetyShoesGumBoots, JacketsAprons, Gloves, EarPlugMuffs, BeltHarness, Helmet, Remarks FROM Workers WHERE PermitNumber = @PermitNumber";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PermitNumber", permitNumber);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        private void DisplayPermitDetails(PermitDetails details)
        {
            if (details != null)
            {
                string detailsJson = Newtonsoft.Json.JsonConvert.SerializeObject(details);
                string script = $"showPermitDetails({detailsJson});";
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowDetailsScript", script, true);
            }
        }

        protected void deleteViewPermit_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "DeleteDetails")
            {
                string permitNumber = e.CommandArgument.ToString();

                if (permitNumber != null)
                {
                    string query = "DELETE FROM permit_details_tbl WHERE PermitNumber = @PermitNumber";

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
