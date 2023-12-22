using GNForm3C_.Areas.ACC_Receipt.Models;
using GNForm3C_.Areas.MST_ExpenseType.Models;
using GNForm3C_.Areas.MST_FinYear.Models;
using GNForm3C_.Areas.MST_Hospital.Models;
using GNForm3C_.Areas.MST_IncomeType.Models;
using GNForm3C_.Areas.MST_ReceiptType.Models;
using GNForm3C_.Areas.MST_SubTreatment.Models;
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
				if (modelMST_Hospital.Hospital != null)
				{
					dbCMD = sqldb.GetStoredProcCommand("PR_Hospital_SearchForHospitalName");
					sqldb.AddInParameter(dbCMD, "HospitalName", SqlDbType.NVarChar, modelMST_Hospital.Hospital);
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
				sqldb.AddInParameter(dbCMD, "Created", SqlDbType.DateTime, DBNull.Value);
				sqldb.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DBNull.Value);
				sqldb.AddInParameter(dbCMD, "FooterName", SqlDbType.NVarChar, modelMST_Hospital.FooterName);
				sqldb.AddInParameter(dbCMD, "ReportHeaderName", SqlDbType.NVarChar, modelMST_Hospital.ReportHeaderName);

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
			catch (Exception ex)
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
					sqldb.AddInParameter(dbCMD, "FinYearName", SqlDbType.NVarChar, modelMST_FinYear.FinYearName);
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
		public bool? PR_FinYear_Update(MST_FinYearModel modelMST_FinYear)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_FinYear_Update");
				sqldb.AddInParameter(dbCMD, "FinYearID", SqlDbType.Int, modelMST_FinYear.FinYearID);
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

		#region PR_FinYear_CheckISExist
		public bool PR_FinYear_CheckISExist(string FinYearName)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_FinYear_CheckISExist");

				sqldb.AddInParameter(dbCMD, "FinYearName", SqlDbType.NVarChar, FinYearName);

				int recordCount = Convert.ToInt32(sqldb.ExecuteScalar(dbCMD));

				return recordCount > 0;
			}
			catch (Exception ex)
			{
				// Handle the exception (log, throw, etc.)
				return false;
			}
		}
		#endregion

		#region PR_FinYear_SelectFinYearIDFromFromDateAndToDate
		public DataTable PR_FinYear_SelectFinYearIDFromFromDateAndToDate(ACC_ReceiptModel modelACC_Receipt)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_FinYear_SelectFinYearIDFromFromDateAndToDate");
				sqldb.AddOutParameter(dbCMD, "FinYearID", SqlDbType.Int, 4);
				sqldb.AddInParameter(dbCMD, "FromDate", SqlDbType.DateTime, modelACC_Receipt.FromDate);
				sqldb.AddInParameter(dbCMD, "ToDate", SqlDbType.DateTime, modelACC_Receipt.ToDate);

				DataTable dt = new DataTable();
				using (IDataReader dr = sqldb.ExecuteReader(dbCMD))
				{
					modelACC_Receipt.FinYearID = Convert.ToInt32(dbCMD.Parameters["@FinYearID"].Value);
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

				if (modelMST_ExpenseType.ExpenseType != null || modelMST_ExpenseType.HospitalID!=null)
				{
					dbCMD = sqldb.GetStoredProcCommand("PR_ExpenseType_SearchForExpenseType");
					sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelMST_ExpenseType.HospitalID);
					sqldb.AddInParameter(dbCMD, "ExpenseType", SqlDbType.NVarChar, modelMST_ExpenseType.ExpenseType);
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
			catch (Exception ex)
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
			catch (Exception ex)
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
			catch (Exception ex)
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

		#region PR_ExpenseType_SelectComboBox
		public DataTable PR_ExpenseType_SelectComboBox()
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_ExpenseType_SelectComboBox");
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
					sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelMST_Treatment.HospitalID);
					sqldb.AddInParameter(dbCMD, "Treatment", SqlDbType.NVarChar, modelMST_Treatment.Treatment);
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
			catch (Exception ex)
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
			catch (Exception ex)
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

		#region PR_Treatment_SelectComboBox
		public DataTable PR_Treatment_SelectComboBox()
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Treatment_SelectComboBox");
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

		#region MST_IncomeType

		#region PR_IncomeType_SelectAll
		public DataTable PR_IncomeType_SelectAll(MST_IncomeTypeModel modelMST_IncomeType)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_IncomeType_SelectAll");
				DataTable dt = new DataTable();

				if (modelMST_IncomeType.IncomeType != null || modelMST_IncomeType.HospitalID!=null)
				{
					dbCMD = sqldb.GetStoredProcCommand("PR_IncomeType_SearchForIncomeType");
					sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelMST_IncomeType.HospitalID);
					sqldb.AddInParameter(dbCMD, "IncomeType", SqlDbType.NVarChar, modelMST_IncomeType.IncomeType);
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

		#region PR_IncomeType_Delete
		public bool? PR_IncomeType_Delete(int IncomeTypeID)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_IncomeType_Delete");
				sqldb.AddInParameter(dbCMD, "IncomeTypeID", SqlDbType.Int, IncomeTypeID);
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

		#region PR_IncomeType_Insert
		public bool? PR_IncomeType_Insert(MST_IncomeTypeModel modelMST_IncomeType)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_IncomeType_Insert");
				sqldb.AddOutParameter(dbCMD, "IncomeTypeID", SqlDbType.Int, 4);
				sqldb.AddInParameter(dbCMD, "IncomeType", SqlDbType.NVarChar, modelMST_IncomeType.IncomeType);
				sqldb.AddInParameter(dbCMD, "Remarks", SqlDbType.NVarChar, modelMST_IncomeType.Remarks);
				sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelMST_IncomeType.HospitalID);
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

		#region PR_IncomeType_Update
		public bool? PR_IncomeType_Update(MST_IncomeTypeModel modelMST_IncomeType, int IncomeTypeID)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_IncomeType_Update");
				sqldb.AddInParameter(dbCMD, "IncomeTypeID", SqlDbType.Int, IncomeTypeID);
				sqldb.AddInParameter(dbCMD, "IncomeType", SqlDbType.NVarChar, modelMST_IncomeType.IncomeType);
				sqldb.AddInParameter(dbCMD, "Remarks", SqlDbType.NVarChar, modelMST_IncomeType.Remarks);
				sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelMST_IncomeType.HospitalID);
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

		#region PR_IncomeType_SelectPK
		public DataTable PR_IncomeType_SelectPK(int? IncomeTypeID)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_IncomeType_SelectPK");

				sqldb.AddInParameter(dbCMD, "IncomeTypeID", SqlDbType.Int, IncomeTypeID);

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

		#region PR_IncomeType_SelectComboBox
		public DataTable PR_IncomeType_SelectComboBox()
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_IncomeType_SelectComboBox");
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

		#region MST_SubTreatment

		#region PR_SubTreatment_SelectAll
		public DataTable PR_SubTreatment_SelectAll(MST_SubTreatmentModel modelMST_SubTreatment)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_SubTreatment_SelectAll");
				DataTable dt = new DataTable();
				if (modelMST_SubTreatment.HospitalID != null || modelMST_SubTreatment.SubTreatmentName != null)
				{
					dbCMD = sqldb.GetStoredProcCommand("PR_SubTreatment_SelectBySubTreatmentNameHospital");

					sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelMST_SubTreatment.HospitalID);
					sqldb.AddInParameter(dbCMD, "SubTreatmentName", SqlDbType.NVarChar, modelMST_SubTreatment.SubTreatmentName);

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

		#region PR_SubTreatment_Delete
		public bool? PR_SubTreatment_Delete(int SubTreatmentID)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_SubTreatment_Delete");
				sqldb.AddInParameter(dbCMD, "SubTreatmentID", SqlDbType.Int, SubTreatmentID);
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

		#region PR_SubTreatment_Insert
		public bool? PR_SubTreatment_Insert(MST_SubTreatmentModel modelMST_SubTreatment)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_SubTreatment_Insert");
				sqldb.AddOutParameter(dbCMD, "SubTreatmentID", SqlDbType.Int, 4);
				sqldb.AddInParameter(dbCMD, "SubTreatmentName", SqlDbType.NVarChar, modelMST_SubTreatment.SubTreatmentName);
				sqldb.AddInParameter(dbCMD, "SequenceNo", SqlDbType.Int, modelMST_SubTreatment.SequenceNo);
				sqldb.AddInParameter(dbCMD, "Rate", SqlDbType.Decimal, modelMST_SubTreatment.Rate);
				sqldb.AddInParameter(dbCMD, "IsInGrid", SqlDbType.Bit, modelMST_SubTreatment.IsInGrid);
				sqldb.AddInParameter(dbCMD, "IsPerDay", SqlDbType.Bit, modelMST_SubTreatment.IsPerDay);
				sqldb.AddInParameter(dbCMD, "Remarks", SqlDbType.NVarChar, modelMST_SubTreatment.Remarks);
				sqldb.AddInParameter(dbCMD, "DefaultUnit", SqlDbType.NVarChar, modelMST_SubTreatment.DefaultUnit);
				sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelMST_SubTreatment.HospitalID);
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

		#region PR_SubTreatment_Update
		public bool? PR_SubTreatment_Update(MST_SubTreatmentModel modelMST_SubTreatment, int SubTreatmentID)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_SubTreatment_Update");
				sqldb.AddInParameter(dbCMD, "SubTreatmentID", SqlDbType.Int, SubTreatmentID);
				sqldb.AddInParameter(dbCMD, "SubTreatmentName", SqlDbType.NVarChar, modelMST_SubTreatment.SubTreatmentName);
				sqldb.AddInParameter(dbCMD, "SequenceNo", SqlDbType.Int, modelMST_SubTreatment.SequenceNo);
				sqldb.AddInParameter(dbCMD, "Rate", SqlDbType.Decimal, modelMST_SubTreatment.Rate);
				sqldb.AddInParameter(dbCMD, "IsInGrid", SqlDbType.Bit, modelMST_SubTreatment.IsInGrid);
				sqldb.AddInParameter(dbCMD, "IsPerDay", SqlDbType.Bit, modelMST_SubTreatment.IsPerDay);
				sqldb.AddInParameter(dbCMD, "Remarks", SqlDbType.NVarChar, modelMST_SubTreatment.Remarks);
				sqldb.AddInParameter(dbCMD, "DefaultUnit", SqlDbType.NVarChar, modelMST_SubTreatment.DefaultUnit);
				sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelMST_SubTreatment.HospitalID);
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

		#region PR_SubTreatment_SelectPK
		public DataTable PR_SubTreatment_SelectPK(int? SubTreatmentID)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_SubTreatment_SelectPK");

				sqldb.AddInParameter(dbCMD, "SubTreatmentID", SqlDbType.Int, SubTreatmentID);

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

		#region MST_ReceiptType

		#region PR_ReceiptType_SelectAll
		public DataTable PR_ReceiptType_SelectAll(MST_ReceiptTypeModel modelMST_ReceiptType)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_ReceiptType_SelectAll");
				DataTable dt = new DataTable();

				if (modelMST_ReceiptType.HospitalID != null || modelMST_ReceiptType.ReceiptTypeName != null)
				{
					dbCMD = sqldb.GetStoredProcCommand("PR_ReceiptType_SelectByReceiptTypeNameHospital");

					sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelMST_ReceiptType.HospitalID);
					sqldb.AddInParameter(dbCMD, "ReceiptTypeName", SqlDbType.NVarChar, modelMST_ReceiptType.ReceiptTypeName);
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

		#region PR_ReceiptType_Delete
		public bool? PR_ReceiptType_Delete(int ReceiptTypeID)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_ReceiptType_Delete");
				sqldb.AddInParameter(dbCMD, "ReceiptTypeID", SqlDbType.Int, ReceiptTypeID);
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

		#region PR_ReceiptType_Insert
		public bool? PR_ReceiptType_Insert(MST_ReceiptTypeModel modelMST_ReceiptType)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_ReceiptType_Insert");
				sqldb.AddOutParameter(dbCMD, "ReceiptTypeID", SqlDbType.Int, 4);
				sqldb.AddInParameter(dbCMD, "ReceiptTypeName", SqlDbType.NVarChar, modelMST_ReceiptType.ReceiptTypeName);
				sqldb.AddInParameter(dbCMD, "PrintName", SqlDbType.NVarChar, modelMST_ReceiptType.PrintName);
				sqldb.AddInParameter(dbCMD, "IsDefault", SqlDbType.Bit, modelMST_ReceiptType.IsDefault);
				sqldb.AddInParameter(dbCMD, "Remarks", SqlDbType.NVarChar, modelMST_ReceiptType.Remarks);
				sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelMST_ReceiptType.HospitalID);
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

		#region PR_ReceiptType_Update
		public bool? PR_ReceiptType_Update(MST_ReceiptTypeModel modelMST_ReceiptType, int ReceiptTypeID)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_ReceiptType_Update");
				sqldb.AddInParameter(dbCMD, "ReceiptTypeID", SqlDbType.Int, ReceiptTypeID);
				sqldb.AddInParameter(dbCMD, "ReceiptTypeName", SqlDbType.NVarChar, modelMST_ReceiptType.ReceiptTypeName);
				sqldb.AddInParameter(dbCMD, "PrintName", SqlDbType.NVarChar, modelMST_ReceiptType.PrintName);
				sqldb.AddInParameter(dbCMD, "IsDefault", SqlDbType.Bit, modelMST_ReceiptType.IsDefault);
				sqldb.AddInParameter(dbCMD, "Remarks", SqlDbType.NVarChar, modelMST_ReceiptType.Remarks);
				sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelMST_ReceiptType.HospitalID);
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

		#region PR_ReceiptType_SelectPK
		public DataTable PR_ReceiptType_SelectPK(int? ReceiptTypeID)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_ReceiptType_SelectPK");

				sqldb.AddInParameter(dbCMD, "ReceiptTypeID", SqlDbType.Int, ReceiptTypeID);

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
		#region PR_ReceiptType_SelectComboBox
		public DataTable PR_ReceiptType_SelectComboBox()
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_ReceiptType_SelectComboBox");
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
	}
}
