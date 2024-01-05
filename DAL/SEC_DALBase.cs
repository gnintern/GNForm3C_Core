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
        #region SEC_User

        #region PR_SEC_User_SelectAll
        public DataTable PR_SEC_User_SelectAll(SEC_UserModel modelSEC_User)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_User_SelectAll");
                DataTable dt = new DataTable();

                if (modelSEC_User.HospitalID != null || modelSEC_User.UserName != null)
                {
                    dbCMD = sqldb.GetStoredProcCommand("PR_User_SelectByUserNameHospital");
                    sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelSEC_User.HospitalID);
                    sqldb.AddInParameter(dbCMD, "UserName", SqlDbType.NVarChar, modelSEC_User.UserName);
                }

                using (IDataReader dr = sqldb.ExecuteReader(dbCMD))
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

        #region PR_User_Delete
        public bool? PR_User_Delete(int UserID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_User_Delete");

                sqldb.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);


                int vResultValue = sqldb.ExecuteNonQuery(dbCMD);
                //return (vResultValue == -1 ? false : true);
                return (vResultValue == -1 ? true : false);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_User_SelectPK
        public DataTable PR_User_SelectPK(int? UserID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_User_SelectPK");

                sqldb.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqldb.ExecuteReader(dbCMD))
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

        #region PR_User_Insert
        public bool? PR_User_Insert(SEC_UserModel modelSEC_User)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_User_Insert");
                sqldb.AddOutParameter(dbCMD, "UserID", SqlDbType.Int, 4);
                sqldb.AddInParameter(dbCMD, "UserName", SqlDbType.NVarChar, modelSEC_User.UserName);
                sqldb.AddInParameter(dbCMD, "Password", SqlDbType.NVarChar, modelSEC_User.Password);
                sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelSEC_User.HospitalID);
                sqldb.AddInParameter(dbCMD, "IsActive", SqlDbType.Bit, modelSEC_User.IsActive);
                sqldb.AddInParameter(dbCMD, "Created", SqlDbType.Int, DBNull.Value);
                sqldb.AddInParameter(dbCMD, "Modified", SqlDbType.Int, DBNull.Value);

                int vResultValue = sqldb.ExecuteNonQuery(dbCMD);

                //return (vResultValue == -1 ? false : true);
                return (vResultValue == -1 ? true : false);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_User_Update
        public bool? PR_User_Update(SEC_UserModel modelSEC_User, int UserID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_User_Update");
                sqldb.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);
                sqldb.AddInParameter(dbCMD, "UserName", SqlDbType.NVarChar, modelSEC_User.UserName);
                sqldb.AddInParameter(dbCMD, "Password", SqlDbType.NVarChar, modelSEC_User.Password);
                sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelSEC_User.HospitalID);
                sqldb.AddInParameter(dbCMD, "IsActive", SqlDbType.Bit, modelSEC_User.IsActive);
                sqldb.AddInParameter(dbCMD, "Modified", SqlDbType.NVarChar, DBNull.Value);


                int result = sqldb.ExecuteNonQuery(dbCMD);
                //return (result == -1 ? false : true);
                return (result == -1 ? true : false);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region dbo_PR_SEC_User_SelectByUserNamePassword
        public DataTable PR_SEC_User_SelectByUserNamePassword(string UserName, string Password)
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

        #region PR_User_SelectByUserNamePasswordHospitalID
        public DataTable PR_User_SelectByUserNamePasswordHospitalID(Login_SEC_UserModel modelLogin_SEC_UserModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_User_SelectByUserNamePasswordHospitalID");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, modelLogin_SEC_UserModel.UserName);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, modelLogin_SEC_UserModel.Password);
                sqlDB.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelLogin_SEC_UserModel.HospitalID);

                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        #endregion
        #endregion
    }
}
