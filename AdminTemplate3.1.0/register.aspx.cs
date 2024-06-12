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
            if (!IsPostBack)
            {
                dept_list();
                role_list();
            }
        }

        protected void dept_list()
        {
            SqlConnection sqlcon = new SqlConnection(strconn2);
            sqlcon.Open();
            SqlCommand sql_command = new SqlCommand("SELECT * FROM [dbo].[ICSS_DeptMaster]", sqlcon);
            sql_command.CommandType = CommandType.Text;
            dept.DataSource = sql_command.ExecuteReader();
            dept.DataTextField = "DEPT_NAME";
            //araiEng.DataValueField = "DeptID";
            dept.DataBind();
            dept.Items.Insert(0, new ListItem("-- Select Department Name --", "0"));
        }

        protected void role_list()
        {
            SqlConnection sqlcon = new SqlConnection(strconn2);
            sqlcon.Open();
            SqlCommand sql_command = new SqlCommand("SELECT * FROM [dbo].[Role_Master_TBL]", sqlcon);
            sql_command.CommandType = CommandType.Text;
            roles.DataSource = sql_command.ExecuteReader();
            roles.DataTextField = "Role";
            roles.DataBind();
            roles.Items.Insert(0, new ListItem("-- Select Role --", "0"));
        }
    
        // Sign Up Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            String userName = regiName.Text.Trim();
            String email = regiEmail.Text.Trim();
            String pass = regiPass.Text.Trim();
            String rePass = regiRepass.Text.Trim();
            String selectedRole = roles.SelectedValue.ToString();
            String selectedDept = dept.SelectedValue;
            

            if (pass == rePass && selectedRole != null && selectedDept != "0")
            {
                SignUpNewUser(userName, email, pass, selectedRole, selectedDept);
                if (selectedRole.Equals("Admin"))
                {
                    Response.Redirect("Homepage.aspx");
                }
                else if (selectedRole.Equals("User"))
                {
                    Response.Redirect("Homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Select Proper Role');</script>");
                }
            }
            else if (pass != rePass)
            {
                Response.Write("<script>alert('Password does not matched');</script>");
            }
            else
            {
                Response.Write("<script>alert('Please fill all the details.');</script>");
            }
        }

        protected int getRoleID(String selectedRole)
        {
            int roleID;
            try
            {
                using (SqlConnection con = new SqlConnection(strconn2))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_getRoleCode", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Role", selectedRole);
                        cmd.Parameters.Add("@RoleID", SqlDbType.Int, 100).Direction = ParameterDirection.Output;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        roleID = (int)cmd.Parameters["@RoleID"].Value;
                        //Response.Write("<script> alert('Dept Code = '" + roleID + "'); </script>");
                        con.Close();
                        return roleID;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
                return 0;
            }
        }

        protected int GetDeptCode(String selectedDept)
        {
            int deptCode;
            try {
                using (SqlConnection con = new SqlConnection(strconn2))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_getDeptCode", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DeptName", selectedDept);
                        cmd.Parameters.Add("@DeptCode", SqlDbType.Int, 100).Direction = ParameterDirection.Output;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        deptCode = (int)cmd.Parameters["@DeptCode"].Value;
                        Response.Write("<script> alert('Dept Code = '" + deptCode + "'); </script>");
                        con.Close();
                        return deptCode;
                    }
                }
            } catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
                return 0;
            }
        }

        protected void SignUpNewUser(String userName, String email, String pass, String selectedRole, String selectedDept)
        {
            //SqlConnection con = new SqlConnection(strconn2);
            try
            {

                int deptCode = GetDeptCode(selectedDept);
                int roleID = getRoleID(selectedRole);
                if (deptCode == 0 || roleID == 0)
                {
                    Response.Write("<script> alert('Could not store details! Please try again') </script>");
                    Response.Redirect("register.aspx");
                    return;
                }

                Session["DeptID"] = deptCode;
                Session["RoleID"] = roleID;

                //string hashedPassword = PasswordHelper.HashPassword(pass);
                int result = 0;
                using (SqlConnection con = new SqlConnection(strconn2))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_register_tbl", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", userName);
                        cmd.Parameters.AddWithValue("@EmailID", email); 
                        cmd.Parameters.AddWithValue("@Password", pass);
                        cmd.Parameters.AddWithValue("@Role", selectedRole);
                        cmd.Parameters.AddWithValue("@RoleID", roleID);
                        cmd.Parameters.AddWithValue("@Dept", selectedDept);
                        cmd.Parameters.AddWithValue("@DeptCode", deptCode);
                        Session["deptName"] = selectedDept;
                        //Session["Role"] = selectedRole;
                        con.Open();
                        result = cmd.ExecuteNonQuery();
                        con.Close();
                        if (result > 0)
                        {
                            Response.Write("<script>alert('Register Successfully. Go for Login Page to Login.');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Register UnSuccessfully. Try Again');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}