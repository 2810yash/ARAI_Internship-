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
        

        // List to hold rows of Why questions
        private static List<WhyQuestion> whyQuestions = new List<WhyQuestion>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initialize the data source and bind the GridView
                InitializeWhyQuestions();
                BindWhyGridView();
            }

            // Set the visibility of the footer template field based on the EditIndex
            whyGridView.Columns[whyGridView.Columns.Count - 1].Visible = whyGridView.EditIndex == -1;
        }


        protected void AddRow(object sender, EventArgs e)
        {
            // Add a new Why question to the list
            whyQuestions.Add(new WhyQuestion { ID = whyQuestions.Count + 1, WhyQuestionText = "" });

            // Rebind the GridView to update the display
            BindWhyGridView();
        }

        protected void WhyGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RemoveRow")
            {
                // Get the ID of the row to remove
                int id = Convert.ToInt32(e.CommandArgument);

                // Remove the row from the list
                whyQuestions.RemoveAll(wq => wq.ID == id);

                // Rebind the GridView to update the display
                BindWhyGridView();
            }
        }

        protected void WhyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get the index of the row being deleted
            int index = e.RowIndex;

            // Remove the row from the list
            whyQuestions.RemoveAt(index);

            // Rebind the GridView to update the display
            BindWhyGridView();
        }

        private void InitializeWhyQuestions()
        {
            // Initialize the list of Why questions (optional)
            whyQuestions = new List<WhyQuestion>();
        }

        private void BindWhyGridView()
        {
            // Bind the list of Why questions to the GridView
            whyGridView.DataSource = whyQuestions;
            whyGridView.DataBind();
        }
    


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
    }
    // Class to represent a Why question
    public class WhyQuestion
    {
        public int ID { get; set; }
        public string WhyQuestionText { get; set; }
    }
}