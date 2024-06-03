using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public partial class SiteMaster : MasterPage
    {
        public string userDisplayName { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    userDisplayName = Session["Username"].ToString().ToUpperInvariant();
                }

                if (Session["Role"].Equals("user"))
                {
                    createWP.Visible = true;
                    createReport.Visible = true;
                }
                //GetFunc();            
            }
        }
        protected void Create_Report(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
        protected void Create_WP(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }
        protected void Active_WP(object sender, EventArgs e)
        {
            // dashboard.Atri
        }
    }
}