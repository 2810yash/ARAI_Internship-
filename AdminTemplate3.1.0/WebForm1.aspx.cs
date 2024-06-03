using System;
using BusinessLogic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObject;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Net.Mail;
using System.Linq;
using System.IO;
using System.Web;
using System.Configuration;

namespace AdminTemplate3._1._0
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        BLL objBLL = new BLL();
        string ipaddress;
        string FilePath = common.FilePath();
        string strcon = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];
            try
            {
                if (!IsPostBack)
                {

                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string FName = "";
            string FExtension = "";
            string FilePath = null;
            string FileAttachment = string.Empty;
            SaveBO objUser = new SaveBO();

            if (FileUpload1.HasFile)
            {

                string filename = FileUpload1.FileName;
                string extension = Path.GetExtension(filename);
                HttpPostedFile file = FileUpload1.PostedFile;
                if ((extension == ".pdf") || (extension == ".PDF") || (extension == ".jpg") || (extension == ".JPG") || (extension == ".doc") || (extension == ".DOC") || (extension == ".docx") || (extension == ".DOCX") || (extension == ".xlsx") || (extension == ".XLSX") || (extension == ".xls") || (extension == ".XLS") || (extension == ".rtf") || (extension == ".RTF") || (extension == ".pptx") || (extension == ".PPTX") || (extension == ".txt") || (extension == ".TXT"))//extension  
                {
                    if (file.ContentLength <= 5000000) // allow file size upto 5MB  
                    {
                        FName = filename;
                        FExtension = extension;
                        //FileUpload.SaveAs(folder_path + filename);
                        string filepath = FilePath + filename.Trim();
                        FilePath = filepath;
                        FileAttachment = "Y";

                        int result = objBLL.SaveAccidentIncident(objUser);
                        if (result > 0)
                        {
                            ShowMessage("Form save successfully!");
                        }
                        else
                        {
                            ShowMessage("Form not saved!");
                        }

                    }
                }
            }
        }

        private void ShowMessage(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "customScript", "<script>alert('" + message + "');</script>", false);
        }
    }
}
