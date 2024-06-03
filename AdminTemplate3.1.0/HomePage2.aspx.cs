using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public partial class HomePage2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadChartData();
        }

        private void LoadChartData()
        {
            string strcon = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
            string query = @"
            SELECT 
                YEAR(dateOfIssue) AS Year, 
                DATENAME(MONTH, DATEADD(MONTH, MONTH(dateOfIssue) - 1, '1900-01-01')) AS MonthName, 
                COUNT(*) AS PermitCount
            FROM 
                permit_details_tbl
            GROUP BY 
                YEAR(dateOfIssue), 
                MONTH(dateOfIssue)
            ORDER BY 
                YEAR(dateOfIssue), 
                MONTH(dateOfIssue);";


            DataTable dt = new DataTable();

            using(SqlConnection con = new SqlConnection(strcon))
            {
                using(SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            var labels = new List<string>();
            var data = new List<int>();

            foreach (DataRow row in dt.Rows)
            {
                // string monthName = GetMonthName((int)row["Month"]);
                labels.Add($"{row["MonthName"]} {row["Year"]}");
                data.Add((int)row["PermitCount"]);
            }

            var chartData = new
            {
                labels = labels,
                data = data
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            hfChartData.Value = serializer.Serialize(chartData);

        }
        private string GetMonthName(int month)
        {
            return new DateTime(1, month, 1).ToString("MMMM");
        }
    }
}