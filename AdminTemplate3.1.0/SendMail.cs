using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace AdminTemplate3._1._0
{
    //public class SendMail
    //{
    //    HttpContext context;

    //    protected void SendEmail(string permitNumber)
    //    {
    //        PermitDetails permitDetails = GetPermitDetailsByNumber(permitNumber);
    //        if (permitDetails != null)
    //        {
    //            //Response.Write("<script>alert('Dept Name: " + deptName + "');</script>");
    //            string emailTo;
    //            int flag;

    //            string emailFrom, smtp_host, networkCredentials;
    //            Boolean isBodyHTML, enableSSL, useDefaultCredentials;
    //            int smtp_port;

    //            using (SqlConnection con = new SqlConnection(Main_con))
    //            {
    //                using (SqlCommand cmd = new SqlCommand("usp_fetchEmail", con))
    //                {
    //                    cmd.CommandType = CommandType.StoredProcedure;
    //                    cmd.Parameters.AddWithValue("@Dept_Code", deptCode);
    //                    cmd.Parameters.AddWithValue("RoleID", (int)context.Session["RoleID"]);
    //                    cmd.Parameters.AddWithValue("@FormStatus", "Approved");
    //                    cmd.Parameters.Add("@EmailID", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
    //                    con.Open();
    //                    flag = cmd.ExecuteNonQuery();

    //                    // Fetch the output 
    //                    emailTo = cmd.Parameters["@EmailID"].Value.ToString();
    //                    //Response.Write("<script>alert('Email: " + email + "');</script>");

    //                    con.Close();

    //                }

    //                DataTable dt = new DataTable();

    //                using (SqlCommand cmd = new SqlCommand("exec usp_getSMTPDetails", con))
    //                {

    //                    con.Open();
    //                    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //                    da.Fill(dt);

    //                    DataRow row = dt.Rows[0];
    //                    emailFrom = row["EmailFrom"].ToString();
    //                    isBodyHTML = (Boolean)row["IsBodyHTML"];
    //                    smtp_host = row["SMTP_HOST"].ToString();
    //                    enableSSL = (Boolean)row["SMTP_EnableSSL"];
    //                    networkCredentials = row["NetworkCredentials"].ToString();
    //                    useDefaultCredentials = (Boolean)row["UseDefaultCredentials"];
    //                    smtp_port = Convert.ToInt32(row["SMTP_Port"]);

    //                }

    //            }

    //            //string from = "adityaraut1003@gmail.com";
    //            //string to = email; //Use exception handling here!
    //            try
    //            {
    //                using (MailMessage mail = new MailMessage(emailFrom, emailTo))
    //                {
    //                    mail.Subject = "New Work Permit Created";

    //                    string body = $@"
    //                <div class='card'>
    //                    <div>
    //                        <h3>Permit Details</h3>
    //                            <h6 style='color:gray;'>{permitDetails.SiteName}</h6>
    //                            <h6 style='color:gray;'><b>Date of Issue: </b>{permitDetails.DateofIssue:dd-MM-yyyy}</h6>
    //                    </div>
    //                    <div class='card-body'>
    //                        <h5 class='card-title'>
    //                        <strong>Permit Number:</strong> {permitDetails.PermitNumber}
    //                        </h5>
    //                        <p class='card-text d-block'>
    //                        <table class='table table-bordered' style='width: 100%;'>
    //                            <tr>
    //                                <td><p><strong>Permit Valid From:</strong> {permitDetails.PermitValidFrom:dd-MM-yyyy}</p></td>
    //                                <td><p><strong>Permit Valid Till:</strong> {permitDetails.PermitValidTill:dd-MM-yyyy}</p></td>
    //                            </tr>
    //                            <tr>
    //                                <td><p><strong>Special License:</strong> {permitDetails.SpecialLicense}</p></td>
    //                                <td><p><strong>Special License Type:</strong> {permitDetails.SpecialLicenseType}</p></td>
    //                            </tr>
    //                            <tr>
    //                                <td><p><strong>ESI/Insurance No:</strong> {permitDetails.InsuranceNo}</p></td>
    //                                <td><p><strong>ESI/Insurance Validity:</strong> {permitDetails.InsuranceValidity:dd-MM-yyyy}</p></td>
    //                            </tr>
    //                            <tr>
    //                                <td><p><strong>Name of Vendor or Contractor Firm/Agency:</strong> {permitDetails.AgencyName}</p></td>
    //                                <td><p><strong>Number of workers:</strong> {permitDetails.WorkerNo}</p></td>
    //                            </tr>
    //                            <tr>
    //                                <td><p><strong>Worker Details:</strong> permitDetails.WorkerDetails</p></td>
    //                            </tr>
    //                            <tr>
    //                                <td><p><strong>Name of Vendor/Contractor Supervisor:</strong> {permitDetails.ContractorName}</p></td>
    //                                <td><p><strong>Contact Number (Contractor):</strong> {permitDetails.ContractorNo}</p></td>
    //                            </tr>
    //                            <tr>
    //                                <td><p><strong>ARAI Engineer:</strong> {permitDetails.EngineerName}</p></td>
    //                                <td><p><strong>Contact Number (Engineer):</strong> {permitDetails.EngineerNo}</p></td>
    //                            </tr>
    //                            <tr>
    //                                <td><p><strong>Brief Description of Work:</strong> {permitDetails.Description}</p></td>
    //                                <td><p><strong>Location of Work:</strong> {permitDetails.Location}</p></td>
    //                            </tr>
    //                            <tr>
    //                                <td>WorkPermits selected: {permitDetails.workPermits}</td>
    //                            </tr>
    //                        </table>
    //                        </p>
    //                    </div>
    //                </div>";

    //                    mail.Body = body;

    //                    mail.IsBodyHtml = isBodyHTML; //false
    //                    SmtpClient smtp = new SmtpClient();
    //                    smtp.Host = smtp_host; //"smtp.gmail.com"
    //                    smtp.EnableSsl = enableSSL; //true
    //                    NetworkCredential networkCredential = new NetworkCredential(emailFrom, networkCredentials);
    //                    smtp.UseDefaultCredentials = useDefaultCredentials; //true
    //                    smtp.Credentials = networkCredential;
    //                    smtp.Port = smtp_port; //587
    //                    smtp.Send(mail);
    //                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Message has been sent successfully.');", true);
    //                    Response.Redirect("Welcome.aspx");
    //                }
    //            }
    //            catch (SmtpException smtpEx)
    //            {
    //                //Response.Write($"<script>alert('SMTP Exception: {smtpEx.Message}');</script>");
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('SMTP Exception : " + smtpEx.Message + "');", true);
    //            }
    //            catch (Exception ex)
    //            {
    //                //Response.Write($"<script>alert('General Exception: {ex.Message}');</script>");
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('General Exception : " + ex.Message + "');", true);
    //            }
    //        }
    //        else
    //        {
    //            //Response.Write("<script>alert('Permit details not found.');</script>");
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Permit Details not found');", true);
    //        }

    //    }


    //}
}