using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTemplate3._1._0
{
    public partial class Welcome : System.Web.UI.Page
    {
        public int deptCode;
        string Main_con = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
        public string deptName;
        public void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["RoleID"] == 1)
            {
                Response.Redirect("Homepage.aspx");
            }

            if (Session["DeptName"] != null)
            {
                deptName = Session["DeptName"].ToString();
            }

            deptCode = (int)Session["DeptCode"];

            if (!IsPostBack)
            {
                arai_Engineer_list();
                splWorkPermit_list();
            }

            if (!Page.IsPostBack)
            {
                SetInitialRow();
            }
        }

        public void arai_Engineer_list()
        {
            SqlConnection sqlcon = new SqlConnection(Main_con);
            sqlcon.Open();
            SqlCommand sql_command = new SqlCommand("SELECT * FROM [dbo].[engineer_name_tbl]", sqlcon);
            sql_command.CommandType = CommandType.Text;
            araiEng.DataSource = sql_command.ExecuteReader();
            araiEng.DataTextField = "EngineerName";
            araiEng.DataBind();
            araiEng.Items.Insert(0, new ListItem("-- Select Engineer Name --", "0"));
        }

        public void splWorkPermit_list()
        {
            SqlConnection sqlcon = new SqlConnection(Main_con);
            sqlcon.Open();
            SqlCommand sql_command = new SqlCommand("SELECT Work_Permit FROM [dbo].[WorkPermit] WHERE Spl_License=1", sqlcon);
            sql_command.CommandType = CommandType.Text;
            spl_Licence.DataSource = sql_command.ExecuteReader();
            spl_Licence.DataTextField = "Work_Permit";
            spl_Licence.DataBind();
            spl_Licence.Items.Insert(0, new ListItem("-- Select Special Work Permit --", "0"));
        }

        public void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Name of Workers", typeof(string)));
            dt.Columns.Add(new DataColumn("AGE", typeof(int)));
            dt.Columns.Add(new DataColumn("Mask", typeof(bool)));
            dt.Columns.Add(new DataColumn("Safety Shoes/ Gum Boots", typeof(bool)));
            dt.Columns.Add(new DataColumn("Jackets/ Aprons", typeof(bool)));
            dt.Columns.Add(new DataColumn("Gloves", typeof(bool)));
            dt.Columns.Add(new DataColumn("Ear plug/ muffs", typeof(bool)));
            dt.Columns.Add(new DataColumn("Belt/ Harness", typeof(bool)));
            dt.Columns.Add(new DataColumn("Helmet", typeof(bool)));
            dt.Columns.Add(new DataColumn("Remarks", typeof(string)));

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Name of Workers"] = string.Empty;
            dr["AGE"] = 0;
            dr["Mask"] = true;
            dr["Safety Shoes/ Gum Boots"] = true;
            dr["Jackets/ Aprons"] = true;
            dr["Gloves"] = true;
            dr["Ear plug/ muffs"] = true;
            dr["Belt/ Harness"] = true;
            dr["Helmet"] = true;
            dr["Remarks"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        public void AddNewRowToGrid()
        {
            int workerNum = Convert.ToInt32(numWorkers.Text.Trim());
            DataTable CurrentTableCount = (DataTable)ViewState["CurrentTable"];
            int rowIndex = 0;

            if (CurrentTableCount.Rows.Count >= workerNum)
            {
                //Response.Write($"<script>alert('You cannot add more than {workerNum} worker details. Please check number of workers!');</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You cannot add more than "+workerNum+" worker details. Please check number of workers!');", true);
            }
            else
            {
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                    DataRow drCurrentRow = null;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            TextBox box1 = (TextBox)GridView1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                            TextBox box2 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                            CheckBox chk1 = (CheckBox)GridView1.Rows[rowIndex].Cells[3].FindControl("CheckBox1");
                            CheckBox chk2 = (CheckBox)GridView1.Rows[rowIndex].Cells[4].FindControl("CheckBox2");
                            CheckBox chk3 = (CheckBox)GridView1.Rows[rowIndex].Cells[5].FindControl("CheckBox3");
                            CheckBox chk4 = (CheckBox)GridView1.Rows[rowIndex].Cells[6].FindControl("CheckBox4");
                            CheckBox chk5 = (CheckBox)GridView1.Rows[rowIndex].Cells[7].FindControl("CheckBox5");
                            CheckBox chk6 = (CheckBox)GridView1.Rows[rowIndex].Cells[8].FindControl("CheckBox6");
                            CheckBox chk7 = (CheckBox)GridView1.Rows[rowIndex].Cells[9].FindControl("CheckBox7");
                            TextBox box3 = (TextBox)GridView1.Rows[rowIndex].Cells[10].FindControl("TextBox3");

                            dtCurrentTable.Rows[i - 1]["Name of Workers"] = box1.Text;
                            dtCurrentTable.Rows[i - 1]["AGE"] = box2.Text;
                            dtCurrentTable.Rows[i - 1]["Mask"] = chk1.Checked;
                            dtCurrentTable.Rows[i - 1]["Safety Shoes/ Gum Boots"] = chk2.Checked;
                            dtCurrentTable.Rows[i - 1]["Jackets/ Aprons"] = chk3.Checked;
                            dtCurrentTable.Rows[i - 1]["Gloves"] = chk4.Checked;
                            dtCurrentTable.Rows[i - 1]["Ear plug/ muffs"] = chk5.Checked;
                            dtCurrentTable.Rows[i - 1]["Belt/ Harness"] = chk6.Checked;
                            dtCurrentTable.Rows[i - 1]["Helmet"] = chk7.Checked;
                            dtCurrentTable.Rows[i - 1]["Remarks"] = box3.Text;

                            rowIndex++;
                        }

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                        dtCurrentTable.Rows.Add(drCurrentRow);
                        ViewState["CurrentTable"] = dtCurrentTable;
                        GridView1.DataSource = dtCurrentTable;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    Response.Write("ViewState is null");
                }
                SetPreviousData();
            }
        }

        public void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)GridView1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        CheckBox chk1 = (CheckBox)GridView1.Rows[rowIndex].Cells[3].FindControl("CheckBox1");
                        CheckBox chk2 = (CheckBox)GridView1.Rows[rowIndex].Cells[4].FindControl("CheckBox2");
                        CheckBox chk3 = (CheckBox)GridView1.Rows[rowIndex].Cells[5].FindControl("CheckBox3");
                        CheckBox chk4 = (CheckBox)GridView1.Rows[rowIndex].Cells[6].FindControl("CheckBox4");
                        CheckBox chk5 = (CheckBox)GridView1.Rows[rowIndex].Cells[7].FindControl("CheckBox5");
                        CheckBox chk6 = (CheckBox)GridView1.Rows[rowIndex].Cells[8].FindControl("CheckBox6");
                        CheckBox chk7 = (CheckBox)GridView1.Rows[rowIndex].Cells[9].FindControl("CheckBox7");
                        TextBox box3 = (TextBox)GridView1.Rows[rowIndex].Cells[10].FindControl("TextBox3");

                        box1.Text = dt.Rows[i]["Name of Workers"].ToString();
                        box2.Text = dt.Rows[i]["AGE"].ToString();
                        chk1.Checked = dt.Rows[i]["Mask"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[i]["Mask"]) : false;
                        chk2.Checked = dt.Rows[i]["Safety Shoes/ Gum Boots"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[i]["Safety Shoes/ Gum Boots"]) : false;
                        chk3.Checked = dt.Rows[i]["Jackets/ Aprons"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[i]["Jackets/ Aprons"]) : false;
                        chk4.Checked = dt.Rows[i]["Gloves"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[i]["Gloves"]) : false;
                        chk5.Checked = dt.Rows[i]["Ear plug/ muffs"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[i]["Ear plug/ muffs"]) : false;
                        chk6.Checked = dt.Rows[i]["Belt/ Harness"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[i]["Belt/ Harness"]) : false;
                        chk7.Checked = dt.Rows[i]["Helmet"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[i]["Helmet"]) : false;
                        box3.Text = dt.Rows[i]["Remarks"].ToString();

                        rowIndex++;
                    }
                }
            }
        }
        public int SaveDataToDatabase(string permitNumber)
        {
            using (SqlConnection conn = new SqlConnection(Main_con))
            {
                conn.Open();

                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        TextBox box1 = (TextBox)row.Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)row.Cells[2].FindControl("TextBox2");
                        CheckBox chk1 = (CheckBox)row.Cells[3].FindControl("CheckBox1");
                        CheckBox chk2 = (CheckBox)row.Cells[4].FindControl("CheckBox2");
                        CheckBox chk3 = (CheckBox)row.Cells[5].FindControl("CheckBox3");
                        CheckBox chk4 = (CheckBox)row.Cells[6].FindControl("CheckBox4");
                        CheckBox chk5 = (CheckBox)row.Cells[7].FindControl("CheckBox5");
                        CheckBox chk6 = (CheckBox)row.Cells[8].FindControl("CheckBox6");
                        CheckBox chk7 = (CheckBox)row.Cells[9].FindControl("CheckBox7");
                        TextBox box3 = (TextBox)row.Cells[10].FindControl("TextBox3");

                        using (SqlCommand cmd = new SqlCommand("InsertWorkerData", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@PermitNumber", permitNumber);
                            cmd.Parameters.AddWithValue("@RowNumber", int.Parse(row.Cells[0].Text));
                            cmd.Parameters.AddWithValue("@NameOfWorkers", box1.Text);
                            cmd.Parameters.AddWithValue("@Age", int.Parse(box2.Text));
                            cmd.Parameters.AddWithValue("@Mask", chk1.Checked);
                            cmd.Parameters.AddWithValue("@SafetyShoesGumBoots", chk2.Checked);
                            cmd.Parameters.AddWithValue("@JacketsAprons", chk3.Checked);
                            cmd.Parameters.AddWithValue("@Gloves", chk4.Checked);
                            cmd.Parameters.AddWithValue("@EarPlugMuffs", chk5.Checked);
                            cmd.Parameters.AddWithValue("@BeltHarness", chk6.Checked);
                            cmd.Parameters.AddWithValue("@Helmet", chk7.Checked);
                            cmd.Parameters.AddWithValue("@Remarks", box3.Text);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                //Response.Write($"<script>alert('Exception: {ex.Message}');</script>");
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Exception " + ex.Message + "');", true);
                                return 0;
                            }
                        }
                    }
                }
            }
            return 1;
        }

        public void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }


        public void special_license_CheckedChanged(object sender, EventArgs e)
        {
            spl_Licence.Visible = special_license_yes.Checked;
        }
        public void WPcheckBox_Load(object sender, EventArgs e) { }

        public int validateDates(DateTime dateOfIssue, DateTime validFrom, DateTime validTill)
        {
            int flag = 0;
            TimeSpan diff = validTill.Subtract(validFrom);
            if (dateOfIssue > validTill)
            {
                flag = -1;
                //Response.Write("<script> alert('Valid Till Date cannot be earlier than Date of Issue!'); </script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Valid Till Date cannot be earlier than Date of Issue!');", true);
            }
            else if (dateOfIssue.Date > validFrom)
            {
                flag = -1;
                //Response.Write("<script> alert('Valid From Date cannot be earlier than Date of Issue!'); </script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Valid From Date cannot be earlier than Date of Issue!');", true);
            }
            else if (diff.Days > 15)
            {
                flag = -1;
                //Response.Write("<script> alert('Valid Till Date cannot exceed 15 days!'); </script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Valid Till Date cannot exceed 15 days!');", true);
            }
            return flag;
        }

        public void FormOpreations()
        {
            // Obtain values from the permit form
            String siteName = site.SelectedValue;
            String permitNumber = permitNum.Text.Trim();
            DateTime dateOfIssue = Convert.ToDateTime(issueDate.Text.Trim());
            DateTime validFrom = Convert.ToDateTime(perValidFrom.Text.Trim());
            DateTime validTill = Convert.ToDateTime(perValidTill.Text.Trim());
            String createdBy = Session["LoginID"].ToString();
            int flag = validateDates(dateOfIssue, validFrom, validTill);
            int WDdone = 0;

            if (flag < 0)
            {
                return;
            }

            bool hasSpecialLicenseYES = special_license_yes.Checked;
            String splWork = "NO SPL Licence";
            if (hasSpecialLicenseYES == true)
            {
                splWork = spl_Licence.SelectedValue;
            }
            String esiNumber = esiNUM.Text.Trim();
            DateTime esiValidity = Convert.ToDateTime(esiVali.Text.Trim());
            String contractorName = contractorNam.Text.Trim();
            int workerNum = Convert.ToInt32(numWorkers.Text.Trim());
            String supervisorName = supervisorNam.Text.Trim();
            String supervisorContact = supervisorContactNUM.Text.Trim();
            String engineerName = araiEng.SelectedValue;
            String engiContact = engiContactNUM.Text.Trim();
            String workDescription = describeWork.Text.Trim();
            String workLocation = locateWork.Text.Trim();
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
                //Response.Write("<script>alert('Please select a work permit!');</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please select a work permit!');", true);
                return;
            }
            selectedWorkPer = "|" + check1Txt + "|" + check2Txt + "|" + check3Txt + "|" + check4Txt + "|" + check5Txt + "|" + check6Txt + "|" + check7Txt + "|" + check8Txt + "|";

            try
            {
                int result = 0;
                // Insert permit details
                using (SqlConnection con = new SqlConnection(Main_con))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_workPermit_tbl", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PermitNumber", permitNumber);
                        cmd.Parameters.AddWithValue("@DateOfIssue", dateOfIssue);
                        cmd.Parameters.AddWithValue("@PermitValidFrom", validFrom);
                        cmd.Parameters.AddWithValue("@PermitValidTill", validTill);
                        cmd.Parameters.AddWithValue("@SpecialLicense", hasSpecialLicenseYES);
                        cmd.Parameters.AddWithValue("@SplLicenseType", splWork);
                        cmd.Parameters.AddWithValue("@ESIInsuranceNo", esiNumber);
                        cmd.Parameters.AddWithValue("@ESIValidity", esiValidity);
                        cmd.Parameters.AddWithValue("@NameofAgency", contractorName);
                        cmd.Parameters.AddWithValue("@NumOfWorkers", workerNum);
                        cmd.Parameters.AddWithValue("@NameofContractor", supervisorName);
                        cmd.Parameters.AddWithValue("@ContractorContact", supervisorContact);
                        cmd.Parameters.AddWithValue("@ARAIEngineer", engineerName);
                        cmd.Parameters.AddWithValue("@EngineerContact", engiContact);
                        cmd.Parameters.AddWithValue("@DescofWork", workDescription);
                        cmd.Parameters.AddWithValue("@Location", workLocation);
                        cmd.Parameters.AddWithValue("@DeptIssued", deptName);
                        cmd.Parameters.AddWithValue("@PermitsIssued", selectedWorkPer);
                        cmd.Parameters.AddWithValue("@SiteName", siteName);
                        cmd.Parameters.AddWithValue("@CreatedBy", createdBy);
                        cmd.Parameters.AddWithValue("@DeptIssuedCode", deptCode);
                        con.Open();
                        // Execute the command and get the result
                        result = cmd.ExecuteNonQuery();
                        con.Close();
                        WDdone = SaveDataToDatabase(permitNumber);
                        if (WDdone == 1)
                        {
                            if (result > 0)
                            {
                                //Response.Write("<script>alert('Data added Successfully.');</script>");
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Added Successfully');", true);
                                try
                                {
                                    SendEmail(dateOfIssue, permitNumber);
                                }
                                catch (Exception ex)
                                {
                                    //Response.Write("<script> alert(" + ex.Message + "); </script>");
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message + "!');", true);
                                }
                            }
                            else
                            {
                                //Response.Write("<script>alert('Data updatation UnSuccessfully. Try Again');</script>");
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Updation Unsuccessful. Try again');", true);

                            }
                        }
                        else
                        {
                            //Response.Write("<script>alert('Error storing Workers Data');</script>");
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error storing worker data');", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Response.Write($"<script>alert('Exception: {ex.Message}');</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Exception " + ex.Message +"');", true);
            }
        }
        public void SubmitFrom(object sender, EventArgs e)
        {
            FormOpreations();
        }

        public PermitDetails GetPermitDetailsByNumber(string permitNumber)
        {
            PermitDetails permitDetails = null;
            using (SqlConnection con = new SqlConnection(Main_con))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM permit_details_tbl_backup WHERE PermitNumber = @PermitNumber", con))
                {
                    cmd.Parameters.AddWithValue("@PermitNumber", permitNumber);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            permitDetails = new PermitDetails
                            {
                                SiteName = reader["SiteName"].ToString(),
                                PermitNumber = reader["PermitNumber"].ToString(),
                                DateofIssue = reader["DateofIssue"].ToString(),
                                PermitValidFrom = reader["PermitValidFrom"].ToString(),
                                PermitValidTill = reader["PermitValidTill"].ToString(),
                                SpecialLicense = reader["SpecialLicense"].ToString(),
                                SpecialLicenseType = reader["SpecialLicenseType"].ToString(),
                                InsuranceNo = reader["ESI_InsuranceNo"].ToString(),
                                InsuranceValidity = reader["ESI_Validity"].ToString(),
                                AgencyName = reader["NameofFirm_Agency"].ToString(),
                                WorkerNo = reader["NumberofWorkers"].ToString(),
                                ContractorName = reader["NameofSupervisor"].ToString(),
                                ContractorNo = reader["ContractorContactNumber"].ToString(),
                                EngineerName = reader["ARAIEngineer"].ToString(),
                                EngineerNo = reader["EngineerContactNumber"].ToString(),
                                Description = reader["BriefDescriptionofWork"].ToString(),
                                Location = reader["LocationofWork"].ToString(),
                                DeptIssued = reader["DeptIssued"].ToString(),
                                workPermits = reader["PermitsIssued"].ToString()
                            };

                        }
                    }
                    catch (Exception ex)
                    {
                        //Response.Write("<script>console.log('Error reading from database: " + ex.Message + "');</script>");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error reading from database: " + ex.Message + "');", true);
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }
            return permitDetails;
        }
        protected void SendEmail(DateTime dateOfIssue, string permitNumber)
        {
            PermitDetails permitDetails = GetPermitDetailsByNumber(permitNumber);
            if (permitDetails != null)
            {
                //Response.Write("<script>alert('Dept Name: " + deptName + "');</script>");
                string emailTo;
                int flag;

                string emailFrom, smtp_host, networkCredentials;
                Boolean isBodyHTML, enableSSL, useDefaultCredentials;
                int smtp_port;

                using (SqlConnection con = new SqlConnection(Main_con))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_fetchEmail", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Dept_Code", deptCode);
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
                        mail.Subject = "New Work Permit Created";

                        string body = $@"
                    <div class='card'>
                        <div>
                            <h3>Permit Details</h3>
                                <h6 style='color:gray;'>{permitDetails.SiteName}</h6>
                                <h6 style='color:gray;'><b>Date of Issue: </b>{permitDetails.DateofIssue:dd-MM-yyyy}</h6>
                        </div>
                        <div class='card-body'>
                            <h5 class='card-title'>
                            <strong>Permit Number:</strong> {permitDetails.PermitNumber}
                            </h5>
                            <p class='card-text d-block'>
                            <table class='table table-bordered' style='width: 100%;'>
                                <tr>
                                    <td><p><strong>Permit Valid From:</strong> {permitDetails.PermitValidFrom:dd-MM-yyyy}</p></td>
                                    <td><p><strong>Permit Valid Till:</strong> {permitDetails.PermitValidTill:dd-MM-yyyy}</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>Special License:</strong> {permitDetails.SpecialLicense}</p></td>
                                    <td><p><strong>Special License Type:</strong> {permitDetails.SpecialLicenseType}</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>ESI/Insurance No:</strong> {permitDetails.InsuranceNo}</p></td>
                                    <td><p><strong>ESI/Insurance Validity:</strong> {permitDetails.InsuranceValidity:dd-MM-yyyy}</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>Name of Vendor or Contractor Firm/Agency:</strong> {permitDetails.AgencyName}</p></td>
                                    <td><p><strong>Number of workers:</strong> {permitDetails.WorkerNo}</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>Worker Details:</strong> permitDetails.WorkerDetails</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>Name of Vendor/Contractor Supervisor:</strong> {permitDetails.ContractorName}</p></td>
                                    <td><p><strong>Contact Number (Contractor):</strong> {permitDetails.ContractorNo}</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>ARAI Engineer:</strong> {permitDetails.EngineerName}</p></td>
                                    <td><p><strong>Contact Number (Engineer):</strong> {permitDetails.EngineerNo}</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>Brief Description of Work:</strong> {permitDetails.Description}</p></td>
                                    <td><p><strong>Location of Work:</strong> {permitDetails.Location}</p></td>
                                </tr>
                                <tr>
                                    <td>WorkPermits selected: {permitDetails.workPermits}</td>
                                </tr>
                            </table>
                            </p>
                        </div>
                    </div>";

                        mail.Body = body;

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
                        Response.Redirect("Welcome.aspx");
                    }
                }
                catch (SmtpException smtpEx)
                {
                    //Response.Write($"<script>alert('SMTP Exception: {smtpEx.Message}');</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('SMTP Exception : "+ smtpEx.Message +"');", true);
                }
                catch (Exception ex)
                {
                    //Response.Write($"<script>alert('General Exception: {ex.Message}');</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('General Exception : " + ex.Message + "');", true);
                }
            }
            else
            {
                //Response.Write("<script>alert('Permit details not found.');</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Permit Details not found');", true);
            }

        }
    }
}