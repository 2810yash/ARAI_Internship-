using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace AdminTemplate3._1._0
{
    public partial class approvedPermit : System.Web.UI.Page
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
        public char trueFalseCHeck(string sttus)
        {
            if(sttus.Equals("True"))
            {
                return '\u2713';
            } else
            {
                return '-';
            }
        }
        private void LoadPermitDetails()
        {
            //string query = "SELECT PermitNumber, NameofFirm_Agency, DateofIssue, PermitValidFrom FROM permit_details_tbl_backup WHERE IsClosed = 1 and DeptIssuedCode = " + deptCode;
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
                    cmd.Parameters.AddWithValue("@PermitType", "Approved");

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
                //Button editPermit = (Button)e.Item.FindControl("editPermit");
                Button downloadPermit = (Button)e.Item.FindControl("downloadPemit");
                if (downloadPermit != null)
                {

                    // Set the visibility based on the role ID
                    if (roleID ==  2)
                    {
                        //editPermit.Visible = true;
                    }
                    if(roleID == 5)
                    {
                        downloadPermit.Visible = true;
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchtxt = txtSearch.Value.Trim();
            string permitType = "Approved";
            SearchPermitDetails(roleID, deptCode, loginID, searchtxt, permitType);
            //string query = "SELECT PermitNumber, NameofFirm_Agency, DateofIssue, PermitValidFrom FROM permit_details_tbl_backup WHERE (PermitNumber LIKE '%' + @searchQuery + '%' OR NameofFirm_Agency LIKE '%' + @searchQuery + '%') AND IsClosed = 1 and DeptIssuedCode = " + deptCode;

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
        protected void pendingPermit_btn(object sender, EventArgs e)
        {
            Response.Redirect("pendingPermit.aspx");
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

        protected void downloadViewPermit_Click(object sender, CommandEventArgs e)
        {
            string permitNumber = e.CommandArgument.ToString();
            string pdfPath = Server.MapPath($"~/PermitPDFs/{permitNumber}.pdf");
            List<PermitDetails> permit = new List<PermitDetails>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Main_con))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("get_PermitDetails", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@permitNumber", permitNumber);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PermitDetails permitdel = new PermitDetails
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
                                    workPermits = reader["PermitsIssued"].ToString()
                                };
                                permit.Add(permitdel);
                            }

                        }
                    }
                }

                ExportToPdf(permit, pdfPath);
                Response.Write("<script>alert('Successfully converted to PDF.');</script>");
                Process.Start(pdfPath);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "');</script>");
            }
        }
        public static List<PermitDetails> GetWorkerDetails(string permitNumber)
        {
            string Main_con = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;

            List<PermitDetails> workerInfoList = new List<PermitDetails>();

            // Replace with your actual connection string details

            using (SqlConnection connection = new SqlConnection(Main_con))
            {
                try
                {
                    connection.Open();

                    string sqlQuery = "SELECT * FROM Workers WHERE PermitNumber = @permitNumber";
                    SqlParameter permitNumberParam = new SqlParameter("@permitNumber", permitNumber);

                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    command.Parameters.Add(permitNumberParam);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable workerTable = new DataTable();
                    adapter.Fill(workerTable);

                    foreach (DataRow row in workerTable.Rows)
                    {
                        PermitDetails workerInfo = new PermitDetails();
                        workerInfo.workerName = row["NameOfWorkers"].ToString();
                        workerInfo.workerAge = row["Age"].ToString();
                        workerInfo.maskIssued = row["Mask"].ToString();
                        workerInfo.shoesIssued = row["SafetyShoesGumBoots"].ToString();
                        workerInfo.jacketIssued = row["JacketsAprons"].ToString();
                        workerInfo.glovesIssued = row["Gloves"].ToString();
                        workerInfo.earplugIssued = row["EarPlugMuffs"].ToString();
                        workerInfo.beltIssued = row["BeltHarness"].ToString();
                        workerInfo.helmetIssued = row["Helmet"].ToString();
                        workerInfo.Rejected_Remark = row["Remarks"].ToString();
                        workerInfoList.Add(workerInfo);
                    }
                }
                catch (SqlException ex)
                {
                    // Handle SQL exceptions here (e.g., connection errors, invalid queries)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return workerInfoList;
        }
        static void ExportToPdf(List<PermitDetails> permits, string pdfPath)
        {
            using (FileStream fs = new FileStream(pdfPath, FileMode.Create))
            {
                Document document = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                foreach (var permit in permits)
                {
                    // Permit details section
                    PdfPTable permitDetailsTable = new PdfPTable(2);  // Two main columns

                    // Permit details title
                    PdfPCell titleCell = new PdfPCell(new Phrase("Work Permit", FontFactory.GetFont(FontFactory.TIMES_BOLD, 20)));
                    titleCell.Colspan = 2;  // Span across both main columns
                    titleCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    titleCell.VerticalAlignment = Element.ALIGN_CENTER;
                    titleCell.Border = Rectangle.NO_BORDER;
                    permitDetailsTable.AddCell(titleCell);
                    PdfPCell emptyCell1 = new PdfPCell();
                    emptyCell1.Colspan = 2;
                    emptyCell1.MinimumHeight = 30f;  // Set a minimum height for spacing
                    emptyCell1.Border = Rectangle.NO_BORDER;  // Remove borders (optional)
                    permitDetailsTable.AddCell(emptyCell1);

                    PdfPCell txt1 = new PdfPCell(new Phrase("* Security shall check work permit and allow workers to enter with valid work permit in case of below mentioned works. *", FontFactory.GetFont(FontFactory.TIMES_BOLD, 9)));
                    txt1.Colspan = 2;  // Span across both main columns
                    txt1.HorizontalAlignment = Element.ALIGN_LEFT;
                    txt1.VerticalAlignment = Element.ALIGN_CENTER;
                    txt1.Border = Rectangle.NO_BORDER;
                    permitDetailsTable.AddCell(txt1);
                    PdfPCell txt2 = new PdfPCell(new Phrase("* Work permit to be filled by contractor in consultation with ARAI officials(of work intending dept.) *", FontFactory.GetFont(FontFactory.TIMES_BOLD, 9)));
                    txt2.Colspan = 2;  // Span across both main columns
                    txt2.HorizontalAlignment = Element.ALIGN_LEFT;
                    txt2.VerticalAlignment = Element.ALIGN_CENTER;
                    txt2.Border = Rectangle.NO_BORDER;
                    permitDetailsTable.AddCell(txt2);
                    PdfPCell txt3 = new PdfPCell(new Phrase("* Work on Saturday/Sunday & holidays will be under strict supervision of work intending departments. *", FontFactory.GetFont(FontFactory.TIMES_BOLD, 9)));
                    txt3.Colspan = 2;  // Span across both main columns
                    txt3.HorizontalAlignment = Element.ALIGN_LEFT;
                    txt3.VerticalAlignment = Element.ALIGN_CENTER;
                    txt3.Border = Rectangle.NO_BORDER;
                    permitDetailsTable.AddCell(txt3);

                    // Site Name
                    PdfPCell siteName = new PdfPCell(new Phrase(permit.SiteName, FontFactory.GetFont(FontFactory.TIMES_BOLD, 16)));
                    siteName.Colspan = 2;  // Span across both main columns
                    siteName.HorizontalAlignment = Element.ALIGN_CENTER;
                    siteName.VerticalAlignment = Element.ALIGN_CENTER;
                    siteName.Border = Rectangle.NO_BORDER;
                    permitDetailsTable.AddCell(siteName);
                    PdfPCell emptyCell2 = new PdfPCell();
                    emptyCell2.Colspan = 2;
                    emptyCell2.MinimumHeight = 10f;  // Set a minimum height for spacing
                    emptyCell2.Border = Rectangle.NO_BORDER;  // Remove borders (optional)
                    permitDetailsTable.AddCell(emptyCell2);

                    // Date Of Issue
                    PdfPCell issueDate = new PdfPCell(new Phrase("Date of Issue: " + permit.DateofIssue, FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    issueDate.Colspan = 2;  // Span across both main columns
                    issueDate.HorizontalAlignment = Element.ALIGN_RIGHT;
                    issueDate.VerticalAlignment = Element.ALIGN_CENTER;
                    issueDate.Border = Rectangle.NO_BORDER;
                    permitDetailsTable.AddCell(issueDate);
                    PdfPCell emptyCell3 = new PdfPCell();
                    emptyCell3.Colspan = 2;
                    emptyCell3.MinimumHeight = 10f;  // Set a minimum height for spacing
                    emptyCell3.Border = Rectangle.NO_BORDER;  // Remove borders (optional)
                    permitDetailsTable.AddCell(emptyCell3);

                    // Permit Number
                    PdfPCell permitNumberCell = new PdfPCell(new Phrase("Permit Number:", FontFactory.GetFont(FontFactory.TIMES_BOLD, 13)));
                    permitNumberCell.HorizontalAlignment = Element.ALIGN_RIGHT; // Align label to the right
                    permitNumberCell.VerticalAlignment = Element.ALIGN_CENTER; // Align label to the right
                    permitNumberCell.Border = Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER; // Set left, top, and bottom borders
                    permitDetailsTable.AddCell(permitNumberCell);
                    PdfPCell permitNumberValueCell = new PdfPCell(new Phrase(permit.PermitNumber, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 11)));
                    permitNumberValueCell.HorizontalAlignment = Element.ALIGN_LEFT; // Align value to the left
                    permitNumberValueCell.VerticalAlignment = Element.ALIGN_CENTER; // Align value to the left
                    permitNumberValueCell.Border = Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER; // Set right, top, and bottom borders
                    permitDetailsTable.AddCell(permitNumberValueCell);

                    // Left column (nested two columns)
                    PdfPTable leftColumnTable = new PdfPTable(2);  // Two columns for left side

                    // Permit Valid From
                    PdfPCell validFrom = new PdfPCell(new Phrase("Permit Valid From: ", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    validFrom.Border = Rectangle.NO_BORDER;
                    validFrom.HorizontalAlignment = Element.ALIGN_RIGHT;
                    validFrom.VerticalAlignment = Element.ALIGN_CENTER;
                    leftColumnTable.AddCell(validFrom);
                    PdfPCell validFromValue = new PdfPCell(new Phrase((permit.PermitValidFrom.Date).ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                    validFromValue.Border = Rectangle.NO_BORDER;
                    validFromValue.HorizontalAlignment = Element.ALIGN_LEFT;
                    validFromValue.VerticalAlignment = Element.ALIGN_CENTER;
                    leftColumnTable.AddCell(validFromValue);

                    // Special License
                    PdfPCell splLicense = new PdfPCell(new Phrase("Special License: ", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    splLicense.Border = Rectangle.NO_BORDER;
                    splLicense.HorizontalAlignment = Element.ALIGN_RIGHT;
                    splLicense.VerticalAlignment = Element.ALIGN_CENTER;
                    leftColumnTable.AddCell(splLicense);
                    PdfPCell splLicenseValue = new PdfPCell(new Phrase(permit.SpecialLicense, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                    splLicenseValue.Border = Rectangle.NO_BORDER;
                    splLicenseValue.HorizontalAlignment = Element.ALIGN_LEFT;
                    splLicenseValue.VerticalAlignment = Element.ALIGN_CENTER;
                    leftColumnTable.AddCell(splLicenseValue);

                    // ESI/Insurance No
                    PdfPCell esiNo = new PdfPCell(new Phrase("ESI/Insurance No: ", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    esiNo.Border = Rectangle.NO_BORDER;
                    esiNo.HorizontalAlignment = Element.ALIGN_RIGHT;
                    esiNo.VerticalAlignment = Element.ALIGN_CENTER;
                    leftColumnTable.AddCell(esiNo);
                    PdfPCell esiNoValue = new PdfPCell(new Phrase(permit.InsuranceNo, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                    esiNoValue.Border = Rectangle.NO_BORDER;
                    esiNoValue.HorizontalAlignment = Element.ALIGN_LEFT;
                    esiNoValue.VerticalAlignment = Element.ALIGN_CENTER;
                    leftColumnTable.AddCell(esiNoValue);

                    // AgencyName
                    PdfPCell agencyName = new PdfPCell(new Phrase("Name of Vendor or Contractor Firm/Agency: ", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    agencyName.Border = Rectangle.NO_BORDER;
                    agencyName.HorizontalAlignment = Element.ALIGN_RIGHT;
                    agencyName.VerticalAlignment = Element.ALIGN_CENTER;
                    leftColumnTable.AddCell(agencyName);
                    PdfPCell agencyNameValue = new PdfPCell(new Phrase(permit.AgencyName, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                    agencyNameValue.Border = Rectangle.NO_BORDER;
                    agencyNameValue.HorizontalAlignment = Element.ALIGN_LEFT;
                    agencyNameValue.VerticalAlignment = Element.ALIGN_CENTER;
                    leftColumnTable.AddCell(agencyNameValue);

                    // ContractorName
                    PdfPCell contractorName = new PdfPCell(new Phrase("Name of Vendor/Contractor Supervisor: ", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    contractorName.Border = Rectangle.NO_BORDER;
                    contractorName.HorizontalAlignment = Element.ALIGN_RIGHT;
                    contractorName.VerticalAlignment = Element.ALIGN_CENTER;
                    leftColumnTable.AddCell(contractorName);
                    PdfPCell contractorNameValue = new PdfPCell(new Phrase(permit.ContractorName, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                    contractorNameValue.Border = Rectangle.NO_BORDER;
                    contractorNameValue.HorizontalAlignment = Element.ALIGN_LEFT;
                    contractorNameValue.VerticalAlignment = Element.ALIGN_CENTER;
                    leftColumnTable.AddCell(contractorNameValue);

                    // ARAI Engineer
                    PdfPCell engiName = new PdfPCell(new Phrase("ARAI Engineer: ", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    engiName.Border = Rectangle.NO_BORDER;
                    engiName.HorizontalAlignment = Element.ALIGN_RIGHT;
                    engiName.VerticalAlignment = Element.ALIGN_CENTER;
                    leftColumnTable.AddCell(engiName);
                    PdfPCell engiNameValue = new PdfPCell(new Phrase(permit.EngineerName, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                    engiNameValue.Border = Rectangle.NO_BORDER;
                    engiNameValue.HorizontalAlignment = Element.ALIGN_LEFT;
                    engiNameValue.VerticalAlignment = Element.ALIGN_CENTER;
                    leftColumnTable.AddCell(engiNameValue);

                    // Brief Description of Work
                    PdfPCell discription = new PdfPCell(new Phrase("Brief Description of Work: ", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    discription.Border = Rectangle.NO_BORDER;
                    discription.HorizontalAlignment = Element.ALIGN_RIGHT;
                    discription.VerticalAlignment = Element.ALIGN_CENTER;
                    leftColumnTable.AddCell(discription);
                    PdfPCell discriptionValue = new PdfPCell(new Phrase(permit.Description, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                    discriptionValue.Border = Rectangle.NO_BORDER;
                    discriptionValue.HorizontalAlignment = Element.ALIGN_LEFT;
                    discriptionValue.VerticalAlignment = Element.ALIGN_CENTER;
                    leftColumnTable.AddCell(discriptionValue);

                    permitDetailsTable.AddCell(leftColumnTable);  // Add left column to main table

                    // Right column
                    PdfPTable rightColumnTable = new PdfPTable(2);  // two column for right side

                    // Permit Valid Till
                    PdfPCell validTill = new PdfPCell(new Phrase("Permit Valid Till: ", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    validTill.Border = Rectangle.NO_BORDER;
                    validTill.HorizontalAlignment = Element.ALIGN_RIGHT;
                    validTill.VerticalAlignment = Element.ALIGN_CENTER;
                    rightColumnTable.AddCell(validTill);
                    PdfPCell validTillValue = new PdfPCell(new Phrase((permit.PermitValidTill.Date).ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                    validTillValue.Border = Rectangle.NO_BORDER;
                    validTillValue.HorizontalAlignment = Element.ALIGN_LEFT;
                    validTillValue.VerticalAlignment = Element.ALIGN_CENTER;
                    rightColumnTable.AddCell(validTillValue);

                    // Special License Type
                    PdfPCell splLicenseType = new PdfPCell(new Phrase("Special License Type: ", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    splLicenseType.Border = Rectangle.NO_BORDER;
                    splLicenseType.HorizontalAlignment = Element.ALIGN_RIGHT;
                    splLicenseType.VerticalAlignment = Element.ALIGN_CENTER;
                    rightColumnTable.AddCell(splLicenseType);
                    PdfPCell splLicenseTypeValue = new PdfPCell(new Phrase(permit.SpecialLicenseType, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                    splLicenseTypeValue.Border = Rectangle.NO_BORDER;
                    splLicenseTypeValue.HorizontalAlignment = Element.ALIGN_LEFT;
                    splLicenseTypeValue.VerticalAlignment = Element.ALIGN_CENTER;
                    rightColumnTable.AddCell(splLicenseTypeValue);

                    // ESI/Insurance Validity
                    PdfPCell esiValidity = new PdfPCell(new Phrase("ESI/Insurance Validity: ", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    esiValidity.Border = Rectangle.NO_BORDER;
                    esiValidity.HorizontalAlignment = Element.ALIGN_RIGHT;
                    esiValidity.VerticalAlignment = Element.ALIGN_CENTER;
                    rightColumnTable.AddCell(esiValidity);
                    PdfPCell esiValidityValue = new PdfPCell(new Phrase(permit.InsuranceValidity, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                    esiValidityValue.Border = Rectangle.NO_BORDER;
                    esiValidityValue.HorizontalAlignment = Element.ALIGN_LEFT;
                    esiValidityValue.VerticalAlignment = Element.ALIGN_CENTER;
                    rightColumnTable.AddCell(esiValidityValue);

                    // Number of workers
                    PdfPCell workerNo = new PdfPCell(new Phrase("Number of workers: ", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    workerNo.Border = Rectangle.NO_BORDER;
                    workerNo.HorizontalAlignment = Element.ALIGN_RIGHT;
                    workerNo.VerticalAlignment = Element.ALIGN_CENTER;
                    rightColumnTable.AddCell(workerNo);
                    PdfPCell workerNoValue = new PdfPCell(new Phrase(permit.WorkerNo, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                    workerNoValue.Border = Rectangle.NO_BORDER;
                    workerNoValue.HorizontalAlignment = Element.ALIGN_LEFT;
                    workerNoValue.VerticalAlignment = Element.ALIGN_CENTER;
                    rightColumnTable.AddCell(workerNoValue);

                    // Contact Number (Contractor)
                    PdfPCell contractorNo = new PdfPCell(new Phrase("Contact Number (Contractor): ", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    contractorNo.Border = Rectangle.NO_BORDER;
                    contractorNo.HorizontalAlignment = Element.ALIGN_RIGHT;
                    contractorNo.VerticalAlignment = Element.ALIGN_CENTER;
                    rightColumnTable.AddCell(contractorNo);
                    PdfPCell contractorNoValue = new PdfPCell(new Phrase(permit.ContractorNo, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                    contractorNoValue.Border = Rectangle.NO_BORDER;
                    contractorNoValue.HorizontalAlignment = Element.ALIGN_LEFT;
                    contractorNoValue.VerticalAlignment = Element.ALIGN_CENTER;
                    rightColumnTable.AddCell(contractorNoValue);

                    // Contact Number (Engineer)
                    PdfPCell engiNo = new PdfPCell(new Phrase("Contact Number (Engineer): ", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    engiNo.Border = Rectangle.NO_BORDER;
                    engiNo.HorizontalAlignment = Element.ALIGN_RIGHT;
                    engiNo.VerticalAlignment = Element.ALIGN_CENTER;
                    rightColumnTable.AddCell(engiNo);
                    PdfPCell engiNoValue = new PdfPCell(new Phrase(permit.EngineerNo, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                    engiNoValue.Border = Rectangle.NO_BORDER;
                    engiNoValue.HorizontalAlignment = Element.ALIGN_LEFT;
                    engiNoValue.VerticalAlignment = Element.ALIGN_CENTER;
                    rightColumnTable.AddCell(engiNoValue);

                    // Location of Work
                    PdfPCell location = new PdfPCell(new Phrase("Location of Work: ", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    location.Border = Rectangle.NO_BORDER;
                    location.HorizontalAlignment = Element.ALIGN_RIGHT;
                    location.VerticalAlignment = Element.ALIGN_CENTER;
                    rightColumnTable.AddCell(location);
                    PdfPCell locationValue = new PdfPCell(new Phrase(permit.EngineerNo, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                    locationValue.Border = Rectangle.NO_BORDER;
                    locationValue.HorizontalAlignment = Element.ALIGN_LEFT;
                    locationValue.VerticalAlignment = Element.ALIGN_CENTER;
                    rightColumnTable.AddCell(locationValue);

                    permitDetailsTable.AddCell(rightColumnTable);  // Add right column to main table
                    

                    PdfPCell emptycel1 = new PdfPCell(new Phrase("", FontFactory.GetFont(FontFactory.TIMES_BOLD, 9)));
                    emptycel1.Colspan = 2;  // Span across both main columns
                    emptyCell1.MinimumHeight = 30f;  // Set a minimum height for
                    emptycel1.Border = Rectangle.NO_BORDER;
                    permitDetailsTable.AddCell(emptycel1);

                    PdfPCell permitSelected = new PdfPCell(new Phrase("Job Sefty Assissment", FontFactory.GetFont(FontFactory.TIMES_BOLD, 13)));
                    permitSelected.Colspan = 2;
                    permitSelected.HorizontalAlignment = Element.ALIGN_RIGHT; // Align label to the right
                    permitSelected.VerticalAlignment = Element.ALIGN_CENTER; // Align label to the right
                    permitSelected.Border = Rectangle.NO_BORDER;
                    permitDetailsTable.AddCell(permitSelected);

                    string workPermits = permit.workPermits;
                    string[] parts = workPermits.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    // Trim each part to remove any leading or trailing whitespace
                    for (int i = 0; i < parts.Length; i++)
                    {
                        parts[i] = parts[i].Trim();
                    }

                    // Initialize variables to hold up to 8 parts
                    //string wp1 = parts.Length > 0 ? parts[0] : string.Empty;
                    //string wp2 = parts.Length > 1 ? parts[1] : string.Empty;
                    //string wp3 = parts.Length > 2 ? parts[2] : string.Empty;
                    //string wp4 = parts.Length > 3 ? parts[3] : string.Empty;
                    //string wp5 = parts.Length > 4 ? parts[4] : string.Empty;
                    //string wp6 = parts.Length > 5 ? parts[5] : string.Empty;
                    //string wp7 = parts.Length > 6 ? parts[6] : string.Empty;
                    //string wp8 = parts.Length > 7 ? parts[7] : string.Empty;


                    for(int i=0; i < parts.Length; i++)
                    {
                        PdfPCell permitSelectedValue = new PdfPCell(new Phrase(parts[i], FontFactory.GetFont(FontFactory.TIMES_ROMAN, 11)));
                        permitSelectedValue.Colspan = 2;
                        permitSelectedValue.HorizontalAlignment = Element.ALIGN_LEFT; // Align value to the left
                        permitSelectedValue.VerticalAlignment = Element.ALIGN_CENTER; // Align value to the left
                        permitSelectedValue.Border = Rectangle.NO_BORDER;
                        permitDetailsTable.AddCell(permitSelectedValue);
                    }

                    document.Add(permitDetailsTable);  // Add permit details to current page
                    document.NewPage();  // Start new page for worker details
                    PdfPTable workerDetails = new PdfPTable(11);    // workers details table

                    PdfPCell SrNo = new PdfPCell(new Phrase("Sr. No.", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    SrNo.HorizontalAlignment = Element.ALIGN_RIGHT;
                    SrNo.VerticalAlignment = Element.ALIGN_CENTER;
                    workerDetails.AddCell(SrNo);

                    PdfPCell WorkerName = new PdfPCell(new Phrase("Name Of Worker", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    WorkerName.HorizontalAlignment = Element.ALIGN_CENTER;
                    WorkerName.VerticalAlignment = Element.ALIGN_CENTER;
                    workerDetails.AddCell(WorkerName);

                    PdfPCell WorkerAge = new PdfPCell(new Phrase("Age", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    WorkerAge.HorizontalAlignment = Element.ALIGN_CENTER;
                    WorkerAge.VerticalAlignment = Element.ALIGN_CENTER;
                    workerDetails.AddCell(WorkerAge);

                    PdfPCell Mask = new PdfPCell(new Phrase("Mask", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    Mask.HorizontalAlignment = Element.ALIGN_CENTER;
                    Mask.VerticalAlignment = Element.ALIGN_CENTER;
                    workerDetails.AddCell(Mask);

                    PdfPCell Shoes = new PdfPCell(new Phrase("Safety Shoes/ GumBoots", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    Shoes.HorizontalAlignment = Element.ALIGN_CENTER;
                    Shoes.VerticalAlignment = Element.ALIGN_CENTER;
                    workerDetails.AddCell(Shoes);

                    PdfPCell Jacket = new PdfPCell(new Phrase("Jackets/ Aprons", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    Jacket.HorizontalAlignment = Element.ALIGN_CENTER;
                    Jacket.VerticalAlignment = Element.ALIGN_CENTER;
                    workerDetails.AddCell(Jacket);

                    PdfPCell Gloves = new PdfPCell(new Phrase("Gloves", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    Gloves.HorizontalAlignment = Element.ALIGN_CENTER;
                    Gloves.VerticalAlignment = Element.ALIGN_CENTER;
                    workerDetails.AddCell(Gloves);

                    PdfPCell Plug = new PdfPCell(new Phrase("Ear Plug/ Muffs", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    Plug.HorizontalAlignment = Element.ALIGN_CENTER;
                    Plug.VerticalAlignment = Element.ALIGN_CENTER;
                    workerDetails.AddCell(Plug);

                    PdfPCell Belt = new PdfPCell(new Phrase("Belt/ Harness", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    Belt.HorizontalAlignment = Element.ALIGN_CENTER;
                    Belt.VerticalAlignment = Element.ALIGN_CENTER;
                    workerDetails.AddCell(Belt);

                    PdfPCell Heltmet = new PdfPCell(new Phrase("Helmet", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    Heltmet.HorizontalAlignment = Element.ALIGN_CENTER;
                    Heltmet.VerticalAlignment = Element.ALIGN_CENTER;
                    workerDetails.AddCell(Heltmet);

                    PdfPCell Remark = new PdfPCell(new Phrase("Remark", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    Remark.HorizontalAlignment = Element.ALIGN_CENTER;
                    Remark.VerticalAlignment = Element.ALIGN_CENTER;
                    workerDetails.AddCell(Remark);

                    //PdfPCell Remark1 = new PdfPCell(new Phrase("Remarkhnjkad", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    //Remark1.HorizontalAlignment = Element.ALIGN_CENTER;
                    //Remark1.VerticalAlignment = Element.ALIGN_CENTER;
                    //permitDetailsTable.AddCell(Remark1);


                    List<PermitDetails> workerList = GetWorkerDetails(permit.PermitNumber);
                    if (workerList.Count > 0)
                    {
                        int i = 1;
                        // Iterate through worker details in the list
                        foreach (PermitDetails workerInfo in workerList)
                        {
                            PdfPCell srno = new PdfPCell(new Phrase(i.ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                            srno.HorizontalAlignment = Element.ALIGN_CENTER;
                            srno.VerticalAlignment = Element.ALIGN_CENTER;
                            workerDetails.AddCell(srno);
                            i++;

                            PdfPCell WorkerNameValue = new PdfPCell(new Phrase(workerInfo.workerName, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                            WorkerNameValue.HorizontalAlignment = Element.ALIGN_CENTER;
                            WorkerNameValue.VerticalAlignment = Element.ALIGN_CENTER;
                            workerDetails.AddCell(WorkerNameValue);

                            PdfPCell WorkerAgeValue = new PdfPCell(new Phrase(workerInfo.workerAge, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                            WorkerAgeValue.HorizontalAlignment = Element.ALIGN_CENTER;
                            WorkerAgeValue.VerticalAlignment = Element.ALIGN_CENTER;
                            workerDetails.AddCell(WorkerAgeValue);

                            PdfPCell MaskValue = new PdfPCell(new Phrase(workerInfo.maskIssued, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                            MaskValue.HorizontalAlignment = Element.ALIGN_CENTER;
                            MaskValue.VerticalAlignment = Element.ALIGN_CENTER;
                            workerDetails.AddCell(MaskValue);

                            PdfPCell ShoesValue = new PdfPCell(new Phrase(workerInfo.shoesIssued, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                            ShoesValue.HorizontalAlignment = Element.ALIGN_CENTER;
                            ShoesValue.VerticalAlignment = Element.ALIGN_CENTER;
                            workerDetails.AddCell(ShoesValue);

                            PdfPCell JacketValue = new PdfPCell(new Phrase(workerInfo.jacketIssued, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                            JacketValue.HorizontalAlignment = Element.ALIGN_CENTER;
                            JacketValue.VerticalAlignment = Element.ALIGN_CENTER;
                            workerDetails.AddCell(JacketValue);

                            PdfPCell GlovesValue = new PdfPCell(new Phrase(workerInfo.glovesIssued, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                            GlovesValue.HorizontalAlignment = Element.ALIGN_CENTER;
                            GlovesValue.VerticalAlignment = Element.ALIGN_CENTER;
                            workerDetails.AddCell(GlovesValue);

                            PdfPCell PlugValue = new PdfPCell(new Phrase(workerInfo.earplugIssued, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                            PlugValue.HorizontalAlignment = Element.ALIGN_CENTER;
                            PlugValue.VerticalAlignment = Element.ALIGN_CENTER;
                            workerDetails.AddCell(PlugValue);

                            PdfPCell BeltValue = new PdfPCell(new Phrase(workerInfo.beltIssued, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                            BeltValue.HorizontalAlignment = Element.ALIGN_CENTER;
                            BeltValue.VerticalAlignment = Element.ALIGN_CENTER;
                            workerDetails.AddCell(BeltValue);

                            PdfPCell HeltmetValue = new PdfPCell(new Phrase(workerInfo.helmetIssued, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                            HeltmetValue.HorizontalAlignment = Element.ALIGN_CENTER;
                            HeltmetValue.VerticalAlignment = Element.ALIGN_CENTER;
                            workerDetails.AddCell(HeltmetValue);

                            PdfPCell RemarkValue = new PdfPCell(new Phrase(workerInfo.Rejected_Remark, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)));
                            RemarkValue.HorizontalAlignment = Element.ALIGN_CENTER;
                            RemarkValue.VerticalAlignment = Element.ALIGN_CENTER;
                            workerDetails.AddCell(RemarkValue);
                        }
                    }
                    else
                    {
                        PdfPCell noWorkerCell = new PdfPCell(new Phrase("No Worker Details Found", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                        noWorkerCell.Colspan = 11; // Span across all columns
                        noWorkerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        noWorkerCell.VerticalAlignment = Element.ALIGN_CENTER;
                        workerDetails.AddCell(noWorkerCell);
                    }

                    document.Add(workerDetails);
                    document.Add(Chunk.NEWLINE);  // Add some space between permits
                }
                document.Close();
            }
        }
    }
}