using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public partial class viewWorkPermit : System.Web.UI.Page
    {
        string Main_con = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = string.Format("select PermitNumber, NameofSupervisor, DateofIssue, PermitValidFrom from permit_details_tbl");
                SqlConnection con = new SqlConnection(Main_con);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reptCard.DataSource = reader;
                reptCard.DataBind();
                con.Close();
            }
        }

        protected void searchBTN_Click(object sender, EventArgs e)
        {
            
        }
    }
}