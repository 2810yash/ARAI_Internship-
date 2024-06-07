using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        string Main_con = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

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
                                hazard_study= reader["hazard_study"].ToString(),
                                FName=reader["FName"].ToString(),
                                FExtension=reader["FExtension"].ToString(),
                                FilePath=reader["FilePath"].ToString(),
                                CreatedDate=reader["CreatedDate"].ToString(),
                                remarks=reader["remarks"].ToString(),
                                IPAddress=reader["IPAddress"].ToString(),
                                root_cause_1=reader["root_cause_1"].ToString(),
                                root_cause_2=reader["root_cause_2"].ToString(),
                                root_cause_3=reader["root_cause_3"].ToString(),
                                root_cause_4=reader["root_cause_4"].ToString(),
                                root_cause_5=reader["root_cause_5"].ToString(),
                                corrective_action_1=reader["corrective_action_1"].ToString(),
                                corrective_action_2=reader["corrective_action_2"].ToString(),
                                corrective_action_3=reader["corrective_action_3"].ToString(),
                                responsible_person_1=reader["responsible_person_1"].ToString(),
                                responsible_person_2=reader["responsible_person_2"].ToString(),
                                responsible_person_3=reader["responsible_person_3"].ToString(),
                                date_of_completion_1=reader["date_of_completion_1"].ToString(),
                                date_of_completion_2=reader["date_of_completion_2"].ToString(),
                                date_of_completion_3=reader["date_of_completion_3"].ToString(),
    };
                        }
                    }
                }

                return permitDetails;
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