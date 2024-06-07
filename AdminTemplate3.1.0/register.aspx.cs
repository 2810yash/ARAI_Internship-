namespace AdminTemplate3._1._0
{
    public partial class register : System.Web.UI.Page
    {
        /* string strconn2 = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
         private SqlCommand cmd;

         protected void Page_Load(object sender, EventArgs e)
         {
             if (!IsPostBack)
             {
                 dept_list();
             }
         }

         protected void dept_list()
         {
             SqlConnection sqlcon = new SqlConnection(strconn2);
             sqlcon.Open();
             SqlCommand sql_command = new SqlCommand("SELECT * FROM [dbo].[Department_TBL]", sqlcon);
             sql_command.CommandType = CommandType.Text;
             dept.DataSource = sql_command.ExecuteReader();
             dept.DataTextField = "Dept_Name";
             //araiEng.DataValueField = "DeptID";
             dept.DataBind();
             dept.Items.Insert(0, new ListItem("-- Select Department Name --", "0"));*/
    }
}
        
        // Sign Up Button
       /* protected void Button1_Click(object sender, EventArgs e)
        {
            String userName = regiName.Text.Trim();
            String email = regiEmail.Text.Trim();
            String pass = regiPass.Text.Trim();
            String rePass = regiRepass.Text.Trim();
            String selectedRole = roles.SelectedValue;
            String selectedDept = dept.SelectedValue;

            if (pass == rePass && selectedRole != "role" && selectedDept != "0")
            {
                SignUpNewUser(userName, email, pass, selectedRole, selectedDept);
                if (selectedRole == "admin")
                {
                    Response.Redirect("Homepage.aspx");
                }
                else if (selectedRole == "user")
                {
                    Response.Redirect("Welcome.aspx");
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

        protected void SignUpNewUser(String userName, String email, String pass, String selectedRole, String selectedDept)
        {
           /SqlConnection con = new SqlConnection(strconn2);
            /*try
            {
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
                        cmd.Parameters.AddWithValue("@Dept", selectedDept);
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
                    }*/
           /*     }
            }
           // catch (Exception ex)
            //{
               // Response.Write(ex.Message);
           // }
        }*/

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    //Response.Redirect("login.aspx");
        //}
    

