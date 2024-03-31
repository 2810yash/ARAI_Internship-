﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public partial class login : System.Web.UI.Page
    {
        string strconn2 = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;

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
            SqlConnection con = new SqlConnection(strconn2);
            try
            {
                int result = 0;
                int userID = 0;

                using (con = new SqlConnection(strconn2))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_login_tbl", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmailID", email);
                        cmd.Parameters.AddWithValue("@Password", pass);
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                        con.Open();
                        result = cmd.ExecuteNonQuery();

                        // Get the output parameter value
                        userID = (int)cmd.Parameters["@Id"].Value;

                        con.Close();
                    }
                }

                if (userID > 0)
                {
                    // Successful login
                    Response.Write("<script>alert('Login Successfully.');</script>");
                    // Redirect user to a dashboard page or any other page
                    Response.Redirect("HomePage.aspx");
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
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}
