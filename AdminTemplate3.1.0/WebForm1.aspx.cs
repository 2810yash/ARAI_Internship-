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

       
        protected void submitForm(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("insert into exp (date_of_issue, time_of_issue, root_cause, mitigation, root_cause_analysis, corrective_action_plan, completion_date, responsibility, remarks) values(@date_of_issue, @time_of_issue, @root_cause, @mitigation, @root_cause_analysis, @corrective_action_plan, @completion_date, @responsibility, @remarks)", con);
                cmd.Parameters.AddWithValue("date_of_issue", date_of_issue.Text.Trim());
                cmd.Parameters.AddWithValue("time_of_issue", time_of_issue.Text.Trim());
                cmd.Parameters.AddWithValue("root_cause", root_cause.Text.Trim());
                cmd.Parameters.AddWithValue("mitigation", mitigation.Text.Trim());
                cmd.Parameters.AddWithValue("root_cause_analysis", root_cause_analysis.Text.Trim());
                cmd.Parameters.AddWithValue("corrective_action_plan", corrective_action_plan.Text.Trim());
                cmd.Parameters.AddWithValue("completion_date", completion_date.Text.Trim());
                cmd.Parameters.AddWithValue("responsibility", responsibility.Text.Trim());
                cmd.Parameters.AddWithValue("remarks", remarks.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                // Display alert using JavaScript
                string script = "<script>alert('Form Submitted Successfully');\nalert('Now Redirecting to Dashboard');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script);

                // Redirect after a delay
                Response.AddHeader("REFRESH", "0.1;URL=Homepage.aspx");

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }
        protected void Gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Action";
                e.Row.Cells[1].Text = "Student ID";
                e.Row.Cells[2].Text = "Student Name";
                e.Row.Cells[3].Text = "Father Name";
                e.Row.Cells[4].Text = "DOB";
                e.Row.Cells[5].Text = "Program";
                e.Row.Cells[6].Text = "Region";
                e.Row.Cells[7].Text = "Address";
                e.Row.Cells[8].Text = "Cell Number";
                e.Row.Cells[9].Text = "Gender";
            }
        }
    }
}

