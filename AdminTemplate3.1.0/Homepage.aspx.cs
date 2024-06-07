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
using System.Web.Script.Serialization;
using System.Web.Script;

namespace AdminTemplate3._1._0
{

    public class AccidentData
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Accident_Incident_Count { get; set; }
    }
    public partial class Homepage : System.Web.UI.Page
    {
        //string strcon = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //int bounceRate = FetchBounceRateFromDatabase();
                //int newOrdersCount = FetchNewOrdersCountFromDatabase();
                //LiteralBounceRate.Text = bounceRate.ToString();
                //LiteralNewOrders.Text = newOrdersCount.ToString();
                // Example data
                var chartData = new
                {
                    labels = new[] { "January", "February", "March", "April" },
                    data = new[] { 10, 20, 30, 40 }
                };

                // Serialize the data to JSON
                var jsonData = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(chartData);

                // Set the JSON data to the HiddenField
                //hfChartData.Value = jsonData;
                LoadChartData();

            }
        }

        private int FetchNewOrdersCountFromDatabase()
        {
            /* int count = 0;
             using (SqlConnection connection = new SqlConnection(strcon))
             {
                 string query = "SELECT COUNT(*) FROM IncidentReport";
                 using (SqlCommand command = new SqlCommand(query, connection))
                 {
                     connection.Open();
                     count = (int)command.ExecuteScalar();
                 }
             } */
            return 0;
        }

        private int FetchBounceRateFromDatabase()
        {
            return 43;
        }
        private void LoadChartData()
        {
            string strcon = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
            string query = @"
            SELECT 
                YEAR([date_of_incident]) AS Year, 
                DATENAME(MONTH, DATEADD(MONTH, MONTH(date_Of_Incident) - 1, '1900-01-01')) AS MonthName, 
                COUNT(*) AS Accident_Incident_Count
            FROM 
                accident_incident
            GROUP BY 
                YEAR(date_Of_incident), 
                MONTH(date_Of_incident)
            ORDER BY 
                YEAR(date_Of_incident), 
                MONTH(date_Of_incident);";

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
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
                labels.Add($"{row["MonthName"]} {row["Year"]}");
                data.Add((int)row["Accident_Incident_Count"]);
            }

            var chartData = new
            {
                labels = labels,
                data = data
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            hfChartData.Value = serializer.Serialize(chartData);
        }
    }
}



