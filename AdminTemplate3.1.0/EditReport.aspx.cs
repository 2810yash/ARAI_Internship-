using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public partial class EditReport : System.Web.UI.Page
    {
        string incident_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadIncidentID();
            loadFormData();
        }
        private void loadIncidentID()
        {
            // Retrieve the incident_id from the session
            incident_id = Session["incident_id"] as string;

            // If incident_id is null or empty, handle it accordingly
            if (string.IsNullOrEmpty(incident_id))
            {
                // Handle the case when incident_id is not available, e.g., redirect to an error page or display a message
                Response.Redirect("viewReport.aspx");
            }
        }

        private void loadFormData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["accidentConnectionString"].ConnectionString;
            string storedProcedureName = "GetAccidentIncidentById";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", incident_id);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            date_of_incident.Text = reader["date_of_incident"] != DBNull.Value ? Convert.ToDateTime(reader["date_of_incident"]).ToString("yyyy-MM-dd") : "";
                            time_of_incident.Text = reader["time_of_incident"] != DBNull.Value ? reader["time_of_incident"].ToString() : "";
                            name_of_affected_person.Text = reader["name_of_affected_person"] != DBNull.Value ? reader["name_of_affected_person"].ToString() : "";
                            name_of_department.SelectedValue = reader["name_of_department"] != DBNull.Value ? reader["name_of_department"].ToString() : "";
                            location_of_incident.Text = reader["location_of_incident"] != DBNull.Value ? reader["location_of_incident"].ToString() : "";
                            nature_of_incident.SelectedValue = reader["nature_of_incident"] != DBNull.Value ? reader["nature_of_incident"].ToString() : "";
                            drop_down_1.SelectedValue = reader["drop_down_1"] != DBNull.Value ? reader["drop_down_1"].ToString() : "";
                            drop_down_2.SelectedValue = reader["drop_down_2"] != DBNull.Value ? reader["drop_down_2"].ToString() : "";
                            drop_down_3.SelectedValue = reader["drop_down_3"] != DBNull.Value ? reader["drop_down_3"].ToString() : "";
                            drop_down_4.SelectedValue = reader["drop_down_4"] != DBNull.Value ? reader["drop_down_4"].ToString() : "";
                            drop_down_5.SelectedValue = reader["drop_down_5"] != DBNull.Value ? reader["drop_down_5"].ToString() : "";
                            drop_down_6.SelectedValue = reader["drop_down_6"] != DBNull.Value ? reader["drop_down_6"].ToString() : "";
                            describe_incident.Text = reader["describe_incident"] != DBNull.Value ? reader["describe_incident"].ToString() : "";
                            immediate_action.Text = reader["immediate_action"] != DBNull.Value ? reader["immediate_action"].ToString() : "";
                            remarks.Text = reader["remarks"] != DBNull.Value ? reader["remarks"].ToString() : "";
                            root1.Text = reader["root_cause_1"] != DBNull.Value ? reader["root_cause_1"].ToString() : "";
                            root2.Text = reader["root_cause_2"] != DBNull.Value ? reader["root_cause_2"].ToString() : "";
                            root3.Text = reader["root_cause_3"] != DBNull.Value ? reader["root_cause_3"].ToString() : "";
                            root4.Text = reader["root_cause_4"] != DBNull.Value ? reader["root_cause_4"].ToString() : "";
                            root5.Text = reader["root_cause_5"] != DBNull.Value ? reader["root_cause_5"].ToString() : "";
                            corrective1.Text = reader["corrective_action_1"] != DBNull.Value ? reader["corrective_action_1"].ToString() : "";
                            corrective2.Text = reader["corrective_action_2"] != DBNull.Value ? reader["corrective_action_2"].ToString() : "";
                            corrective3.Text = reader["corrective_action_3"] != DBNull.Value ? reader["corrective_action_3"].ToString() : "";
                            resp1.Text = reader["responsible_person_1"] != DBNull.Value ? reader["responsible_person_1"].ToString() : "";
                            resp2.Text = reader["responsible_person_2"] != DBNull.Value ? reader["responsible_person_2"].ToString() : "";
                            resp3.Text = reader["responsible_person_3"] != DBNull.Value ? reader["responsible_person_3"].ToString() : "";
                            date1.Text = reader["date_of_completion_1"] != DBNull.Value ? Convert.ToDateTime(reader["date_of_completion_1"]).ToString("yyyy-MM-dd") : "";
                            date2.Text = reader["date_of_completion_2"] != DBNull.Value ? Convert.ToDateTime(reader["date_of_completion_2"]).ToString("yyyy-MM-dd") : "";
                            date3.Text = reader["date_of_completion_3"] != DBNull.Value ? Convert.ToDateTime(reader["date_of_completion_3"]).ToString("yyyy-MM-dd") : "";

                            string hazardStudy = reader["hazard_study"] != DBNull.Value ? reader["hazard_study"].ToString() : "";
                            if (hazardStudy == "Yes")
                            {
                                RadioYes.Checked = true;
                            }
                            else if (hazardStudy == "No")
                            {
                                RadioNo.Checked = true;
                            }
                        }
                        else
                        {
                            // Handle case where no record is found
                            Response.Redirect("HomePage2.aspx");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "');</script>");
                }
            }
        }

        private string GetClientIpAddress()
        {
            string ipAddress = HttpContext.Current.Request.UserHostAddress;

            // Check for X-Forwarded-For header for cases where the server is behind a proxy
            string xForwardedFor = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(xForwardedFor))
            {
                string[] ipAddresses = xForwardedFor.Split(',');
                if (ipAddresses.Length > 0)
                {
                    ipAddress = ipAddresses[0];
                }
            }

            // Handle IPv6 loopback address (::1) for local testing
            if (ipAddress == "::1")
            {
                ipAddress = "127.0.0.1";
            }

            return ipAddress;
        }



        protected void submitForm(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["accidentConnectionString"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                StatusLabel.Text = "Database connection string is not set.";
                Response.Write("<script>alert('no db connection');</script>");
                return;
            }


            //DateTime dateofIncident = date_of_incident;


            try
            {
                string filename = "NULL";
                string extension = "NULL";
                string customUploadPath = "NULL";
                string savePath = "NULL";
                DateTime now = DateTime.Now;

                if (FileUpload1.HasFile)
                {
                    filename = Path.GetFileName(FileUpload1.FileName);
                    extension = Path.GetExtension(FileUpload1.FileName);
                    customUploadPath = @"D:\Uploads\";


                    // Ensure the custom directory exists
                    if (!Directory.Exists(customUploadPath))
                    {
                        Directory.CreateDirectory(customUploadPath);
                    }

                    savePath = Path.Combine(customUploadPath, filename);

                    // Save the file to the specified path
                    FileUpload1.SaveAs(savePath);
                }

                // Get the client's IP address
                string ipAddress = GetClientIpAddress();

                // Extract the selected value from the radio buttons
                string hazardStudy = RadioYes.Checked ? "Yes" : "No";

                // Insert file metadata into the database



                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("update_accident", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@incident_id", incident_id);
                        cmd.Parameters.AddWithValue("@date_of_incident", date_of_incident.Text.Trim());
                        cmd.Parameters.AddWithValue("@time_of_incident", time_of_incident.Text.Trim());
                        cmd.Parameters.AddWithValue("@name_of_affected_person", name_of_affected_person.Text.Trim());
                        cmd.Parameters.AddWithValue("@name_of_department", name_of_department.Text.Trim());
                        cmd.Parameters.AddWithValue("@location_of_incident", location_of_incident.Text.Trim());
                        cmd.Parameters.AddWithValue("@nature_of_incident", nature_of_incident.Text.Trim());
                        cmd.Parameters.AddWithValue("@drop_down_1", drop_down_1.SelectedValue);
                        cmd.Parameters.AddWithValue("@drop_down_2", drop_down_2.SelectedValue);
                        cmd.Parameters.AddWithValue("@drop_down_3", drop_down_3.SelectedValue);
                        cmd.Parameters.AddWithValue("@drop_down_4", drop_down_4.SelectedValue);
                        cmd.Parameters.AddWithValue("@drop_down_5", drop_down_5.SelectedValue);
                        cmd.Parameters.AddWithValue("@drop_down_6", drop_down_6.SelectedValue);
                        cmd.Parameters.AddWithValue("@describe_incident", describe_incident.Text.Trim());
                        cmd.Parameters.AddWithValue("@immediate_action", immediate_action.Text.Trim());
                        cmd.Parameters.AddWithValue("@root_cause_1", root1.Text.Trim());
                        cmd.Parameters.AddWithValue("@root_cause_2", root2.Text.Trim());
                        cmd.Parameters.AddWithValue("@root_cause_3", root3.Text.Trim());
                        cmd.Parameters.AddWithValue("@root_cause_4", root4.Text.Trim());
                        cmd.Parameters.AddWithValue("@root_cause_5", root5.Text.Trim());
                        cmd.Parameters.AddWithValue("@corrective_action_1", corrective1.Text.Trim());
                        cmd.Parameters.AddWithValue("@corrective_action_2", corrective2.Text.Trim());
                        cmd.Parameters.AddWithValue("@corrective_action_3", corrective3.Text.Trim());
                        cmd.Parameters.AddWithValue("@responsible_person_1", resp1.Text.Trim());
                        cmd.Parameters.AddWithValue("@responsible_person_2", resp2.Text.Trim());
                        cmd.Parameters.AddWithValue("@responsible_person_3", resp3.Text.Trim());
                        cmd.Parameters.AddWithValue("@date_of_completion_1", date1.Text.Trim());
                        cmd.Parameters.AddWithValue("@date_of_completion_2", date2.Text.Trim());
                        cmd.Parameters.AddWithValue("@date_of_completion_3", date3.Text.Trim());
                        cmd.Parameters.AddWithValue("@hazard_study", hazardStudy);
                        cmd.Parameters.AddWithValue("@FName", filename);
                        cmd.Parameters.AddWithValue("@FExtension", extension);
                        cmd.Parameters.AddWithValue("@FilePath", savePath);
                        cmd.Parameters.AddWithValue("@modified_date", now);
                        cmd.Parameters.AddWithValue("@remarks", remarks.Text.Trim());
                        cmd.Parameters.AddWithValue("@IPAddress", ipAddress.Trim());

                        cmd.ExecuteNonQuery();
                        conn.Close();

                        string script = "<script>alert('Form Submitted Successfully'); alert('Now Redirecting to Dashboard'); window.location='HomePage2.aspx';</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "');</script>");
            }

        }
    }


}