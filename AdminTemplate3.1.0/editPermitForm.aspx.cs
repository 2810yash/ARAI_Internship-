using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public partial class editPermitForm : System.Web.UI.Page
    {
        string permitNUM;
        string remark;
        int? workernum;
        int rowCount = 0;
        public string deptName;
        string Main_con = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
        PermitDetails fileParts = new PermitDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["DeptName"] != null)
                {
                    deptName = Session["DeptName"].ToString();
                }
                else
                {
                    Response.Redirect("login.aspx");
                }

                if (Session["PermitNumber"] == null)
                {
                    // Handle the case when incident_id is not available, e.g., redirect to an error page or display a message
                    Response.Redirect("viewWorkPermit.aspx");
                }
                else
                {
                    string permitNumber = Session["PermitNumber"].ToString();
                    //loadIncidentID();
                    splWorkPermit_list();
                    arai_Engineer_list();
                    setInitialCheck();
                    loadFormData(permitNumber);
                    GetData(permitNumber);
                }
            } catch
            {
                Response.Redirect("login.aspx");
            }

            if (!IsPostBack)
            {
                if (Session["PermitNumber"] == null)
                {
                    // Handle the case when incident_id is not available, e.g., redirect to an error page or display a message
                    Response.Redirect("viewWorkPermit.aspx");
                }
                else
                {
                    string permitNumber = Session["PermitNumber"].ToString();
                    //loadIncidentID();
                    splWorkPermit_list();
                    arai_Engineer_list();
                    setInitialCheck();
                    loadFormData(permitNumber);
                    GetData(permitNumber);
                }
            }
           
            //if (!Page.IsPostBack)
            //{
            //    SetInitialRow();
            //}
        }
        public void arai_Engineer_list()
        {
            SqlConnection sqlcon = new SqlConnection(Main_con);
            sqlcon.Open();
            SqlCommand sql_command = new SqlCommand("SELECT * FROM [dbo].[engineer_name_tbl]", sqlcon);
            sql_command.CommandType = CommandType.Text;
            araiEng1.DataSource = sql_command.ExecuteReader();
            araiEng1.DataTextField = "EngineerName";
            araiEng1.DataBind();
            araiEng1.Items.Insert(0, new ListItem("-- Select Engineer Name --", "0"));
        }

        public void splWorkPermit_list()
        {
            SqlConnection sqlcon = new SqlConnection(Main_con);
            sqlcon.Open();
            SqlCommand sql_command = new SqlCommand("SELECT Work_Permit FROM [dbo].[WorkPermit] WHERE Spl_License=1", sqlcon);
            sql_command.CommandType = CommandType.Text;
            spl_Licence1.DataSource = sql_command.ExecuteReader();
            spl_Licence1.DataTextField = "Work_Permit";
            spl_Licence1.DataBind();
            spl_Licence1.Items.Insert(0, new ListItem("-- Select Special Work Permit --", "0"));
        }

        private void GetData(string permitNumber)
        {
            DataTable table = new DataTable();

            using (SqlConnection con = new SqlConnection(Main_con))
            {
                string sql = "SELECT * FROM [dbo].[Workers] WHERE PermitNumber = @PermitNumber";

                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@PermitNumber", permitNumber);

                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }

            ViewState["WorkerDetails"] = table;
            workerDetails.DataSource = table;
            workerDetails.DataBind();
        }

        private void loadIncidentID()
        {
            // Retrieve the incident_id from the session
            permitNUM = Session["PermitNumber"].ToString();

            // If incident_id is null or empty, handle it accordingly
            if (string.IsNullOrEmpty(permitNUM))
            {
                // Handle the case when incident_id is not available, e.g., redirect to an error page or display a message
                Response.Redirect("viewWorkPermit.aspx");
            }
        }
        public void setInitialCheck()
        {
            check1_Hinfo.Visible = false;
            check1_Pinfo.Visible = false;
            check1_PPEinfo.Visible = false;
            check2_Hinfo.Visible = false;
            check2_Pinfo.Visible = false;
            check2_PPEinfo.Visible = false;
            check3_Hinfo.Visible = false;
            check3_Pinfo.Visible = false;
            check3_PPEinfo.Visible = false;
            check4_Hinfo.Visible = false;
            check4_Pinfo.Visible = false;
            check4_PPEinfo.Visible = false;
            check5_Hinfo.Visible = false;
            check5_Pinfo.Visible = false;
            check5_PPEinfo.Visible = false;
            check6_Hinfo.Visible = false;
            check6_Pinfo.Visible = false;
            check6_PPEinfo.Visible = false;
            check7_Hinfo.Visible = false;
            check7_Pinfo.Visible = false;
            check7_PPEinfo.Visible = false;
            check8_Hinfo.Visible = false;
            check8_Pinfo.Visible = false;
            check8_PPEinfo.Visible = false;
        }
        public void special_license_CheckedChanged(object sender, EventArgs e)
        {
            spl_Licence1.Visible = special_license_yes1.Checked;
            check5.Enabled = true;
            check6.Enabled = true;
            check7.Enabled = true;
            check8.Enabled = true;
        }
        public void special_license_CheckedChangedNo(object sender, EventArgs e)
        {
            spl_Licence1.Visible = special_license_yes1.Checked;
            check1.Enabled = true;
            check2.Enabled = true;
            check3.Enabled = true;
            check4.Enabled = true;
            check5.Enabled = false;
            check6.Enabled = false;
            check7.Enabled = false;
            check8.Enabled = false;
            check5.Checked = false;
            check6.Checked = false;
            check7.Checked = false;
            check8.Checked = false;
        }
        protected void checkChange1(object sender, EventArgs e)
        {
            if (check1.Checked == true)
            {
                check1_Hinfo.Visible = true;
                check1_Pinfo.Visible = true;
                check1_PPEinfo.Visible = true;
                check4.Enabled = false;
                check4.Checked = false;
            }
            else
            {
                check1_Hinfo.Visible = false;
                check1_Pinfo.Visible = false;
                check1_PPEinfo.Visible = false;
                check4.Enabled = true;
            }
        }
        protected void checkChange2(object sender, EventArgs e)
        {
            if (check2.Checked == true)
            {
                check2_Hinfo.Visible = true;
                check2_Pinfo.Visible = true;
                check2_PPEinfo.Visible = true;
            }
            else
            {
                check2_Hinfo.Visible = false;
                check2_Pinfo.Visible = false;
                check2_PPEinfo.Visible = false;
            }
        }
        protected void checkChange3(object sender, EventArgs e)
        {
            if (check3.Checked == true)
            {
                check3_Hinfo.Visible = true;
                check3_Pinfo.Visible = true;
                check3_PPEinfo.Visible = true;
            }
            else
            {
                check3_Hinfo.Visible = false;
                check3_Pinfo.Visible = false;
                check3_PPEinfo.Visible = false;
            }
        }
        protected void checkChange4(object sender, EventArgs e)
        {
            if (check4.Checked == true)
            {
                check4_Hinfo.Visible = true;
                check4_Pinfo.Visible = true;
                check4_PPEinfo.Visible = true;
                check1.Enabled = false;
                check1.Checked = false;
            }
            else
            {
                check4_Hinfo.Visible = false;
                check4_Pinfo.Visible = false;
                check4_PPEinfo.Visible = false;
                check1.Enabled = true;
            }
        }
        protected void checkChange5(object sender, EventArgs e)
        {
            if (check5.Checked == true)
            {
                check5_Hinfo.Visible = true;
                check5_Pinfo.Visible = true;
                check5_PPEinfo.Visible = true;
            }
            else
            {
                check5_Hinfo.Visible = false;
                check5_Pinfo.Visible = false;
                check5_PPEinfo.Visible = false;
            }
        }
        protected void checkChange6(object sender, EventArgs e)
        {
            if (check6.Checked == true)
            {
                check6_Hinfo.Visible = true;
                check6_Pinfo.Visible = true;
                check6_PPEinfo.Visible = true;
            }
            else
            {
                check6_Hinfo.Visible = false;
                check6_Pinfo.Visible = false;
                check6_PPEinfo.Visible = false;
            }
        }
        protected void checkChange7(object sender, EventArgs e)
        {
            if (check7.Checked == true)
            {
                check7_Hinfo.Visible = true;
                check7_Pinfo.Visible = true;
                check7_PPEinfo.Visible = true;
            }
            else
            {
                check7_Hinfo.Visible = false;
                check7_Pinfo.Visible = false;
                check7_PPEinfo.Visible = false;
            }
        }
        protected void checkChange8(object sender, EventArgs e)
        {
            if (check8.Checked == true)
            {
                check8_Hinfo.Visible = true;
                check8_Pinfo.Visible = true;
                check8_PPEinfo.Visible = true;
            }
            else
            {
                check8_Hinfo.Visible = false;
                check8_Pinfo.Visible = false;
                check8_PPEinfo.Visible = false;
            }
        }
        protected void dropdownSelectedSplIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = spl_Licence1.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    // Uncheck all checkboxes for default selection
                    setInitialCheck();
                    break;
                case 1:
                    setInitialCheck();
                    check5.Checked = true;  // Check the first checkbox
                    check5.Enabled = false;
                    check6.Enabled = true;
                    check7.Enabled = true;
                    check8.Enabled = true;
                    check5_Hinfo.Visible = true;
                    check5_Pinfo.Visible = true;
                    check5_PPEinfo.Visible = true;
                    break;
                case 2:
                    setInitialCheck();
                    check6.Checked = true;
                    check6.Enabled = false;
                    check5.Enabled = true;
                    check8.Enabled = true;
                    check7.Enabled = true;
                    check6_Hinfo.Visible = true;
                    check6_Pinfo.Visible = true;
                    check6_PPEinfo.Visible = true;  // Check the second checkbox
                    break;
                case 3:
                    setInitialCheck();
                    check7.Checked = true;
                    check7.Enabled = false;
                    check5.Enabled = true;
                    check6.Enabled = true;
                    check8.Enabled = true;
                    check7_Hinfo.Visible = true;
                    check7_Pinfo.Visible = true;
                    check7_PPEinfo.Visible = true;  // Check the third checkbox
                    break;
                case 4:
                    setInitialCheck();
                    check8.Checked = true;
                    check8.Enabled = false;
                    check5.Enabled = true;
                    check6.Enabled = true;
                    check7.Enabled = true;
                    check8_Hinfo.Visible = true;
                    check8_Pinfo.Visible = true;
                    check8_PPEinfo.Visible = true;  // Check the fourth checkbox
                    break;
                default:
                    setInitialCheck();
                    break;
            }
        }
        protected void dropdownSelectedSplIndexChanged1(object sender, EventArgs e)
        {
            int selectedIndex = spl_Licence1.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    // Uncheck all checkboxes for default selection
                    check1.Checked = false;
                    check2.Checked = false;
                    check3.Checked = false;
                    check4.Checked = false;
                    break;
                case 1:
                    check1.Checked = true;  // Check the first checkbox
                    break;
                case 2:
                    check2.Checked = true;  // Check the second checkbox
                    break;
                case 3:
                    check3.Checked = true;  // Check the third checkbox
                    break;
                case 4:
                    check4.Checked = true;  // Check the fourth checkbox
                    break;
                default:
                    // Handle unexpected index values (optional)
                    break;
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["WorkerDetails"];

            DataRow dr = dt.NewRow();
            dr["NameOfWorkers"] = string.Empty;
            dr["Age"] = DBNull.Value;
            dr["Mask"] = false;
            dr["SafetyShoesGumBoots"] = false;
            dr["JacketsAprons"] = false;
            dr["Gloves"] = false;
            dr["EarPlugMuffs"] = false;
            dr["BeltHarness"] = false;
            dr["Helmet"] = false;
            dr["Remarks"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["WorkerDetails"] = dt;
            workerDetails.DataSource = dt;
            workerDetails.DataBind();
            rowCount += 1;
        }


        private void loadFormData(string permitNumber)
        {
            using (SqlConnection con = new SqlConnection(Main_con))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM permit_details_tbl_backup WHERE PermitNumber = @permitNumber", con);
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM selectedWorkpermit_TBL WHERE PermitNumber = @permitNumber", con);
                cmd1.Parameters.AddWithValue("@PermitNumber", permitNumber); // Replace with your PermitNumber parameter
                cmd2.Parameters.AddWithValue("@PermitNumber", permitNumber); // Replace with your PermitNumber parameter

                con.Open();
                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        siteName.Text = reader["SiteName"] != DBNull.Value ? reader["SiteName"].ToString() : "";
                        permitNum1.Text = reader["PermitNumber"] != DBNull.Value ? reader["PermitNumber"].ToString() : "";
                        issueDate1.Text = reader["DateofIssue"] != DBNull.Value ? Convert.ToDateTime(reader["DateofIssue"]).ToString("yyyy-MM-dd") : "";
                        perValidFrom1.Text = reader["PermitValidFrom"] != DBNull.Value ? Convert.ToDateTime(reader["PermitValidFrom"]).ToString("yyyy-MM-dd") : "";
                        perValidTill1.Text = reader["PermitValidTill"] != DBNull.Value ? Convert.ToDateTime(reader["PermitValidTill"]).ToString("yyyy-MM-dd") : "";

                        if (reader["SpecialLicense"] != DBNull.Value && Convert.ToBoolean(reader["SpecialLicense"]))
                        {
                            special_license_yes1.Checked = true;
                            special_license_no1.Checked = false;
                            if (reader["SpecialLicenseType"] != DBNull.Value)
                            {
                                spl_Licence1.SelectedValue = reader["SpecialLicenseType"].ToString();
                            }
                        }
                        else
                        {
                            special_license_yes1.Checked = false;
                            special_license_no1.Checked = true;
                            spl_Licence1.SelectedIndex = 0;
                        }

                        esiNUM1.Text = reader["ESI_InsuranceNo"] != DBNull.Value ? reader["ESI_InsuranceNo"].ToString() : "";
                        esiVali1.Text = reader["ESI_Validity"] != DBNull.Value ? Convert.ToDateTime(reader["ESI_Validity"]).ToString("yyyy-MM-dd") : "";
                        contractorNam1.Text = reader["NameofFirm_Agency"] != DBNull.Value ? reader["NameofFirm_Agency"].ToString() : "";
                        numWorkers1.Text = reader["NumberofWorkers"] != DBNull.Value ? reader["NumberofWorkers"].ToString() : "";
                        supervisorNam1.Text = reader["NameofSupervisor"] != DBNull.Value ? reader["NameofSupervisor"].ToString() : "";
                        supervisorContactNUM1.Text = reader["ContractorContactNumber"] != DBNull.Value ? reader["ContractorContactNumber"].ToString() : "";
                        araiEng1.Text = reader["ARAIEngineer"] != DBNull.Value ? reader["ARAIEngineer"].ToString() : "";
                        engiContactNUM1.Text = reader["EngineerContactNumber"] != DBNull.Value ? reader["EngineerContactNumber"].ToString() : "";
                        describeWork1.Text = reader["BriefDescriptionofWork"] != DBNull.Value ? reader["BriefDescriptionofWork"].ToString() : "";
                        locateWork1.Text = reader["LocationofWork"] != DBNull.Value ? reader["LocationofWork"].ToString() : "";
                        remark = reader["Rejected_Remark"] != DBNull.Value ? reader["Rejected_Remark"].ToString() : "";
                    }
                    else
                    {
                        Response.Redirect("viewWorkPermit.aspx");
                    }
                }
                using (SqlDataReader reader2 = cmd2.ExecuteReader())
                {
                    if (reader2.Read())
                    {
                        if (reader2["workPermit1"] != DBNull.Value && Convert.ToBoolean(reader2["workPermit1"]))
                        {
                            check1.Checked = true;
                            check1_Hinfo.Visible = true;
                            check1_Pinfo.Visible = true;
                            check1_PPEinfo.Visible = true;
                        }
                        if (reader2["workPermit2"] != DBNull.Value && Convert.ToBoolean(reader2["workPermit2"]))
                        {
                            check2.Checked = true;
                            check2_Hinfo.Visible = true;
                            check2_Pinfo.Visible = true;
                            check2_PPEinfo.Visible = true;
                        }
                        if (reader2["workPermit3"] != DBNull.Value && Convert.ToBoolean(reader2["workPermit3"]))
                        {
                            check3.Checked = true;
                            check3_Hinfo.Visible = true;
                            check3_Pinfo.Visible = true;
                            check3_PPEinfo.Visible = true;
                        }
                        if (reader2["workPermit4"] != DBNull.Value && Convert.ToBoolean(reader2["workPermit4"]))
                        {
                            check4.Checked = true;
                            check4_Hinfo.Visible = true;
                            check4_Pinfo.Visible = true;
                            check4_PPEinfo.Visible = true;
                        }
                        if (reader2["workPermit5"] != DBNull.Value && Convert.ToBoolean(reader2["workPermit5"]))
                        {
                            check5.Checked = true;
                            check5_Hinfo.Visible = true;
                            check5_Pinfo.Visible = true;
                            check5_PPEinfo.Visible = true;
                        }
                        if (reader2["workPermit6"] != DBNull.Value && Convert.ToBoolean(reader2["workPermit6"]))
                        {
                            check6.Checked = true;
                            check6_Hinfo.Visible = true;
                            check6_Pinfo.Visible = true;
                            check6_PPEinfo.Visible = true;
                        }
                        if (reader2["workPermit7"] != DBNull.Value && Convert.ToBoolean(reader2["workPermit7"]))
                        {
                            check7.Checked = true;
                            check7_Hinfo.Visible = true;
                            check7_Pinfo.Visible = true;
                            check7_PPEinfo.Visible = true;
                        }
                        if (reader2["workPermit8"] != DBNull.Value && Convert.ToBoolean(reader2["workPermit8"]))
                        {
                            check8.Checked = true;
                            check8_Hinfo.Visible = true;
                            check8_Pinfo.Visible = true;
                            check8_PPEinfo.Visible = true;
                        }
                    }
                    else
                    {
                        // Handle case where no record is found
                        Response.Redirect("viewWorkPermit.aspx");
                    }
                }
            }
        }

        private string GetClientIpAddress()
        {
            string ipAddress = HttpContext.Current.Request.UserHostAddress;

            // Check for X-Forwarded-For header for cases where the server is behind a proxy
            string xForwardedFor = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(xForwardedFor))
            {
                string[] ipAddresses = xForwardedFor.Split(',');
                if (ipAddresses.Length > 0)
                {
                    ipAddress = ipAddresses[0];
                }
            }

            // Handle IPv6 loopback address (::1) for local testing
            if (ipAddress == "::1")
            {
                ipAddress = "127.0.0.1";
            }

            return ipAddress;
        }
        public void special_license_CheckedChanged1(object sender, EventArgs e)
        {
            spl_Licence1.Visible = special_license_yes1.Checked;
        }
        protected void submitForm(object sender, EventArgs e)
        {
            string isFileUpload = fileUpload();
            if (isFileUpload != null)
            {
                editFormOperations();
            }
            else
            {
                Response.Write("<script>alert('Error uploading File');</script>");
            }
        }
        public void editFormOperations()
        {
            string permitNumber = permitNum1.Text;
            string siteNameValue = siteName.Text;
            DateTime? dateOfIssueValue = string.IsNullOrEmpty(issueDate1.Text) ? (DateTime?)null : Convert.ToDateTime(issueDate1.Text);
            DateTime? permitValidFromValue = string.IsNullOrEmpty(perValidFrom1.Text) ? (DateTime?)null : Convert.ToDateTime(perValidFrom1.Text);
            DateTime? permitValidTillValue = string.IsNullOrEmpty(perValidTill1.Text) ? (DateTime?)null : Convert.ToDateTime(perValidTill1.Text);
            bool specialLicenseValue = special_license_yes1.Checked;
            string specialLicenseTypeValue = specialLicenseValue ? spl_Licence1.SelectedValue : null;
            string esiNumValue = esiNUM1.Text;
            DateTime? esiValiValue = string.IsNullOrEmpty(esiVali1.Text) ? (DateTime?)null : Convert.ToDateTime(esiVali1.Text);
            string contractorNamValue = contractorNam1.Text;
            int? numWorkersValue = string.IsNullOrEmpty(numWorkers1.Text) ? (int?)null : Convert.ToInt32(numWorkers1.Text);
            numWorkersValue = numWorkersValue + rowCount;
            string supervisorNamValue = supervisorNam1.Text;
            string supervisorContactNumValue = supervisorContactNUM1.Text;
            string araiEngValue = araiEng1.Text;
            string engiContactNumValue = engiContactNUM1.Text;
            string describeWorkValue = describeWork1.Text;
            string locateWorkValue = locateWork1.Text;
            string deptIssuedValue = deptName;
            string remarkValue = remark;
            string fileName = fileParts.fileName;
            string filePath = fileParts.filePath;
            string fileExtention = fileParts.fIleExtention;
            bool isCloseValue = false;
            bool rejectedValue = false;
            string check1Txt = "";
            string check2Txt = "";
            string check3Txt = "";
            string check4Txt = "";
            string check5Txt = "";
            string check6Txt = "";
            string check7Txt = "";
            string check8Txt = "";
            string selectedWorkPer = "";

            //CheckBox bottons
            if (check1.Checked)
            {
                check1Txt = check1.Text;
            }
            if (check2.Checked)
            {
                check2Txt = check2.Text;
            }
            if (check3.Checked)
            {
                check3Txt = check3.Text;
            }
            if (check4.Checked)
            {
                check4Txt = check4.Text;
            }
            if (check5.Checked)
            {
                check5Txt = check5.Text;
            }
            if (check6.Checked)
            {
                check6Txt = check6.Text;
            }
            if (check7.Checked)
            {
                check7Txt = check7.Text;
            }
            if (check8.Checked)
            {
                check8Txt = check8.Text;
            }
            if (!check1.Checked && !check2.Checked && !check3.Checked && !check4.Checked && !check5.Checked && !check6.Checked && !check7.Checked && !check8.Checked)
            {
                Response.Write("<script>alert('Please select a work permit!');</script>");
                return;
            }
            selectedWorkPer = "|" + check1Txt + "|" + check2Txt + "|" + check3Txt + "|" + check4Txt + "|" + check5Txt + "|" + check6Txt + "|" + check7Txt + "|" + check8Txt + "|";

            workernum = numWorkersValue;

            try
            {
                using (SqlConnection con = new SqlConnection(Main_con))
                {
                    SqlCommand cmd = new SqlCommand("SaveOrUpdatePermitDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PermitNumber", permitNumber);
                    cmd.Parameters.AddWithValue("@SiteName", (object)siteNameValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateofIssue", (object)dateOfIssueValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PermitValidFrom", (object)permitValidFromValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PermitValidTill", (object)permitValidTillValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SpecialLicense", specialLicenseValue);
                    cmd.Parameters.AddWithValue("@SpecialLicenseType", (object)specialLicenseTypeValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ESI_InsuranceNo", (object)esiNumValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ESI_Validity", (object)esiValiValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NameofFirm_Agency", (object)contractorNamValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NumberofWorkers", (object)numWorkersValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NameofSupervisor", (object)supervisorNamValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ContractorContactNumber", (object)supervisorContactNumValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ARAIEngineer", (object)araiEngValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EngineerContactNumber", (object)engiContactNumValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BriefDescriptionofWork", (object)describeWorkValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LocationofWork", (object)locateWorkValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DeptIssued", (object)deptIssuedValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FileName", (object)fileName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FilePath", (object)filePath ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FileExtention", (object)fileExtention ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Today.Date);

                    cmd.Parameters.AddWithValue("@workPermit1", check1.Checked);
                    cmd.Parameters.AddWithValue("@workPermit2", check2.Checked);
                    cmd.Parameters.AddWithValue("@workPermit3", check3.Checked);
                    cmd.Parameters.AddWithValue("@workPermit4", check4.Checked);
                    cmd.Parameters.AddWithValue("@workPermit5", check5.Checked);
                    cmd.Parameters.AddWithValue("@workPermit6", check6.Checked);
                    cmd.Parameters.AddWithValue("@workPermit7", check7.Checked);
                    cmd.Parameters.AddWithValue("@workPermit8", check8.Checked);
                    submitWorkerDetails(permitNumber);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                // Redirect or show a message after successful submission
                Response.Redirect("viewWorkPermit.aspx"); // Redirect to a success page or any other appropriate action
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert({ex.Message});</script>");
            }
        }
        protected void submitWorkerDetails(string permitNumber)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Main_con))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();

                    foreach (GridViewRow row in workerDetails.Rows)
                    {
                        TextBox txtName = (TextBox)row.FindControl("TextBox1");
                        TextBox txtAge = (TextBox)row.FindControl("TextBox2");
                        CheckBox chkMask = (CheckBox)row.FindControl("CheckBox1");
                        CheckBox chkSafetyShoes = (CheckBox)row.FindControl("CheckBox2");
                        CheckBox chkJacketsAprons = (CheckBox)row.FindControl("CheckBox3");
                        CheckBox chkGloves = (CheckBox)row.FindControl("CheckBox4");
                        CheckBox chkEarPlugMuffs = (CheckBox)row.FindControl("CheckBox5");
                        CheckBox chkBeltHarness = (CheckBox)row.FindControl("CheckBox6");
                        CheckBox chkHelmet = (CheckBox)row.FindControl("CheckBox7");
                        TextBox txtRemarks = (TextBox)row.FindControl("TextBox3");

                        HiddenField hfWorkerID = (HiddenField)row.FindControl("hfWorkerID");

                        string workerID = hfWorkerID.Value;

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.Transaction = transaction;

                        if (!string.IsNullOrEmpty(workerID))
                        {
                            // Update existing worker details
                            cmd.CommandText = "UPDATE [dbo].[Workers] SET NameOfWorkers = @Name, Age = @Age, Mask = @Mask, SafetyShoesGumBoots = @SafetyShoes, JacketsAprons = @JacketsAprons, Gloves = @Gloves, EarPlugMuffs = @EarPlugMuffs, BeltHarness = @BeltHarness, Helmet = @Helmet, Remarks = @Remarks WHERE Id = @WorkerID";
                            cmd.Parameters.AddWithValue("@WorkerID", workerID);
                        }
                        else
                        {
                            // Insert new worker details
                            cmd.CommandText = "INSERT INTO [dbo].[Workers] (PermitNumber, NameOfWorkers, Age, Mask, SafetyShoesGumBoots, JacketsAprons, Gloves, EarPlugMuffs, BeltHarness, Helmet, Remarks) VALUES (@PermitNumber, @Name, @Age, @Mask, @SafetyShoes, @JacketsAprons, @Gloves, @EarPlugMuffs, @BeltHarness, @Helmet, @Remarks)";
                            cmd.Parameters.AddWithValue("@PermitNumber", permitNumber); // Assuming permitNumber is a class-level variable
                        }

                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Age", string.IsNullOrEmpty(txtAge.Text) ? (object)DBNull.Value : Convert.ToInt32(txtAge.Text));
                        cmd.Parameters.AddWithValue("@Mask", chkMask.Checked);
                        cmd.Parameters.AddWithValue("@SafetyShoes", chkSafetyShoes.Checked);
                        cmd.Parameters.AddWithValue("@JacketsAprons", chkJacketsAprons.Checked);
                        cmd.Parameters.AddWithValue("@Gloves", chkGloves.Checked);
                        cmd.Parameters.AddWithValue("@EarPlugMuffs", chkEarPlugMuffs.Checked);
                        cmd.Parameters.AddWithValue("@BeltHarness", chkBeltHarness.Checked);
                        cmd.Parameters.AddWithValue("@Helmet", chkHelmet.Checked);
                        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    SendEmail(permitNumber);
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }
        }

        public void SendEmail(string permitNumber)
        {
            //PermitDetails permitDetails = GetPermitDetailsByNumber(permitNumber);
            //Response.Write("<script>alert('Dept Name: " + deptName + "');</script>");
            string emailTo;
            int flag;
            string emailFrom, smtp_host, networkCredentials;
            Boolean isBodyHTML, enableSSL, useDefaultCredentials;
            int smtp_port;
            int deptCode = (int)Session["DeptCode"];
            
            using (SqlConnection con = new SqlConnection(Main_con))
            {
                using (SqlCommand cmd = new SqlCommand("usp_fetchEmail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Dept_Code", deptCode);
                    cmd.Parameters.AddWithValue("RoleID", (int)Session["RoleID"]);
                    cmd.Parameters.AddWithValue("@FormStatus", "Approved");
                    cmd.Parameters.Add("@EmailID", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
                    con.Open();
                    flag = cmd.ExecuteNonQuery();

                    // Fetch the output 
                    emailTo = cmd.Parameters["@EmailID"].Value.ToString();
                    //Response.Write("<script>alert('Email: " + email + "');</script>");

                    con.Close();

                }

                DataTable dt = new DataTable();

                using (SqlCommand cmd = new SqlCommand("exec usp_getSMTPDetails", con))
                {

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    DataRow row = dt.Rows[0];
                    emailFrom = row["EmailFrom"].ToString();
                    isBodyHTML = (Boolean)row["IsBodyHTML"];
                    smtp_host = row["SMTP_HOST"].ToString();
                    enableSSL = (Boolean)row["SMTP_EnableSSL"];
                    networkCredentials = row["NetworkCredentials"].ToString();
                    useDefaultCredentials = (Boolean)row["UseDefaultCredentials"];
                    smtp_port = Convert.ToInt32(row["SMTP_Port"]);

                }

            }

            //string from = "adityaraut1003@gmail.com";
            //string to = email; //Use exception handling here!
            try
            {
                using (MailMessage mail = new MailMessage(emailFrom, emailTo))
                {
                    mail.Subject = "Work Permit: " + permitNumber + " corrected";

                    mail.Body = "Dear DGM, \nUser " + Session["LoginID"].ToString() + " has corrected the permit " + permitNumber + ". \nKindly take further action.. \nRegards";

                    mail.IsBodyHtml = isBodyHTML; //false
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = smtp_host; //"smtp.gmail.com"
                    smtp.EnableSsl = enableSSL; //true
                    NetworkCredential networkCredential = new NetworkCredential(emailFrom, networkCredentials);
                    smtp.UseDefaultCredentials = useDefaultCredentials; //true
                    smtp.Credentials = networkCredential;
                    smtp.Port = smtp_port; //587
                    smtp.Send(mail);
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Message has been sent successfully.');", true);
                    //Response.Redirect("Welcome.aspx");
                }
            }
            catch (SmtpException smtpEx)
            {
                //Response.Write($"<script>alert('SMTP Exception: {smtpEx.Message}');</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('SMTP Exception : " + smtpEx.Message + "');", true);
            }
            catch (Exception ex)
            {
                //Response.Write($"<script>alert('General Exception: {ex.Message}');</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('General Exception : " + ex.Message + "');", true);
            }
        }
        public string fileUpload()
        {
            if (FileUpload1.HasFile)
            {
                string FileName = FileUpload1.FileName;
                string FilePath = Server.MapPath($"~/FileUploads/{FileName}");
                string FileExtension = System.IO.Path.GetExtension(FileName);
                FileUpload1.SaveAs(FilePath);
                Response.Write("<script>alert('File Uploaded.');</script>");
                fileParts.fileName = FileName;
                fileParts.filePath = FilePath;
                fileParts.fIleExtention = FileExtension;
                fileUploadedText.Visible = false;
                return FilePath;
            }
            else
            {
                Response.Write("<script>alert('Please select a file to upload');</script>");
            }
            return null;
        }
    }
}