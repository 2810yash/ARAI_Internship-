using OfficeOpenXml;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{

    public class PermitDetails2
    {
        public string incident_id { get; set; }
        public string date_of_incident { get; set; }
        public string time_of_incident { get; set; }
        public string name_of_affected_person { get; set; }
        public string name_of_department { get; set; }
        public string location_of_incident { get; set; }
        public string nature_of_incident { get; set; }
        public string drop_down_1 { get; set; }
        public string drop_down_2 { get; set; }
        public string drop_down_3 { get; set; }
        public string drop_down_4 { get; set; }
        public string drop_down_5 { get; set; }
        public string drop_down_6 { get; set; }
        public string describe_incident { get; set; }
        public string immediate_action { get; set; }
        public string hazard_study { get; set; }
        public string FName { get; set; }
        public string FExtension { get; set; }
        public string FilePath { get; set; }
        public string CreatedDate { get; set; }
        public string remarks { get; set; }
        public string IPAddress { get; set; }
        public string root_cause_1 { get; set; }
        public string root_cause_2 { get; set; }
        public string root_cause_3 { get; set; }
        public string root_cause_4 { get; set; }
        public string root_cause_5 { get; set; }
        public string corrective_action_1 { get; set; }
        public string corrective_action_2 { get; set; }
        public string corrective_action_3 { get; set; }
        public string responsible_person_1 { get; set; }
        public string responsible_person_2 { get; set; }
        public string responsible_person_3 { get; set; }
        public string date_of_completion_1 { get; set; }
        public string date_of_completion_2 { get; set; }
        public string date_of_completion_3 { get; set; }

    }
    public partial class viewReport : System.Web.UI.Page
    {
        string Main_con = ConfigurationManager.ConnectionStrings["accidentConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchtxt = txtSearch.Value.Trim();

            // Construct the SQL query
            string query = "SELECT incident_id, name_of_affected_person, date_of_incident, name_of_department FROM accident_incident WHERE ";

            // Check if search text is provided
            if (!string.IsNullOrEmpty(searchtxt))
            {
                query += "incident_id LIKE '%' + @searchQuery + '%' OR name_of_department LIKE '%' + @searchQuery + '%'";
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
                    //Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                }
            }
        }

        private PermitDetails2 GetPermitDetailsByNumber(string incident_id)
        {
            PermitDetails2 permitDetails = null;
            string query = @"
            SELECT 
            incident_id, 
            date_of_incident,
            time_of_incident,
            name_of_affected_person, name_of_department, location_of_incident, nature_of_incident, drop_down_1, drop_down_2, drop_down_3, drop_down_4, drop_down_5, drop_down_6, describe_incident, immediate_action, hazard_study, FName, FExtension, FilePath, CreatedDate, remarks, IPAddress, root_cause_1, root_cause_2, root_cause_3, root_cause_4, root_cause_5, corrective_action_1, corrective_action_2, corrective_action_3, responsible_person_1, responsible_person_2, responsible_person_3, date_of_completion_1, date_of_completion_2, date_of_completion_3
            FROM accident_incident 
            WHERE incident_id = @incident_id";

            using (SqlConnection con = new SqlConnection(Main_con))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@incident_id", incident_id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            permitDetails = new PermitDetails2
                            {
                                incident_id = reader["incident_id"].ToString(),
                                date_of_incident = reader["date_of_incident"].ToString(),
                                time_of_incident = reader["time_of_incident"].ToString(),
                                name_of_affected_person = reader["name_of_affected_person"].ToString(),
                                name_of_department = reader["name_of_department"].ToString(),
                                location_of_incident = reader["location_of_incident"].ToString(),
                                nature_of_incident = reader["nature_of_incident"].ToString(),
                                drop_down_1 = reader["drop_down_1"].ToString(),
                                drop_down_2 = reader["drop_down_2"].ToString(),
                                drop_down_3 = reader["drop_down_3"].ToString(),
                                drop_down_4 = reader["drop_down_4"].ToString(),
                                drop_down_5 = reader["drop_down_5"].ToString(),
                                drop_down_6 = reader["drop_down_6"].ToString(),
                                describe_incident = reader["describe_incident"].ToString(),
                                immediate_action = reader["immediate_action"].ToString(),
                                hazard_study = reader["hazard_study"].ToString(),
                                FName = reader["FName"].ToString(),
                                FExtension = reader["FExtension"].ToString(),
                                FilePath = reader["FilePath"].ToString(),
                                CreatedDate = reader["CreatedDate"].ToString(),
                                remarks = reader["remarks"].ToString(),
                                IPAddress = reader["IPAddress"].ToString(),
                                root_cause_1 = reader["root_cause_1"].ToString(),
                                root_cause_2 = reader["root_cause_2"].ToString(),
                                root_cause_3 = reader["root_cause_3"].ToString(),
                                root_cause_4 = reader["root_cause_4"].ToString(),
                                root_cause_5 = reader["root_cause_5"].ToString(),
                                corrective_action_1 = reader["corrective_action_1"].ToString(),
                                corrective_action_2 = reader["corrective_action_2"].ToString(),
                                corrective_action_3 = reader["corrective_action_3"].ToString(),
                                responsible_person_1 = reader["responsible_person_1"].ToString(),
                                responsible_person_2 = reader["responsible_person_2"].ToString(),
                                responsible_person_3 = reader["responsible_person_3"].ToString(),
                                date_of_completion_1 = reader["date_of_completion_1"].ToString(),
                                date_of_completion_2 = reader["date_of_completion_2"].ToString(),
                                date_of_completion_3 = reader["date_of_completion_3"].ToString(),
                            };
                        }
                    }
                }

                return permitDetails;
            }

        }

        protected void deleteReport(object sender, CommandEventArgs e)
        {
            string incident_id = e.CommandArgument.ToString();

            string connectionString = ConfigurationManager.ConnectionStrings["accidentConnectionString"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                Response.Write("<script>alert('Connection to Database failed');</script>");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("delete_accident", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@incident_id", incident_id);

                        cmd.ExecuteNonQuery();
                        conn.Close();

                        string script = "<script>alert('Report Deleted Successfully');</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
                    }
                }

                string script2 = "<script>window.location='viewReport.aspx';</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "redirect", script2);

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "');</script>");
            }

        }
        protected void DisplayPermitDetails(PermitDetails2 details)
        {
            if (details != null)
            {
                string detailsJson = Newtonsoft.Json.JsonConvert.SerializeObject(details);
                string script = $"showPermitDetails({detailsJson});";
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowDetailsScript", script, true);
            }
        }

        protected void Download_Click(object sender, CommandEventArgs e)
        {
            try
            {
                string incident_id = e.CommandArgument.ToString();
                string filePath = GetPermitDetailsByNumber(incident_id).FilePath;
                string fileName = GetPermitDetailsByNumber(incident_id).FName;
                if (File.Exists(filePath))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", $"attachment; filename={fileName}");
                    Response.TransmitFile(filePath);
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert('no file found');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "');</script>");
            }

        }

        protected void Excel_Click(object sender, CommandEventArgs e)
        {
            try
            {
                string incident_id = e.CommandArgument.ToString();
                PermitDetails2 values = GetPermitDetailsByNumber(incident_id);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                string directory_path = @"D:\Uploads\";
                string file_name = $"IncidentReport_{incident_id}.xlsx";
                string file_path = Path.Combine(directory_path, file_name);
                if (!Directory.Exists(directory_path))
                {
                    Directory.CreateDirectory(directory_path);
                }
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");


                    worksheet.Cells[1, 1].Value = "Incident ID";
                    worksheet.Cells[1, 2].Value = "Date of Incident";
                    worksheet.Cells[1, 3].Value = "Time of Incident";
                    worksheet.Cells[1, 4].Value = "Date of Creation";
                    worksheet.Cells[1, 5].Value = "Name of Affected Person";
                    worksheet.Cells[1, 6].Value = "Name of Department";
                    worksheet.Cells[1, 7].Value = "Location of Incident";
                    worksheet.Cells[1, 8].Value = "Nature of Incident";
                    worksheet.Cells[1, 9].Value = "Drop Down 1";
                    worksheet.Cells[1, 10].Value = "Drop Down 2";
                    worksheet.Cells[1, 11].Value = "Drop Down 3";
                    worksheet.Cells[1, 12].Value = "Drop Down 4";
                    worksheet.Cells[1, 13].Value = "Drop Down 5";
                    worksheet.Cells[1, 14].Value = "Drop Down 6";
                    worksheet.Cells[1, 15].Value = "Describe Incident";
                    worksheet.Cells[1, 16].Value = "Immediate Action Taken";
                    worksheet.Cells[1, 17].Value = "Hazard Study";
                    worksheet.Cells[1, 18].Value = "File Name";
                    worksheet.Cells[1, 19].Value = "Remarks";
                    worksheet.Cells[1, 20].Value = "IPAddress";
                    worksheet.Cells[1, 21].Value = "Root Cause 1";
                    worksheet.Cells[1, 22].Value = "Root Cause 2";
                    worksheet.Cells[1, 23].Value = "Root Cause 3";
                    worksheet.Cells[1, 24].Value = "Root Cause 4";
                    worksheet.Cells[1, 25].Value = "Root Cause 5";
                    worksheet.Cells[1, 26].Value = "Corrective Action 1";
                    worksheet.Cells[1, 27].Value = "Corrective Action 2";
                    worksheet.Cells[1, 28].Value = "Corrective Action 3";
                    worksheet.Cells[1, 29].Value = "Responsible Person 1";
                    worksheet.Cells[1, 30].Value = "Responsible Person 2";
                    worksheet.Cells[1, 31].Value = "Responsible Person 3";
                    worksheet.Cells[1, 32].Value = "Date of Completion 1";
                    worksheet.Cells[1, 33].Value = "Date of Completion 2";
                    worksheet.Cells[1, 34].Value = "Date of Completion 3";



                    worksheet.Cells[2, 1].Value = incident_id;
                    worksheet.Cells[2, 2].Value = values.date_of_incident;
                    worksheet.Cells[2, 3].Value = values.time_of_incident;
                    worksheet.Cells[2, 4].Value = values.CreatedDate;
                    worksheet.Cells[2, 5].Value = values.name_of_affected_person;
                    worksheet.Cells[2, 6].Value = values.name_of_department;
                    worksheet.Cells[2, 7].Value = values.location_of_incident;
                    worksheet.Cells[2, 8].Value = values.nature_of_incident;
                    worksheet.Cells[2, 9].Value = values.drop_down_1;
                    worksheet.Cells[2, 10].Value = values.drop_down_2;
                    worksheet.Cells[2, 11].Value = values.drop_down_3;
                    worksheet.Cells[2, 12].Value = values.drop_down_4;
                    worksheet.Cells[2, 13].Value = values.drop_down_5;
                    worksheet.Cells[2, 14].Value = values.drop_down_6;
                    worksheet.Cells[2, 15].Value = values.describe_incident;
                    worksheet.Cells[2, 16].Value = values.immediate_action;
                    worksheet.Cells[2, 17].Value = values.hazard_study;
                    worksheet.Cells[2, 18].Value = values.FName;
                    worksheet.Cells[2, 19].Value = values.remarks;
                    worksheet.Cells[2, 20].Value = values.IPAddress;
                    worksheet.Cells[2, 21].Value = values.root_cause_1;
                    worksheet.Cells[2, 22].Value = values.root_cause_2;
                    worksheet.Cells[2, 23].Value = values.root_cause_3;
                    worksheet.Cells[2, 24].Value = values.root_cause_4;
                    worksheet.Cells[2, 25].Value = values.root_cause_5;
                    worksheet.Cells[2, 26].Value = values.corrective_action_1;
                    worksheet.Cells[2, 27].Value = values.corrective_action_2;
                    worksheet.Cells[2, 28].Value = values.corrective_action_3;
                    worksheet.Cells[2, 29].Value = values.responsible_person_1;
                    worksheet.Cells[2, 30].Value = values.responsible_person_2;
                    worksheet.Cells[2, 31].Value = values.responsible_person_3;
                    worksheet.Cells[2, 32].Value = values.date_of_completion_1;
                    worksheet.Cells[2, 33].Value = values.date_of_completion_2;
                    worksheet.Cells[2, 34].Value = values.date_of_completion_3;




                    // Save the Excel file
                    var file = new FileInfo(file_path);
                    package.SaveAs(file);

                    Response.Write("<script>alert('Data Successfully exported');</script>");
                }




            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "');</script>");
            }
        }

        protected void EditReport_Click(object sender, CommandEventArgs e)
        {
            string incident_id = e.CommandArgument.ToString();
            Session["incident_id"] = incident_id;
            Response.Redirect("EditReport.aspx");
        }

        protected void ViewPermit_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                string permitNumber = e.CommandArgument.ToString();
                var incident_id = GetPermitDetailsByNumber(permitNumber);

                if (incident_id != null)
                {
                    DisplayPermitDetails(incident_id);
                }
            }
        }
    }

}