using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public partial class login : System.Web.UI.Page
    {
        string strconn2 = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
        
        //Login button
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Get the email and password from the textboxes
            string email = TextBox1.Text.Trim();
            string pass = TextBox2.Text.Trim();

            // Call the signInUser method to authenticate the user
            signInUser(email, pass);
            
        }

        protected void signInUser(string email, string pass)
        {
            string deptCode = string.Empty;
            string deptName = string.Empty;
            string username = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(strconn2))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_login_create_tbl", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmailID", email);
                        cmd.Parameters.AddWithValue("@Password", pass);
                        cmd.Parameters.Add("@DeptCode", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@DeptName", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;

                        con.Open();
                        cmd.ExecuteNonQuery();

                        // Retrieve output parameters
                        deptCode = cmd.Parameters["@DeptCode"].Value.ToString();
                        deptName = cmd.Parameters["@DeptName"].Value.ToString();
                        username = cmd.Parameters["@Username"].Value.ToString();

                        con.Close();
                    }
                }

                if (!string.IsNullOrEmpty(deptCode) && !string.IsNullOrEmpty(deptName) && !string.IsNullOrEmpty(username))
                {
                    // Successful login
                    Response.Write("<script>alert('Login Successfully.');</script>");
                    // Redirect user to a dashboard page or any other page
                    Response.Redirect("Homepage.aspx");
                }
                else
                {
                    // Unsuccessful login
                    Response.Write("<script>alert('Login Unsuccessful.\nCheck your Details and Try Again');</script>");
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
