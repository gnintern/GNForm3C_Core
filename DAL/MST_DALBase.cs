using GNForm3C_.Areas.MST_ExpenseType.Models;
using GNForm3C_.Areas.MST_FinYear.Models;
using GNForm3C_.Areas.MST_Hospital.Models;
using GNForm3C_.Areas.MST_Treatment.Models;
using GNForm3C_.Areas.SEC_User.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace GNForm3C_.DAL
{
    public class MST_DALBase : DAL_Helper
    {
        #region MST_Hospital

        #region PR_Hospital_SelectAll
        public DataTable PR_Hospital_SelectAll(MST_HospitalModel modelMST_Hospital)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Hospital_SelectAll");
                DataTable dt = new DataTable();
                if(modelMST_Hospital.Hospital != null)
                {
                    dbCMD = sqldb.GetStoredProcCommand("PR_Hospital_SearchForHospitalName");
                    if(modelMST_Hospital.Hospital != null)
                        sqldb.AddInParameter(dbCMD, "HospitalName", SqlDbType.NVarChar, modelMST_Hospital.Hospital);
                    else
                        sqldb.AddInParameter(dbCMD, "HospitalName", SqlDbType.NVarChar, DBNull.Value);
                }

                using(IDataReader dr = sqldb.ExecuteReader(dbCMD))
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

        #region PR_Hospital_Delete
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
			catch(Exception ex)
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
				using(IDataReader dr = sqldb.ExecuteReader(dbCMD))
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
				sqldb.AddInParameter(dbCMD, "Created", SqlDbType.DateTime, DBNull.Value);
				sqldb.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DBNull.Value);
				sqldb.AddInParameter(dbCMD, "FooterName", SqlDbType.NVarChar, modelMST_Hospital.FooterName);
				sqldb.AddInParameter(dbCMD, "ReportHeaderName", SqlDbType.NVarChar, modelMST_Hospital.ReportHeaderName);

				int vResultValue = sqldb.ExecuteNonQuery(dbCMD);

				//return (vResultValue == -1 ? false : true);
				return (vResultValue == -1 ? true : false);

			}
			catch(Exception ex)
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
				sqldb.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DBNull.Value);
				sqldb.AddInParameter(dbCMD, "FooterName", SqlDbType.NVarChar, modelMST_Hospital.FooterName);
				sqldb.AddInParameter(dbCMD, "ReportHeaderName", SqlDbType.NVarChar, modelMST_Hospital.ReportHeaderName);

				int result = sqldb.ExecuteNonQuery(dbCMD);
				//return (result == -1 ? false : true);
				return (result == -1 ? true : false);

			}
			catch(Exception ex)
			{
				return null;
			}
		}


		#endregion

		#region PR_Hospital_SelectComboBox
		public DataTable PR_Hospital_SelectComboBox()
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Hospital_SelectComboBox");
				DataTable dt = new DataTable();
				using(IDataReader dr = sqldb.ExecuteReader(dbCMD))
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

        #region MST_FinYear
        #region PR_FinYear_SelectAll
        public DataTable PR_FinYear_SelectAll(MST_FinYearModel modelMST_FinYear)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_FinYear_SelectAll");
                DataTable dt = new DataTable();

                if (modelMST_FinYear.FinYearName != null)
                {
                    dbCMD = sqldb.GetStoredProcCommand("PR_FinYear_SelectForFinYearName");

                    if (modelMST_FinYear.FinYearName != null)
                        sqldb.AddInParameter(dbCMD, "FinYearName", SqlDbType.NVarChar, modelMST_FinYear.FinYearName);
                    else
                        sqldb.AddInParameter(dbCMD, "FinYearName", SqlDbType.NVarChar, DBNull.Value);
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

        #region PR_FinYear_Delete
        public bool? PR_FinYear_Delete(int FinYearID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_FinYear_Delete");

                sqldb.AddInParameter(dbCMD, "FinYearID", SqlDbType.Int, FinYearID);


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

        #region PR_FinYear_SelectPK
        public DataTable PR_FinYear_SelectPK(int? FinYearID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_FinYear_SelectPK");

                sqldb.AddInParameter(dbCMD, "FinYearID", SqlDbType.Int, FinYearID);

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

        #region PR_FinYear_Insert
        public bool? PR_FinYear_Insert(MST_FinYearModel modelMST_FinYear)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_FinYear_Insert");
                sqldb.AddOutParameter(dbCMD, "FinYearID", SqlDbType.Int, 4);
                sqldb.AddInParameter(dbCMD, "FinYearName", SqlDbType.NVarChar, modelMST_FinYear.FinYearName);
                sqldb.AddInParameter(dbCMD, "FromDate", SqlDbType.DateTime, modelMST_FinYear.FromDate);
                sqldb.AddInParameter(dbCMD, "ToDate", SqlDbType.DateTime, modelMST_FinYear.ToDate);
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

        #region PR_FinYear_Update
        public bool? PR_FinYear_Update(MST_FinYearModel modelMST_FinYear, int FinYearID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_FinYear_Update");
                sqldb.AddInParameter(dbCMD, "FinYearID", SqlDbType.Int, FinYearID);
                sqldb.AddInParameter(dbCMD, "FinYearName", SqlDbType.NVarChar, modelMST_FinYear.FinYearName);
                sqldb.AddInParameter(dbCMD, "FromDate", SqlDbType.DateTime, modelMST_FinYear.FromDate);
                sqldb.AddInParameter(dbCMD, "ToDate", SqlDbType.DateTime, modelMST_FinYear.ToDate);
                //sqldb.AddInParameter(dbCMD, "Created", SqlDbType.Int, DBNull.Value);
                sqldb.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DBNull.Value);

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

        #region PR_FinYear_SelectComboBox
        public DataTable PR_FinYear_SelectComboBox()
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_FinYear_SelectComboBox");
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

        #region PR_FinYear_SelectComboBoxCurrentYear
        public DataTable PR_FinYear_SelectComboBoxCurrentYear()
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_FinYear_SelectComboBoxCurrentYear");
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
        #endregion

        #region MST_ExpenseType

        #region PR_ExpenseType_SelectAll
        public DataTable PR_ExpenseType_SelectAll(MST_ExpenseTypeModel modelMST_ExpenseType)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_ExpenseType_SelectAll");
                DataTable dt = new DataTable();

                if(modelMST_ExpenseType.ExpenseType != null)
                {
                    dbCMD = sqldb.GetStoredProcCommand("PR_ExpenseType_SearchForExpenseType");

                    if(modelMST_ExpenseType.ExpenseType != null)
                        sqldb.AddInParameter(dbCMD, "ExpenseType", SqlDbType.NVarChar, modelMST_ExpenseType.ExpenseType);
                    else
                        sqldb.AddInParameter(dbCMD, "ExpenseType", SqlDbType.NVarChar, DBNull.Value);
                }

                using(IDataReader dr = sqldb.ExecuteReader(dbCMD))
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

        #region PR_ExpenseType_Delete
        public bool? PR_ExpenseType_Delete(int ExpenseTypeID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_ExpenseType_Delete");
                sqldb.AddInParameter(dbCMD, "ExpenseTypeID", SqlDbType.Int, ExpenseTypeID);
                int vResultValue = sqldb.ExecuteNonQuery(dbCMD);
                //return (vResultValue == -1 ? false : true);
                return (vResultValue == -1 ? true : false);

            }
            catch(Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_ExpenseType_Insert
        public bool? PR_ExpenseType_Insert(MST_ExpenseTypeModel modelMST_ExpenseType)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_ExpenseType_Insert");
                sqldb.AddOutParameter(dbCMD, "ExpenseTypeID", SqlDbType.Int, 4);
                sqldb.AddInParameter(dbCMD, "ExpenseType", SqlDbType.NVarChar, modelMST_ExpenseType.ExpenseType);
                sqldb.AddInParameter(dbCMD, "Remarks", SqlDbType.NVarChar, modelMST_ExpenseType.Remarks);
                sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelMST_ExpenseType.HospitalID);
                sqldb.AddInParameter(dbCMD, "Created", SqlDbType.Int, DBNull.Value);
                sqldb.AddInParameter(dbCMD, "Modified", SqlDbType.Int, DBNull.Value);
                int vResultValue = sqldb.ExecuteNonQuery(dbCMD);

                //return (vResultValue == -1 ? false : true);
                return (vResultValue == -1 ? true : false);

            }
            catch(Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_ExpenseType_Update
        public bool? PR_ExpenseType_Update(MST_ExpenseTypeModel modelMST_ExpenseType, int ExpenseTypeID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_ExpenseType_Update");
                sqldb.AddInParameter(dbCMD, "ExpenseTypeID", SqlDbType.Int, ExpenseTypeID);
                sqldb.AddInParameter(dbCMD, "ExpenseType", SqlDbType.NVarChar, modelMST_ExpenseType.ExpenseType);
                sqldb.AddInParameter(dbCMD, "Remarks", SqlDbType.NVarChar, modelMST_ExpenseType.Remarks);
                sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelMST_ExpenseType.HospitalID);
                sqldb.AddInParameter(dbCMD, "Modified", SqlDbType.Int, DBNull.Value);

                int result = sqldb.ExecuteNonQuery(dbCMD);
                //return (result == -1 ? false : true);
                return (result == -1 ? true : false);

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region PR_ExpenseType_SelectPK
        public DataTable PR_ExpenseType_SelectPK(int? ExpenseTypeID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_ExpenseType_SelectPK");

                sqldb.AddInParameter(dbCMD, "ExpenseTypeID", SqlDbType.Int, ExpenseTypeID);

                DataTable dt = new DataTable();
                using(IDataReader dr = sqldb.ExecuteReader(dbCMD))
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

        #region MST_Treatment

        #region PR_Treatment_SelectAll
        public DataTable PR_Treatment_SelectAll(MST_TreatmentModel modelMST_Treatment)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Treatment_SelectAll");
                DataTable dt = new DataTable();

                if (modelMST_Treatment.HospitalID != null || modelMST_Treatment.Treatment != null)
                {
                    dbCMD = sqldb.GetStoredProcCommand("PR_Treatment_SelectByTreatmentAndHospital");
                    if (modelMST_Treatment.HospitalID != null)
                        sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelMST_Treatment.HospitalID);
                    else
                        sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, DBNull.Value);

                    if (modelMST_Treatment.Treatment != null)
                        sqldb.AddInParameter(dbCMD, "UserName", SqlDbType.NVarChar, modelMST_Treatment.Treatment);
                    else
                        sqldb.AddInParameter(dbCMD, "UserName", SqlDbType.NVarChar, DBNull.Value);
                }
                using (IDataReader dr = sqldb.ExecuteReader(dbCMD))
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

        #region PR_Treatment_Delete
        public bool? PR_Treatment_Delete(int TreatmentID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Treatment_Delete");
                sqldb.AddInParameter(dbCMD, "TreatmentID", SqlDbType.Int, TreatmentID);
                int vResultValue = sqldb.ExecuteNonQuery(dbCMD);
                //return (vResultValue == -1 ? false : true);
                return (vResultValue == -1 ? true : false);
            }
            catch( Exception ex) 
            {
                return null;
            }
        }
        #endregion

        #region PR_Treatment_SelectPK
        public DataTable PR_Treatment_SelectPK(int? TreatmentID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Treatment_SelectPK");
                sqldb.AddInParameter(dbCMD, "TreatmentID", SqlDbType.Int, TreatmentID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqldb.ExecuteReader(dbCMD))
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

        #region PR_Treatment_Insert
        public bool? PR_Treatment_Insert(MST_TreatmentModel modelMST_Treatment)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Treatment_Insert");
                sqldb.AddOutParameter(dbCMD, "TreatmentID", SqlDbType.Int, 4);
                sqldb.AddInParameter(dbCMD, "Treatment", SqlDbType.NVarChar, modelMST_Treatment.Treatment);
                sqldb.AddInParameter(dbCMD, "Remarks", SqlDbType.NVarChar, modelMST_Treatment.Remarks);
                sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelMST_Treatment.HospitalID);
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

        #region PR_Treatment_Update
        public bool? PR_Treatment_Update(MST_TreatmentModel modelMST_Treatment, int TreatmentID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Treatment_Update");
                sqldb.AddInParameter(dbCMD, "TreatmentID", SqlDbType.Int, TreatmentID);
                sqldb.AddInParameter(dbCMD, "Treatment", SqlDbType.NVarChar, modelMST_Treatment.Treatment);
                sqldb.AddInParameter(dbCMD, "Remarks", SqlDbType.NVarChar, modelMST_Treatment.Remarks);
                sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelMST_Treatment.HospitalID);
                sqldb.AddInParameter(dbCMD, "Modified", SqlDbType.Int, DBNull.Value);

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
    }
}
