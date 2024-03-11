using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;

namespace BusinessLogic
{
    public class BLL
    {
        DAL objDAL = new DAL();
        public int saveuserloginsession(string loginid, string sessionid, string ipaddress, string userrole, string actiontype)
        {
            try
            {

                return objDAL.saveuserloginsession(loginid, sessionid, ipaddress, userrole, actiontype);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetUserLogin(string userid)
        {
            try
            {
                return objDAL.GetUserLogin(userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ForgotPassword(string emailid)
        {
            try
            {
                return objDAL.ForgotPassword(emailid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
