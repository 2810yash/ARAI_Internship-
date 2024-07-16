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
            try
            {
                if (!IsPostBack)
                {
                    if (Session["Username"] != null)
                    {
                        userDisplayName = Session["Username"].ToString().ToUpperInvariant();
                    }

                    if ((int)Session["RoleID"] == 2)
                    {
                        createWP.Visible = true;
                        //createReport.Visible = true;
                    }
                    //GetFunc();
                } 
            } catch
            {
                Response.Redirect("login.aspx");
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
        protected void logoutBTN_Click(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetValidUntilExpires(false);
            Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            Session.Clear();
            Session.Abandon(); // Add this line to abandon the session
            Session.RemoveAll();

            Response.Redirect("login.aspx");
        }
    }
}