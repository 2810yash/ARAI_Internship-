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

                //// Bind the list to the Repeater
                //Repeater1.DataSource = textBoxRows;
                //Repeater1.DataBind();
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
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_exp_tbl", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@Date_of_Incident", date_of_issue);
                        //cmd.Parameters.AddWithValue("@Time_of_Incident", time_of_issue);
                        //cmd.Parameters.AddWithValue("@Name_of_Affected_person", name_person);
                        //cmd.Parameters.AddWithValue("@Dept_name", dept_name.SelectedValue);
                        //cmd.Parameters.AddWithValue("@Location_Accident", accident_location);
                        //cmd.Parameters.AddWithValue("@Nature_of_Incident", nature_of_incident.SelectedValue);
                        //cmd.Parameters.AddWithValue("@Accident_Description", describtion);
                        //cmd.Parameters.AddWithValue("@Immediate_ActionTaken", immediate_action);
                        //cmd.Parameters.AddWithValue("@Root_cause_Analysis", root_cause_analysis);
                        //cmd.Parameters.AddWithValue("@Corrective_action_plan", corrective_action_plan);
                        //cmd.Parameters.AddWithValue("@Completion_date", completion_date);
                        //cmd.Parameters.AddWithValue("@Responsible_person", responsible_person);
                        //cmd.Parameters.AddWithValue("@Corrective_action_impact", corrective_action_impact);
                        //cmd.Parameters.AddWithValue("@Hazard_Study_Update", hazard_update.Checked);
                        //cmd.Parameters.AddWithValue("@Remark", remarks);

                        cmd.ExecuteNonQuery();
                        conn.Close();

                        string script = "<script>alert('Form Submitted Successfully'); alert('Now Redirecting to Dashboard'); window.location='Homepage.aspx';</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Response.Write(ex.Message);
            }
        }
       
    }
}


