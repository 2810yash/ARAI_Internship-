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
        private readonly DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {

                SetInitialRow();

            }
            
        }
        
          public void AddNewRowToGrid()

        {

            int rowIndex = 1;



            if (ViewState["CurrentTable"] != null)

            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)

                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)

                    {

                        //extract the TextBox values

                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("TextBox1");

                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("TextBox3");



                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;



                        dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;

                        dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;

                        dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;



                        rowIndex++;

                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);

                    ViewState["CurrentTable"] = dtCurrentTable;



                    Gridview1.DataSource = dtCurrentTable;

                    Gridview1.DataBind();

                }

            }

            else

            {

                Response.Write("ViewState is null");

            }



            //Set Previous Data on Postbacks

            SetPreviousData();

        }

     private void SetPreviousData()

        {

            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)

            {
                //// Create a list of 5 items to bind to the Repeater
                //var textBoxRows = new List<int> { 1, 2, 3, 4, 5 };

                //// Bind the list to the Repeater
                //Repeater1.DataSource = textBoxRows;
                //Repeater1.DataBind();
            }

        }

       
     private void SetInitialRow()

        {

            DataTable dt = new DataTable();

            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

            dt.Columns.Add(new DataColumn("Column1", typeof(string)));

            dt.Columns.Add(new DataColumn("Column2", typeof(string)));

            dt.Columns.Add(new DataColumn("Column3", typeof(string)));

            dr = dt.NewRow();

            dr["RowNumber"] = 1;

            dr["Column1"] = string.Empty;

            dr["Column2"] = string.Empty;

            dr["Column3"] = string.Empty;

            dt.Rows.Add(dr);

            //dr = dt.NewRow();



            //Store the DataTable in ViewState

            ViewState["CurrentTable"] = dt;



            Gridview1.DataSource = dt;

            Gridview1.DataBind();

        }
        protected void ButtonAdd_Click(object sender, EventArgs e)

        {

            AddNewRowToGrid();

        }

        protected void submitForm(object sender, EventArgs e)
        {
            try
            {
               // using (SqlConnection con = new SqlConnection(strcon))
                {
                   // using (SqlCommand cmd = new SqlCommand("usp_exp_tbl", con))
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

