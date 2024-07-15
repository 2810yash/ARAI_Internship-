using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public class PermitDetails
    {
        public string SiteName { get; set; }
        public string PermitNumber { get; set; }
        public static string PermitNUM { get; set; }
        public DateTime DateofIssue { get; set; }
        public DateTime PermitValidFrom { get; set; }
        public DateTime PermitValidTill { get; set; }
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
        public string Rejected_Remark { get; set; }
        public string fileName { get; set; }
        public string filePath { get; set; }
        public string fIleExtention { get; set; }

        public List<string> hazards { get; set; }
        public List<string> precautions { get; set; }
        public List<string> ppes { get; set; }


    
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
                                DateofIssue = (DateTime)reader["DateofIssue"],
                                PermitValidFrom = (DateTime)reader["PermitValidFrom"],
                                PermitValidTill = (DateTime)reader["PermitValidTill"],
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


    }

    public partial class viewWorkPermit : System.Web.UI.Page
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
            JSAContainers.Visible = false;


            if (Session["LoginID"] != null && Session["DeptName"] != null && Session["DeptCode"] != null && Session["RoleID"] != null)
            {
                if (!IsPostBack)
                {
                    loginID = Session["LoginID"].ToString();
                    deptName = Session["DeptName"].ToString();
                    deptCode = (int)Session["DeptCode"];
                    roleID = (int)Session["RoleID"];
                    LoadPermitDetails();
                }
            }
            else
            {
                
                Response.Redirect("login.aspx");           
            }
        }

        private void LoadPermitDetails()
        {
            //string query;
            
            using (SqlConnection con = new SqlConnection(Main_con))
            {

                using (SqlCommand cmd = new SqlCommand("usp_fetchPermitDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleID", roleID);
                    cmd.Parameters.AddWithValue("@PermitType", "All");

                    if(roleID == 1 || roleID == 3 || roleID == 4 || roleID == 5)
                    {
                        cmd.Parameters.AddWithValue("@Dept_Code", deptCode);
                    } else if (roleID == 2)
                    {
                        cmd.Parameters.AddWithValue("@LoginID", loginID);
                    }

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reptCard.DataSource = reader;
                        reptCard.DataBind();
                        //con.Close();
                    }
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

        protected void rejectedBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("rejected.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchtxt = txtSearch.Value.Trim();
            string permitType = "All";
            SearchPermitDetails(roleID, deptCode, loginID, searchtxt, permitType);

            //string query = "SELECT PermitNumber, NameofFirm_Agency, DateofIssue, PermitValidFrom FROM permit_details_tbl_backup WHERE  DeptIssuedCode = " + deptCode + " AND PermitNumber LIKE '%' + @searchQuery + '%' OR NameofFirm_Agency LIKE '%' + @searchQuery + '%'";

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

        protected void ViewPermit_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                JSAContainers.Visible = true;
                string permitNumber = e.CommandArgument.ToString();
                permitNum = permitNumber;
                var permitDetails = GetPermitDetailsByPermitNumber(permitNumber);

                if (permitDetails != null)
                {
                    GetData();
                    GetJSAData();
                    DisplayPermitDetails(permitDetails);
                }
            }
        }
        protected void downloadFile_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "DownloadFile")
            {
                string filePath = e.CommandArgument.ToString();
                Process.Start(filePath);
            }
        }
        //protected void EditViewPermit_Click(object sender, CommandEventArgs e)
        //{
        //    if (e.CommandName == "EditDetails")
        //    {
        //        string permitNum = e.CommandArgument.ToString();
        //        Response.Redirect("editPermitForm.aspx");
        //    }
        //}

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
                                DateofIssue = (DateTime)reader["DateofIssue"],
                                PermitValidFrom = (DateTime)reader["PermitValidFrom"],
                                PermitValidTill = (DateTime)reader["PermitValidTill"],
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

        private void GetJSAData()   
        {
            string permitNumber = permitNum;
            int flag;
            string workPermits;
            //DataTable hazards = new DataTable();
            //DataTable precautions = new DataTable();
            //DataTable ppes = new DataTable();

            using (SqlConnection con = new SqlConnection(Main_con))
            {
                using (SqlCommand command = new SqlCommand("usp_fetchWorkPermits", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PermitNumber", permitNumber);
                    command.Parameters.Add("@WorkPermits", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;

                    con.Open();
                    flag = command.ExecuteNonQuery();

                    workPermits = command.Parameters["@WorkPermits"].Value.ToString();
                    con.Close();
                }

                string[] parts = workPermits.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                // Trim each part to remove any leading or trailing whitespace
                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i] = parts[i].Trim();
                }

                // Initialize variables to hold up to 8 parts
                string wp1 = parts.Length > 0 ? parts[0] : string.Empty;
                string wp2 = parts.Length > 1 ? parts[1] : string.Empty;
                string wp3 = parts.Length > 2 ? parts[2] : string.Empty;
                string wp4 = parts.Length > 3 ? parts[3] : string.Empty;
                string wp5 = parts.Length > 4 ? parts[4] : string.Empty;
                string wp6 = parts.Length > 5 ? parts[5] : string.Empty;
                string wp7 = parts.Length > 6 ? parts[6] : string.Empty;
                string wp8 = parts.Length > 7 ? parts[7] : string.Empty;

                try
                {
                    using (SqlCommand command = new SqlCommand("usp_showHazardsAndAll", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@WP1", wp1);
                        command.Parameters.AddWithValue("@WP2", wp2);
                        command.Parameters.AddWithValue("@WP3", wp3);
                        command.Parameters.AddWithValue("@WP4", wp4);
                        command.Parameters.AddWithValue("@WP5", wp5);
                        command.Parameters.AddWithValue("@WP6", wp6);
                        command.Parameters.AddWithValue("@WP7", wp7);
                        command.Parameters.AddWithValue("@WP8", wp8);

                        con.Open();

                        //using (SqlDataReader reader = command.ExecuteReader())
                        //{
                        //    // Load hazards DataTable
                        //    DataTable hazards = new DataTable();
                        //    hazards.Load(reader);
                        //    Console.WriteLine("Loaded hazards: " + hazards.Rows.Count + " rows");

                        //    // Move to the next result set and load precautions DataTable
                        //    DataTable precautions = new DataTable();
                        //    if (reader.NextResult())
                        //    {
                        //        precautions.Load(reader);
                        //        Console.WriteLine("Loaded precautions: " + precautions.Rows.Count + " rows");
                        //    }

                        //    // Move to the next result set and load ppes DataTable
                        //    DataTable ppes = new DataTable();
                        //    if (reader.NextResult())
                        //    {
                        //        ppes.Load(reader);
                        //        Console.WriteLine("Loaded ppes: " + ppes.Rows.Count + " rows");
                        //    }

                        //    // Display DataTables
                        //    DisplayDataTable("Hazards", hazards);
                        //    DisplayDataTable("Precautions", precautions);
                        //    DisplayDataTable("PPEs", ppes);
                        //}

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Load hazards DataTable
                            DataTable hazards = new DataTable();
                            hazards.Load(reader);
                            hazardDetails.DataSource = hazards;
                            hazardDetails.DataBind();
                            Console.WriteLine("Loaded hazards: " + hazards.Rows.Count + " rows");

                            // Move to the next result set and load precautions DataTable
                            DataTable precautions = new DataTable();
                            precautions.Load(reader);
                            precautionsDetails.DataSource = precautions;
                            precautionsDetails.DataBind();
                            Console.WriteLine("Loaded precautions: " + precautions.Rows.Count + " rows");
                            //if (reader.NextResult() && reader.HasRows)
                            //{
                            //    precautions.Load(reader);
                            //    precautionsDetails.DataSource = precautions;
                            //    precautionsDetails.DataBind();
                            //    Console.WriteLine("Loaded precautions: " + precautions.Rows.Count + " rows");
                            //}

                            // Move to the next result set and load ppes DataTable
                            DataTable ppes = new DataTable();
                            ppes.Load(reader);
                            ppeDetails.DataSource = ppes;
                            ppeDetails.DataBind();
                            Console.WriteLine("Loaded PPES: " + ppes.Rows.Count + " rows");
                            //if (reader.NextResult() && reader.HasRows)
                            //{
                            //    ppes.Load(reader);
                            //    ppeDetails.DataSource = ppes;
                            //    ppeDetails.DataBind();
                            //    Console.WriteLine("Loaded PPES: " + ppes.Rows.Count + " rows");
                            //}
                        }

                        con.Close();

                        //hazardDetails.DataSource = hazards;
                        //hazardDetails.DataBind();

                        //precautionsDetails.DataSource = precautions;
                        //precautionsDetails.DataBind();

                        //ppeDetails.DataSource = ppes;
                        //ppeDetails.DataBind();

                    }
                } catch (Exception ex)
                {
                    Response.Write("<script>alert('Error Occured: '" + ex + "'. Please try again!');</script>");
                }
                
            }
        }
        static void DisplayDataTable(string title, DataTable table)
        {
            Console.WriteLine($"\n{title} DataTable:");
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine(string.Join(", ", row.ItemArray));
            }
        }


        //protected void deleteViewPermit_Click(object sender, CommandEventArgs e)
        //{
        //    if (e.CommandName == "DeleteDetails")
        //    {
        //        string permitNumber = e.CommandArgument.ToString();

        //        if (!string.IsNullOrEmpty(permitNumber))
        //        {
        //            string query = "DELETE FROM permit_details_tbl_backup WHERE PermitNumber = @PermitNumber";

        //            using (SqlConnection con = new SqlConnection(Main_con))
        //            {
        //                using (SqlCommand cmd = new SqlCommand(query, con))
        //                {
        //                    cmd.Parameters.AddWithValue("@PermitNumber", permitNumber);
        //                    try
        //                    {
        //                        con.Open();
        //                        cmd.ExecuteNonQuery();
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        // Log or handle the exception as needed
        //                        throw; // or handle the error appropriately
        //                    }
        //                    finally
        //                    {
        //                        con.Close();
        //                        Response.Redirect("viewWorkPermit.aspx");
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
    }
}