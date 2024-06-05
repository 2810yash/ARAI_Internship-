using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;

namespace AdminTemplate3._1._0
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"].Equals("admin"))
            {
                Response.Redirect("Homepage.aspx");
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
            string connectionString = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                StatusLabel.Text = "Database connection string is not set.";
                return;
            }


            //DateTime dateofIncident = date_of_incident;


            try
            {
                string filename = "NULL";
                string extension = "NULL";
                string customUploadPath = "NULL";
                string savePath = "NULL";

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
                DateTime now = DateTime.Now;

                

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Ensure the connection is open
                    string query = "INSERT INTO accident_incident (date_of_incident, time_of_incident, name_of_affected_person, name_of_department, location_of_incident, nature_of_incident, drop_down_1, drop_down_2, drop_down_3, drop_down_4, drop_down_5, drop_down_6, describe_incident, immediate_action_taken, root_cause_analysis, corrective_action_plan, completion_date, responsible_person, corrective_action_impact, hazard_study, FName, FExtension, FilePath, CreatedDate, remarks, IPAddress) " +
                        "VALUES (@date_of_incident, @time_of_incident, @name_of_affected_person, @name_of_department, @location_of_incident, @nature_of_incident, @drop_down_1, @drop_down_2, @drop_down_3, @drop_down_4, @drop_down_5, @drop_down_6, @describe_incident, @immediate_action_taken, @root_cause_analysis, @corrective_action_plan, @completion_date, @responsible_person, @corrective_action_impact, @hazard_study, @FName, @FExtension, @FilePath, @CreatedDate, @remarks, @IPAddress)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add the text properties of TextBox controls
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
                        cmd.Parameters.AddWithValue("@immediate_action_taken", immediate_action_taken.Text.Trim());
                        cmd.Parameters.AddWithValue("@root_cause_analysis", root_cause_analysis.Text.Trim());
                        cmd.Parameters.AddWithValue("@corrective_action_plan", corrective_action_plan.Text.Trim());
                        cmd.Parameters.AddWithValue("@completion_date", completion_date.Text.Trim());
                        cmd.Parameters.AddWithValue("@responsible_person", responsible_person.Text.Trim());
                        cmd.Parameters.AddWithValue("@corrective_action_impact", corrective_action_impact.Text.Trim());
                        cmd.Parameters.AddWithValue("@hazard_study", hazardStudy);
                        cmd.Parameters.AddWithValue("@FName", filename);
                        cmd.Parameters.AddWithValue("@FExtension", extension);
                        cmd.Parameters.AddWithValue("@FilePath", savePath);
                        cmd.Parameters.AddWithValue("@CreatedDate", now);
                        cmd.Parameters.AddWithValue("@remarks", remarks.Text.Trim());
                        cmd.Parameters.AddWithValue("@IPAddress", ipAddress.Trim());

                        cmd.ExecuteNonQuery();

                        string script = "<script>alert('Form Submitted Successfully'); alert('Now Redirecting to Dashboard'); window.location='Homepage.aspx';</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }
    }
}
