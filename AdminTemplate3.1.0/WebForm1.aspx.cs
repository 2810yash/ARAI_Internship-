    using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

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
                        cmd.Parameters.AddWithValue("@Date_of_Incident", date_of_incident);
                        cmd.Parameters.AddWithValue("@Time_of_Incident", time_of_incident);
                        cmd.Parameters.AddWithValue("@Name_of_Affected_person", name_person);
                        cmd.Parameters.AddWithValue("@Dept_name", dept_name.SelectedValue);
                        cmd.Parameters.AddWithValue("@Location_Accident", accident_location);
                        cmd.Parameters.AddWithValue("@Nature_of_Incident", nature_of_incident.SelectedValue);
                        cmd.Parameters.AddWithValue("@Accident_Description", describtion);
                        cmd.Parameters.AddWithValue("@Immediate_ActionTaken", immediate_action);
                        cmd.Parameters.AddWithValue("@Root_cause_Analysis", root_cause_analysis);
                        cmd.Parameters.AddWithValue("@Corrective_action_plan", corrective_action_plan);
                        cmd.Parameters.AddWithValue("@Completion_date", completion_date);
                        cmd.Parameters.AddWithValue("@Responsible_person", responsible_person);
                        cmd.Parameters.AddWithValue("@Corrective_action_impact", corrective_action_impact);
                        cmd.Parameters.AddWithValue("@Hazard_Study_Update", hazard_update.Checked);
                        cmd.Parameters.AddWithValue("@Remark", remarks);

                        con.Open();
                        cmd.ExecuteNonQuery();

                        con.Close();
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