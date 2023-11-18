using GNForm3C_.Areas.MST_Hospital.Models;
using GNForm3C_.Areas.SEC_User.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace GNForm3C_.DAL
{
    public class MST_DALBase : DAL_Helper
    {
        #region SEC_User
        #region PR_SEC_User_SelectAll
        public DataTable PR_SEC_User_SelectAll()
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_User_SelectAll");
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

        #region Delete
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
                sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, 1);

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
        #endregion

        #region MST_Hospital
        #region PR_Hospital_SelectAll
        public DataTable PR_Hospital_SelectAll()
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Hospital_SelectAll");
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

        #region Delete
        public bool? PR_Hospital_Delete(int HospitalID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Hospital_Delete");

                sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, HospitalID);


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

        #region PR_Hospital_SelectPK
        public DataTable PR_Hospital_SelectPK(int? HospitalID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Hospital_SelectPK");

                sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, HospitalID);

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

        #region PR_Hospital_Insert
        public bool? PR_Hospital_Insert(MST_HospitalModel modelMST_Hospital)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Hospital_Insert");
                sqldb.AddOutParameter(dbCMD, "HospitalID", SqlDbType.Int, 4);
                sqldb.AddInParameter(dbCMD, "Hospital", SqlDbType.NVarChar, modelMST_Hospital.Hospital);
                sqldb.AddInParameter(dbCMD, "PrintName", SqlDbType.NVarChar, modelMST_Hospital.PrintName);
                sqldb.AddInParameter(dbCMD, "PrintLine1", SqlDbType.NVarChar, modelMST_Hospital.PrintLine1);
                sqldb.AddInParameter(dbCMD, "PrintLine2", SqlDbType.NVarChar, modelMST_Hospital.PrintLine2);
                sqldb.AddInParameter(dbCMD, "PrintLine3", SqlDbType.NVarChar, modelMST_Hospital.PrintLine3);
                sqldb.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, modelMST_Hospital.Modified);
                sqldb.AddInParameter(dbCMD, "FooterName", SqlDbType.NVarChar, modelMST_Hospital.FooterName);
                sqldb.AddInParameter(dbCMD, "ReportHeaderName", SqlDbType.NVarChar, modelMST_Hospital.ReportHeaderName);

                int vResultValue = sqldb.ExecuteNonQuery(dbCMD);

                return (vResultValue == -1 ? false : true);
                //return (vResultValue == -1 ? true : false);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_Hospital_Update
        public bool? PR_Hospital_Update(MST_HospitalModel modelMST_Hospital, int HospitalID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Hospital_Update");
                sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, HospitalID);
                sqldb.AddInParameter(dbCMD, "Hospital", SqlDbType.NVarChar, modelMST_Hospital.Hospital);
                sqldb.AddInParameter(dbCMD, "PrintName", SqlDbType.NVarChar, modelMST_Hospital.PrintName);
                sqldb.AddInParameter(dbCMD, "PrintLine1", SqlDbType.NVarChar, modelMST_Hospital.PrintLine1);
                sqldb.AddInParameter(dbCMD, "PrintLine2", SqlDbType.NVarChar, modelMST_Hospital.PrintLine2);
                sqldb.AddInParameter(dbCMD, "PrintLine3", SqlDbType.NVarChar, modelMST_Hospital.PrintLine3);
                sqldb.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, modelMST_Hospital.Modified);
                sqldb.AddInParameter(dbCMD, "FooterName", SqlDbType.NVarChar, modelMST_Hospital.FooterName);
                sqldb.AddInParameter(dbCMD, "ReportHeaderName", SqlDbType.NVarChar, modelMST_Hospital.ReportHeaderName);

                int result = sqldb.ExecuteNonQuery(dbCMD);
                return (result == -1 ? false : true);
                //return (result == -1 ? true : false);

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        #endregion
        #endregion
    }
}
