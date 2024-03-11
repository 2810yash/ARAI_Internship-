using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public partial class Homepage : System.Web.UI.Page
    {
        BLL objBLL = new BLL();
        DataTable dt;
        string ipaddress;
        string LogFilePath = common.LogFilePath();
        protected void Page_Load(object sender, EventArgs e)
        {
            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];
            try
            {
                if (Session["userid"] != null)
                {
                    if (IsPostBack)
                    {
                        callfunction();
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog("Log_" + System.DateTime.Now.ToString("dd-MM-yyyy") + "", String.Format("{0} @ {1}", "Exception: " + ex.Message + "", DateTime.Now));
                WriteLog("Log_" + System.DateTime.Now.ToString("dd-MM-yyyy") + "", String.Format("{0}  {1}", "********----------------------------------------------------------------------------------------------------------------------------", "********"));
                ShowMessage(ex.Message);
            }
        }
        private void callfunction()
        {
             //Write code here
        }
        protected void btnClick_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] == null)
                {
                    string userid = "xyz";
                    DataSet ds = new DataSet();
                    ds = objBLL.GetUserLogin(userid);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //Code
                    }             
                    Response.Redirect("~/Welcome.aspx", false);
                }
                else
                {
                    ShowMessage("session has been expired");
                }
            }
            catch (Exception ex)
            {
                WriteLog("Log_" + System.DateTime.Now.ToString("dd-MM-yyyy") + "", String.Format("{0} @ {1}", "_Exception: " + ex.Message + "", DateTime.Now));
                WriteLog("Log_" + System.DateTime.Now.ToString("dd-MM-yyyy") + "", String.Format("{0}  {1}", "********----------------------------------------------------------------------------------------------------------------------------", "********"));
                ShowMessage(ex.Message);
            }
        }
        private bool WriteLog(string strFileName, string strMessage)
        {
            try
            {
                FileStream objFilestream = new FileStream(string.Format(LogFilePath, strFileName), FileMode.Append, FileAccess.Write);
                StreamWriter objStreamWriter = new StreamWriter((Stream)objFilestream);
                objStreamWriter.WriteLine(strMessage);
                objStreamWriter.Close();
                objFilestream.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void ShowMessage(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "customScript", "<script>alert('" + message + "');</script>", false);
        }
    }
}