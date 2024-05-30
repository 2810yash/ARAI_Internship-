using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public partial class Homepage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int bounceRate = FetchBounceRateFromDatabase();
                int newOrdersCount = FetchNewOrdersCountFromDatabase();
                LiteralBounceRate.Text = bounceRate.ToString();
                LiteralNewOrders.Text = newOrdersCount.ToString();
            }
        }

        private int FetchNewOrdersCountFromDatabase()
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(strcon))
            {
                string query = "SELECT COUNT(*) FROM IncidentReport";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    count = (int)command.ExecuteScalar();
                }
            }
            return count;
        }

        private int FetchBounceRateFromDatabase()
        {
            return 43;
        }
    }
}