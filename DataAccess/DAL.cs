using BusinessObject;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DAL
    {
        string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlCommand cmd;
        DataTable dt;
        SqlDataReader dr;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;

        #region "First"
        public int saveuseractivity(string loginid, string altrloginid, string sessionid, string page, string activity, string ipaddress)
        {
            int result = 0;
            try
            {
                using (con = new SqlConnection(constr))
                {
                    using (cmd = new SqlCommand("sp_SaveUserActivityLog", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@loginid", SqlDbType.NVarChar, 100).Value = loginid;
                        cmd.Parameters.Add("@altrloginid", SqlDbType.NVarChar, 100).Value = altrloginid;
                        cmd.Parameters.Add("@sessionid", SqlDbType.NVarChar, 100).Value = sessionid;
                        cmd.Parameters.Add("@page", SqlDbType.NVarChar, 100).Value = page;
                        cmd.Parameters.Add("@activity", SqlDbType.NVarChar, 100).Value = activity;
                        cmd.Parameters.Add("@ipaddress", SqlDbType.NVarChar, 50).Value = ipaddress;
                        cmd.Parameters.Add("@activitytime", SqlDbType.DateTime).Value = System.DateTime.Now;

                        con.Open();
                        result = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                return result;
            }
            catch
            {
                throw;
            }
            finally
            {

                cmd.Dispose();
                con.Close();
            }
        }
        public int SendFeedbackForm(SaveBO ObjSaveBO)
        {
            int result = 0;
            try
            {
                using (con = new SqlConnection(constr))
                {
                    using (cmd = new SqlCommand("sp_SendFeedbackForm", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ASSESSE", SqlDbType.NVarChar, 100).Value = ObjSaveBO.ASSESSE;
                        cmd.Parameters.Add("@ASSESSOR", SqlDbType.NVarChar, 100).Value = ObjSaveBO.ASSESSOR;
                        //cmd.Parameters.Add("@ASSESSE_CODE", SqlDbType.Int).Value = ObjSaveBO.ASSESSE_CODE;
                        //cmd.Parameters.Add("@ASSESSOR_CODE", SqlDbType.Int).Value = ObjSaveBO.ASSESSOR_CODE;
                        //cmd.Parameters.Add("@ICSF_MONTH", SqlDbType.NVarChar, 100).Value = ObjSaveBO.ICSF_MONTH;
                        //cmd.Parameters.Add("@F_YEAR", SqlDbType.NVarChar, 100).Value = ObjSaveBO.F_YEAR;  
                        //if (ObjSaveBO.FileAttachment == "N")
                        //{
                        //    cmd.Parameters.Add("@FUploadDate", SqlDbType.DateTime).Value = DBNull.Value;
                        //}
                        //else
                        //{
                        //    cmd.Parameters.Add("@FUploadDate", SqlDbType.DateTime).Value = System.DateTime.Now;
                        //}
                        //cmd.Parameters.Add("@FilePath", SqlDbType.NVarChar, 350).Value = ObjSaveBO.FilePath;
                        //cmd.Parameters.Add("@FileAttachment", SqlDbType.NVarChar, 2).Value = ObjSaveBO.FileAttachment;
                        con.Open();
                        result = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                return result;
            }
            catch
            {
                throw;
            }
            finally
            {

                cmd.Dispose();
                con.Close();
            }
        }
        public int saveuserloginsession(string loginid, string sessionid, string ipaddress, string userrole, string actiontype)
        {
            int result = 0;
            try
            {
                using (con = new SqlConnection(constr))
                {
                    using (cmd = new SqlCommand("Icss_saveuserloginsession", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@loginid", SqlDbType.NVarChar, 50).Value = loginid;
                        cmd.Parameters.Add("@session_id", SqlDbType.NVarChar, 100).Value = sessionid;
                        cmd.Parameters.Add("@session_time", SqlDbType.DateTime).Value = System.DateTime.Now;
                        cmd.Parameters.Add("@ipaddress", SqlDbType.NVarChar, 50).Value = ipaddress;
                        cmd.Parameters.Add("@userrole", SqlDbType.NVarChar, 10).Value = userrole;
                        cmd.Parameters.Add("@activitytime", SqlDbType.DateTime).Value = System.DateTime.Now;
                        cmd.Parameters.Add("@actiontype", SqlDbType.NVarChar, 20).Value = actiontype;

                        con.Open();
                        result = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                return result;
            }
            catch
            {
                throw;
            }
            finally
            {

                cmd.Dispose();
                con.Close();
            }
        }
        public DataSet GetUserLogin(string userid)
        {
            ds = new DataSet();
            // SqlDataAdapter da;
            try
            {
                using (con = new SqlConnection(constr))
                {
                    using (cmd = new SqlCommand("sp_GetUserLogin", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@userid", SqlDbType.NVarChar, 200).Value = userid;
                        //cmd.Parameters.Add("@password", SqlDbType.NVarChar, 100).Value = password;
                        con.Open();
                        using (da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                ds.Dispose();
                cmd.Dispose();
                con.Close();
            }
        }
        public DataTable ForgotPassword(string emailid)
        {
            dt = new DataTable();
            // SqlDataAdapter da;
            try
            {
                using (con = new SqlConnection(constr))
                {
                    using (cmd = new SqlCommand("sp_ForgotPassword", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@userid", SqlDbType.NVarChar, 100).Value = emailid;
                        con.Open();
                        using (da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        return dt;
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                dt.Dispose();
                cmd.Dispose();
                con.Close();
            }
        }
        #endregion "First"
    }
}

