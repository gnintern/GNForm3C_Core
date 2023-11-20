using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Net.Mail;
using GNForm3C_.Areas.SEC_User.Models;
using GNForm3C_.BAL;

namespace GNForm3C_.DAL
{
    public class SEC_DALBase: DAL_Helper
	{
        
		#region Method: dbo_PR_SEC_User_SelectByUserNamePassword
		public DataTable PR_SEC_User_SelectByUserNamePassword(string UserName,string Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_User_SelectByUserNamePassword");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, UserName);   
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, Password);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
		#endregion
        
    }
}
