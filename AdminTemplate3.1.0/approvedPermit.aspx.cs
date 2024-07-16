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
            if (Session["LoginID"]!=null && Session["DeptName"] != null && Session["DeptCode"] != null && Session["RoleID"] != null)
            {
                loginID = Session["LoginID"].ToString();
                deptName = Session["DeptName"].ToString();
                deptCode = (int)Session["DeptCode"];
                roleID = (int)Session["RoleID"];
            }
            else
            {
                Response.Redirect("login.aspx");
            }

            JSAContainers.Visible = false;

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
        protected void EditViewPermit_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "EditDetails")
            {
                string permitNum = e.CommandArgument.ToString();
                Session["PermitNumber"] = permitNum;
                Response.Redirect("editPermitForm.aspx");
            }
        }
        protected void downloadFile_Click(object sender, CommandEventArgs e)
        {
            if(e.CommandName== "DownloadFile")
            {
                string filePath = e.CommandArgument.ToString();
                Process.Start(filePath);
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

                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error Occured: '" + ex + "'. Please try again!');</script>");
                }

            }
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

        static void AddEmptyCell(PdfPTable table, int colspan, float fixedHeight)
        {
            PdfPCell emptyCell = new PdfPCell(new Phrase(" "));
            emptyCell.Colspan = colspan;
            emptyCell.FixedHeight = fixedHeight;
            emptyCell.Border = Rectangle.NO_BORDER;
            table.AddCell(emptyCell);
        }
        static void AddLabeledCell(PdfPTable table, string label, string value, float fontSize, bool addBorders = true)
        {
            table.AddCell(new PdfPCell(new Phrase(label, FontFactory.GetFont(FontFactory.TIMES_BOLD, fontSize)))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT,
                VerticalAlignment = Element.ALIGN_CENTER,
                Border = addBorders ? Rectangle.BOX : Rectangle.NO_BORDER
            });
            table.AddCell(new PdfPCell(new Phrase(value, FontFactory.GetFont(FontFactory.TIMES_ROMAN, fontSize)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_CENTER,
                Border = addBorders ? Rectangle.BOX : Rectangle.NO_BORDER
            });
        }
        static void AddJSAHeaderCell(PdfPTable table, string header)
        {
            table.AddCell(new PdfPCell(new Phrase(header, FontFactory.GetFont(FontFactory.TIMES_BOLD, 12)))
            {
                Border = Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_CENTER
            });
        }
        static void AddHeaderCell(PdfPTable table, string header)
        {
            table.AddCell(new PdfPCell(new Phrase(header, FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_CENTER
            });
        }
        static void AddWorkerDataCell(PdfPTable table, string data)
        {
            table.AddCell(new PdfPCell(new Phrase(data, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10)))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_CENTER
            });
        }
        static void AddTextCell(PdfPTable table, string text, float fontSize)
        {
            PdfPCell textCell = new PdfPCell(new Phrase(text, FontFactory.GetFont(FontFactory.TIMES_ROMAN, fontSize)))
            {
                Colspan = 2,
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_CENTER,
                Border = Rectangle.NO_BORDER
            };
            table.AddCell(textCell);
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
                    PdfPCell titleCell = new PdfPCell(new Phrase("Work Permit", FontFactory.GetFont(FontFactory.TIMES_BOLD, 16)));
                    titleCell.Colspan = 2;  // Span across both main columns
                    titleCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    titleCell.VerticalAlignment = Element.ALIGN_CENTER;
                    titleCell.Border = Rectangle.NO_BORDER;
                    permitDetailsTable.AddCell(titleCell);

                    // Adding empty space
                    AddEmptyCell(permitDetailsTable, 2, 30f);

                    // Site Name
                    PdfPCell siteName = new PdfPCell(new Phrase(permit.SiteName, FontFactory.GetFont(FontFactory.TIMES_BOLD, 12)));
                    siteName.Colspan = 2;  // Span across both main columns
                    siteName.HorizontalAlignment = Element.ALIGN_CENTER;
                    siteName.VerticalAlignment = Element.ALIGN_CENTER;
                    siteName.Border = Rectangle.NO_BORDER;
                    permitDetailsTable.AddCell(siteName);

                    // Adding empty space
                    AddEmptyCell(permitDetailsTable, 2, 10f);

                    // Security check text
                    AddTextCell(permitDetailsTable, "* Security shall check work permit and allow workers to enter with valid work permit in case of below mentioned works. *", 9);
                    AddTextCell(permitDetailsTable, "* Work permit to be filled by contractor in consultation with ARAI officials(of work intending dept.) *", 9);
                    AddTextCell(permitDetailsTable, "* Work on Saturday/Sunday & holidays will be under strict supervision of work intending departments. *", 9);

                    // Adding empty space
                    AddEmptyCell(permitDetailsTable, 2, 10f);

                    // Date of Issue
                    PdfPCell issueDate = new PdfPCell(new Phrase("Date of Issue: " + permit.DateofIssue, FontFactory.GetFont(FontFactory.TIMES_BOLD, 10)));
                    issueDate.Colspan = 2;  // Span across both main columns
                    issueDate.HorizontalAlignment = Element.ALIGN_RIGHT;
                    issueDate.VerticalAlignment = Element.ALIGN_CENTER;
                    issueDate.Border = Rectangle.NO_BORDER;
                    permitDetailsTable.AddCell(issueDate);

                    // Adding empty space
                    AddEmptyCell(permitDetailsTable, 2, 10f);

                    // Permit Number
                    AddLabeledCell(permitDetailsTable, "Permit Number:", permit.PermitNumber, 10);

                    // Left column (nested two columns)
                    PdfPTable leftColumnTable = new PdfPTable(2);  // Two columns for left side
                    AddLabeledCell(leftColumnTable, "Permit Valid From:", permit.PermitValidFrom.Date.ToString(), 10, false);
                    AddLabeledCell(leftColumnTable, "Special License:", permit.SpecialLicense, 10, false);
                    AddLabeledCell(leftColumnTable, "ESI/Insurance No:", permit.InsuranceNo, 10, false);
                    AddLabeledCell(leftColumnTable, "Name of Vendor or Contractor Firm/Agency:", permit.AgencyName, 10, false);
                    AddLabeledCell(leftColumnTable, "Name of Vendor/Contractor Supervisor:", permit.ContractorName, 10, false);
                    AddLabeledCell(leftColumnTable, "ARAI Engineer:", permit.EngineerName, 10, false);
                    AddLabeledCell(leftColumnTable, "Brief Description of Work:", permit.Description, 10, false);
                    permitDetailsTable.AddCell(leftColumnTable);  // Add left column to main table

                    // Right column (nested two columns)
                    PdfPTable rightColumnTable = new PdfPTable(2);  // Two columns for right side
                    AddLabeledCell(rightColumnTable, "Permit Valid Till:", permit.PermitValidTill.Date.ToString(), 10, false);
                    AddLabeledCell(rightColumnTable, "Special License Type:", permit.SpecialLicenseType, 10, false);
                    AddLabeledCell(rightColumnTable, "ESI/Insurance Validity:", permit.InsuranceValidity, 10, false);
                    AddLabeledCell(rightColumnTable, "Number of workers:", permit.WorkerNo, 10, false);
                    AddLabeledCell(rightColumnTable, "Contact Number (Contractor):", permit.ContractorNo, 10, false);
                    AddLabeledCell(rightColumnTable, "Contact Number (Engineer):", permit.EngineerNo, 10, false);
                    AddLabeledCell(rightColumnTable, "Location of Work:", permit.Location, 10, false);
                    permitDetailsTable.AddCell(rightColumnTable);  // Add right column to main table

                    // Adding empty space
                    AddEmptyCell(permitDetailsTable, 2, 30f);

                    // Job Safety Assessment
                    PdfPCell permitSelected = new PdfPCell(new Phrase("Job Safety Assessment", FontFactory.GetFont(FontFactory.TIMES_BOLD, 13)));
                    permitSelected.Colspan = 2;
                    permitSelected.HorizontalAlignment = Element.ALIGN_LEFT; // Align label to the left
                    permitSelected.VerticalAlignment = Element.ALIGN_CENTER; // Align label to the center
                    permitSelected.Border = Rectangle.NO_BORDER;
                    permitDetailsTable.AddCell(permitSelected);

                    string workPermits = permit.workPermits;
                    string[] parts = workPermits.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    // Trim each part to remove any leading or trailing whitespace
                    for (int i = 0; i < parts.Length; i++)
                    {
                        parts[i] = parts[i].Trim();
                    }

                    for (int i = 0; i < parts.Length; i++)
                    {
                        PdfPCell permitSelectedValue = new PdfPCell(new Phrase(parts[i], FontFactory.GetFont(FontFactory.TIMES_ROMAN, 11)));
                        permitSelectedValue.Colspan = 2;
                        permitSelectedValue.HorizontalAlignment = Element.ALIGN_LEFT; // Align value to the left
                        permitSelectedValue.VerticalAlignment = Element.ALIGN_CENTER; // Align value to the left
                        permitSelectedValue.Border = Rectangle.NO_BORDER;
                        permitDetailsTable.AddCell(permitSelectedValue);
                    }

                    // Adding empty space
                    AddEmptyCell(permitDetailsTable, 2, 30f);

                    // Hazards and Precautions
                    PdfPTable hazardsAndAll = new PdfPTable(3);
                    AddJSAHeaderCell(hazardsAndAll, "Hazards:");
                    AddJSAHeaderCell(hazardsAndAll, "Precautions:");
                    AddJSAHeaderCell(hazardsAndAll, "PPE's:");

                    PdfPTable hazards = new PdfPTable(1);
                    PdfPTable precautions = new PdfPTable(1);
                    PdfPTable ppe = new PdfPTable(1);

                    // lists named hazards, precautions, and ppes
                    List<List<string>> HazardsAndAll = GetJSAData(permit.PermitNumber);
                    //int rowCount = HazardsAndAll.hazards.Count;
                    try
                    {
                        for (int i = 0; i < HazardsAndAll[0].Count; i++)
                        {
                            PdfPCell hazardCell = new PdfPCell(new Phrase(HazardsAndAll[0][i])) { Border = Rectangle.BOTTOM_BORDER, HorizontalAlignment = Element.ALIGN_CENTER };
                            hazards.AddCell(hazardCell);
                        }
                        for (int i = 0; i < HazardsAndAll[1].Count; i++)
                        {
                            PdfPCell precautionCell = new PdfPCell(new Phrase(HazardsAndAll[1][i])) { Border = Rectangle.BOTTOM_BORDER, HorizontalAlignment = Element.ALIGN_CENTER };
                            precautions.AddCell(precautionCell);
                        }
                        for (int i = 0; i < HazardsAndAll[2].Count; i++)
                        {
                            PdfPCell ppeCell = new PdfPCell(new Phrase(HazardsAndAll[2][i])) { Border = Rectangle.BOTTOM_BORDER, HorizontalAlignment = Element.ALIGN_CENTER };
                            ppe.AddCell(ppeCell);
                        }
                        hazardsAndAll.AddCell(hazards);
                        hazardsAndAll.AddCell(precautions);
                        hazardsAndAll.AddCell(ppe);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("<script>alert('Error Occured: '" + ex + "'. Please try again!');</script>");
                    }

                    //permitDetailsTable.AddCell(hazardsAndAll);
                    document.Add(permitDetailsTable);
                    document.Add(hazardsAndAll);


                    // Start new page for worker details
                    document.NewPage();
                    PdfPTable workerDetails = new PdfPTable(11);    // workers details table

                    AddHeaderCell(workerDetails, "Sr. No.");
                    AddHeaderCell(workerDetails, "Name Of Worker");
                    AddHeaderCell(workerDetails, "Age");
                    AddHeaderCell(workerDetails, "Mask");
                    AddHeaderCell(workerDetails, "Safety Shoes/ GumBoots");
                    AddHeaderCell(workerDetails, "Jackets/ Aprons");
                    AddHeaderCell(workerDetails, "Gloves");
                    AddHeaderCell(workerDetails, "Ear Plug/ Muffs");
                    AddHeaderCell(workerDetails, "Belt/ Harness");
                    AddHeaderCell(workerDetails, "Helmet");
                    AddHeaderCell(workerDetails, "Remark");

                    List<PermitDetails> workerList = GetWorkerDetails(permit.PermitNumber);
                    if (workerList.Count > 0)
                    {
                        int i = 1;
                        // Iterate through worker details in the list
                        foreach (PermitDetails workerInfo in workerList)
                        {
                            AddWorkerDataCell(workerDetails, i.ToString());
                            i++;
                            AddWorkerDataCell(workerDetails, workerInfo.workerName);
                            AddWorkerDataCell(workerDetails, workerInfo.workerAge);
                            AddWorkerDataCell(workerDetails, workerInfo.maskIssued);
                            AddWorkerDataCell(workerDetails, workerInfo.shoesIssued);
                            AddWorkerDataCell(workerDetails, workerInfo.jacketIssued);
                            AddWorkerDataCell(workerDetails, workerInfo.glovesIssued);
                            AddWorkerDataCell(workerDetails, workerInfo.earplugIssued);
                            AddWorkerDataCell(workerDetails, workerInfo.beltIssued);
                            AddWorkerDataCell(workerDetails, workerInfo.helmetIssued);
                            AddWorkerDataCell(workerDetails, workerInfo.Rejected_Remark);
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

                    document.Add(workerDetails);  // Add worker details to new page
                }
                document.Close();
            }
        }
        public static List<List<string>> GetJSAData(string permitNum)
        {
            string Main_con = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
            List<List<string>> HazardsAndAll = new List<List<string>>();
            string permitNumber = permitNum;
            string workPermits;

            using (SqlConnection con = new SqlConnection(Main_con))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("usp_fetchWorkPermits", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PermitNumber", permitNumber);
                        command.Parameters.Add("@WorkPermits", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;

                        con.Open();
                        command.ExecuteNonQuery();
                        workPermits = command.Parameters["@WorkPermits"].Value.ToString();
                        con.Close();
                    }

                    string[] parts = workPermits.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < parts.Length; i++)
                    {
                        parts[i] = parts[i].Trim();
                    }

                    string wp1 = parts.Length > 0 ? parts[0] : string.Empty;
                    string wp2 = parts.Length > 1 ? parts[1] : string.Empty;
                    string wp3 = parts.Length > 2 ? parts[2] : string.Empty;
                    string wp4 = parts.Length > 3 ? parts[3] : string.Empty;
                    string wp5 = parts.Length > 4 ? parts[4] : string.Empty;
                    string wp6 = parts.Length > 5 ? parts[5] : string.Empty;
                    string wp7 = parts.Length > 6 ? parts[7] : string.Empty;
                    string wp8 = parts.Length > 7 ? parts[8] : string.Empty;


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

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<string> hazards = new List<string>();
                            while (reader.Read())
                            {
                                hazards.Add(reader[0].ToString());  //Hazards List 
                            }
                            HazardsAndAll.Add(hazards);

                            reader.NextResult();

                            List<string> precautions = new List<string>();
                            while (reader.Read())
                            {
                                precautions.Add(reader[0].ToString());  //Precaution List 
                            }
                            HazardsAndAll.Add(precautions);

                            reader.NextResult();

                            List<string> ppes = new List<string>();
                            while (reader.Read())
                            {
                                ppes.Add(reader[0].ToString()); //PPEs List 
                            }
                            HazardsAndAll.Add(ppes);
                        }
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("<script>alert('Error Occured: '" + ex + "'. Please try again!');</script>");
                }
            }
            return HazardsAndAll;
        }
    }
}