using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web;

namespace AdminTemplate3._1._0
{
    public class PasswordHelper
    {
        // Define the size for the salt and the hash
        private const int SaltSize = 16; // 128 bit
        private const int HashSize = 20; // 160 bit

        // Define the number of iterations for the hashing algorithm
        private const int Iterations = 10000;

        // Method to hash a password
        public static string HashPassword(string password)
        {
            // Generate a salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            // Hash the password with the salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // Combine the salt and password bytes for later use
            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            // Convert to base64 for storage
            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
        }

        // Method to verify a password against a stored hash
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            // Extract the bytes
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // Get the salt
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Hash the entered password with the same salt
            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // Compare the results
            for (int i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                    return false;
            }

            return true;
        }
    }

    public partial class login : System.Web.UI.Page
    {
        string strconn2 = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
        private const int SaltSize = 16; // 128 bit
        private const int HashSize = 20; // 160 bit

        // Define the number of iterations for the hashing algorithm
        private const int Iterations = 10000;

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
                    try
                    {
                        storeDetails(deptCode, deptName, username, email, pass);
                    } catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
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

        protected void storeDetails(string deptCode, string deptName, string username, string email, string pass)
        {
            string clientIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            int index = email.IndexOf('@');
            string userDisplayName = string.Empty;
            if (index > 0)
            {
                userDisplayName = email.Substring(0, index);
            }
            string hashedPassword = PasswordHelper.HashPassword(pass);
            DateTime currentDate = DateTime.Today;
            int flag = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(strconn2))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_login_store_details", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmailID", email);
                        cmd.Parameters.AddWithValue("@Password", pass);
                        cmd.Parameters.AddWithValue("@DeptCode", deptCode);
                        cmd.Parameters.AddWithValue("@DeptName", deptName);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@UserDisplayName", userDisplayName);
                        cmd.Parameters.AddWithValue("@HashedPass", hashedPassword);
                        cmd.Parameters.AddWithValue("@Date", currentDate);
                        cmd.Parameters.AddWithValue("@IPAddress", clientIPAddress);

                        con.Open();
                        flag = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Response.Write(ex.Message);
            }

            if (flag >= 0)
            {
                Response.Write("<script>alert('Login Successfully.');</script>");
                // Redirect user to a dashboard page or any other page
                Response.Redirect("Homepage.aspx");
            } else
            {
                Response.Write("<script> alert('Could not store login details!');</script>");
            }

        }
    }
}
