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
            String email = TextBox1.Text.Trim();
            String pass = TextBox2.Text.Trim();
            String rePass = TextBox3.Text.Trim();

            if (pass == rePass)
            {
                SignUpNewUser(email, pass);
            }
            else
            {
                Response.Write("<script>alert('PassWord does not matched');</script>");
            }
        }

        protected void SignUpNewUser(String email, String pass)
        {
            SqlConnection con = new SqlConnection(strconn2);
            try
            {
                int result = 0;
                using (con = new SqlConnection(strconn2))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_register_tbl", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmailID", email);
                        cmd.Parameters.AddWithValue("@Password", pass);
                        con.Open();
                        result = cmd.ExecuteNonQuery();
                        con.Close();
                        if (result > 0)
                        {
                            Response.Write("<script>alert('Register Successfully.\nGo for Login Page to Login.');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Register UnSuccessfully.\nTry Again');</script>");
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
            Response.Redirect("login.aspx");
        }
    }
}