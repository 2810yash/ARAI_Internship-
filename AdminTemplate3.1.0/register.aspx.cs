using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public partial class register : System.Web.UI.Page
    {
        string strconn2 = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
        private SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        // Sign Up Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            RecordInsert();
        }

        protected void RecordInsert()
        {
            // Response.Write("<script>alert('Testing');</script>");
            SqlConnection con = new SqlConnection(strconn2);
            try
            {
                int result = 0;
                using (con = new SqlConnection(strconn2))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_register_tbl", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmailID", TextBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", TextBox2.Text.Trim());
                        //cmd.Parameters.AddWithValue("@RePassword", TextBox3.Text.Trim());
                        //cmd.Parameters.AddWithValue("@AcountStatus", "pending");
                        con.Open();
                        result = cmd.ExecuteNonQuery();
                        con.Close();
                        if (result > 0)
                        {
                            Response.Write("Record inserted");
                            Response.Write("<script>alert(Record Inserted);</script>");
                        }
                        else
                        {
                            Response.Write("Record not inserted");
                            Response.Write("<script>alert(Record Not Inserted);</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}