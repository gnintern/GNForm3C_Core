using GNForm3C_.Areas.MST_Hospital.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using GNForm3C_.Areas.ACC_Expense.Models;
using GNForm3C_.Areas.SEC_User.Models;
using GNForm3C_.BAL;
using GNForm3C_.Areas.ACC_Income.Models;
using GNForm3C_.Areas.ACC_Receipt.Models;

namespace GNForm3C_.DAL
{
    public class ACC_DALBase:DAL_Helper
    {
        #region PR_Expense_SelectAll
        public DataTable PR_Expense_SelectAll(ACC_ExpenseModel modelACC_Expense)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Expense_SelectAll");
                DataTable dt = new DataTable();
                if (modelACC_Expense.HospitalID != null || modelACC_Expense.FinYearID != null || modelACC_Expense.ExpenseTypeID != null || modelACC_Expense.Amount != null)
                {
                    dbCMD = sqldb.GetStoredProcCommand("PR_Expense_SelectByHospitalFinYearExpenseTypeAmount");
                    if (modelACC_Expense.HospitalID != null)
                        sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelACC_Expense.HospitalID);
                    else
                        sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, DBNull.Value);

                    if (modelACC_Expense.FinYearID != null)
                        sqldb.AddInParameter(dbCMD, "FinYearID", SqlDbType.Int, modelACC_Expense.FinYearID);
                    else
                        sqldb.AddInParameter(dbCMD, "FinYearID", SqlDbType.Int, DBNull.Value);

                    if (modelACC_Expense.ExpenseTypeID != null)
                        sqldb.AddInParameter(dbCMD, "ExpenseTypeID", SqlDbType.Int, modelACC_Expense.ExpenseTypeID);
                    else
                        sqldb.AddInParameter(dbCMD, "ExpenseTypeID", SqlDbType.Int, DBNull.Value);

                    if (modelACC_Expense.Amount != null)
                        sqldb.AddInParameter(dbCMD, "Amount", SqlDbType.NVarChar, modelACC_Expense.Amount);
                    else
                        sqldb.AddInParameter(dbCMD, "Amount", SqlDbType.NVarChar, DBNull.Value);
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

        #region PR_Expense_SelectPK
        public DataTable PR_Expense_SelectPK(int? ExpenseID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Expense_SelectPK");
                sqldb.AddInParameter(dbCMD, "ExpenseID", SqlDbType.Int, ExpenseID);

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

        #region PR_Expense_Insert
        public bool? PR_Expense_Insert(ACC_ExpenseModel modelACC_Expense)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Expense_Insert");
                sqldb.AddOutParameter(dbCMD, "ExpenseID", SqlDbType.Int, 4);
                sqldb.AddInParameter(dbCMD, "ExpenseTypeID", SqlDbType.Int, modelACC_Expense.ExpenseTypeID);
                sqldb.AddInParameter(dbCMD, "Amount", SqlDbType.Decimal, modelACC_Expense.Amount);
                sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelACC_Expense.HospitalID);
                sqldb.AddInParameter(dbCMD, "Note", SqlDbType.NVarChar, modelACC_Expense.Note);
                sqldb.AddInParameter(dbCMD,"FinYearID",SqlDbType.Int, CommonVariables.FinYearID());
                sqldb.AddInParameter(dbCMD, "Created", SqlDbType.DateTime, DBNull.Value);
                sqldb.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DBNull.Value);
                sqldb.AddInParameter(dbCMD, "Date", SqlDbType.DateTime, modelACC_Expense.Date);
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

        #region PR_Expense_Update
        public bool? PR_Expense_Update(ACC_ExpenseModel modelACC_Expense ,int ExpenseID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Expense_Update");
                sqldb.AddInParameter(dbCMD, "ExpenseID", SqlDbType.Int, ExpenseID);
                sqldb.AddInParameter(dbCMD, "ExpenseTypeID", SqlDbType.Int, modelACC_Expense.ExpenseTypeID);
                sqldb.AddInParameter(dbCMD, "Amount", SqlDbType.Decimal, modelACC_Expense.Amount);
                sqldb.AddInParameter(dbCMD, "Date", SqlDbType.DateTime, modelACC_Expense.Date);
                sqldb.AddInParameter(dbCMD, "Note", SqlDbType.NVarChar, modelACC_Expense.Note);
                sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelACC_Expense.HospitalID);
                sqldb.AddInParameter(dbCMD, "FinYearID", SqlDbType.Int, CommonVariables.FinYearID());
                sqldb.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DBNull.Value);
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

        #region PR_ExpenseType_Delete
        public bool? PR_Expense_Delete(int ExpenseID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Expense_Delete");
                sqldb.AddInParameter(dbCMD, "ExpenseID", SqlDbType.Int, ExpenseID);
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

        #region Income

        #region PR_Income_SelectAll
        public DataTable PR_Income_SelectAll(ACC_IncomeModel modelACC_Income)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Income_SelectAll");
                DataTable dt = new DataTable();
                if (modelACC_Income.HospitalID != null || modelACC_Income.FinYearID != null || modelACC_Income.IncomeTypeID != null || modelACC_Income.Amount != null)
                {
                    dbCMD = sqldb.GetStoredProcCommand("PR_Income_SelectByHospitalFinYearIncomeTypeAmount");
                    if (modelACC_Income.HospitalID != null)
                        sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelACC_Income.HospitalID);
                    else
                        sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, DBNull.Value);

                    if (modelACC_Income.FinYearID != null)
                        sqldb.AddInParameter(dbCMD, "FinYearID", SqlDbType.Int, modelACC_Income.FinYearID);
                    else
                        sqldb.AddInParameter(dbCMD, "FinYearID", SqlDbType.Int, DBNull.Value);

                    if (modelACC_Income.IncomeTypeID != null)
                        sqldb.AddInParameter(dbCMD, "IncomeTypeID", SqlDbType.Int, modelACC_Income.IncomeTypeID);
                    else
                        sqldb.AddInParameter(dbCMD, "IncomeTypeID", SqlDbType.Int, DBNull.Value);

                    if (modelACC_Income.Amount != null)
                        sqldb.AddInParameter(dbCMD, "Amount", SqlDbType.NVarChar, modelACC_Income.Amount);
                    else
                        sqldb.AddInParameter(dbCMD, "Amount", SqlDbType.NVarChar, DBNull.Value);
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

        #region PR_Income_SelectPK
        public DataTable PR_Income_SelectPK(int? IncomeID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Income_SelectPK");
                sqldb.AddInParameter(dbCMD, "IncomeID", SqlDbType.Int, IncomeID);

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

        #region PR_Income_Insert
        public bool? PR_Income_Insert(ACC_IncomeModel modelACC_Income)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Income_Insert");
                sqldb.AddOutParameter(dbCMD, "IncomeID", SqlDbType.Int, 4);
                sqldb.AddInParameter(dbCMD, "IncomeTypeID", SqlDbType.Int, modelACC_Income.IncomeTypeID);
                sqldb.AddInParameter(dbCMD, "Amount", SqlDbType.Decimal, modelACC_Income.Amount);
                sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelACC_Income.HospitalID);
                sqldb.AddInParameter(dbCMD, "Note", SqlDbType.NVarChar, modelACC_Income.Note);
                sqldb.AddInParameter(dbCMD, "FinYearID", SqlDbType.Int, CommonVariables.FinYearID());
                sqldb.AddInParameter(dbCMD, "Created", SqlDbType.DateTime, DBNull.Value);
                sqldb.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DBNull.Value);
                sqldb.AddInParameter(dbCMD, "Date", SqlDbType.DateTime, modelACC_Income.Date);
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

        #region PR_Income_Update
        public bool? PR_Income_Update(ACC_IncomeModel modelACC_Income, int IncomeID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Income_Update");
                sqldb.AddInParameter(dbCMD, "IncomeID", SqlDbType.Int, IncomeID);
                sqldb.AddInParameter(dbCMD, "IncomeTypeID", SqlDbType.Int, modelACC_Income.IncomeTypeID);
                sqldb.AddInParameter(dbCMD, "Amount", SqlDbType.Decimal, modelACC_Income.Amount);
                sqldb.AddInParameter(dbCMD, "Date", SqlDbType.DateTime, modelACC_Income.Date);
                sqldb.AddInParameter(dbCMD, "Note", SqlDbType.NVarChar, modelACC_Income.Note);
                sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelACC_Income.HospitalID);
                sqldb.AddInParameter(dbCMD, "FinYearID", SqlDbType.Int, CommonVariables.FinYearID());
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

        #region PR_Income_Delete
        public bool? PR_Income_Delete(int IncomeID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Income_Delete");
                sqldb.AddInParameter(dbCMD, "IncomeID", SqlDbType.Int, IncomeID);
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
		#endregion

		#region Receipt
		#region PR_Transaction_SelectAll
		public DataTable PR_Transaction_SelectAll()
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Transaction_SelectAll");
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

		#region PR_Transaction_SelectByFinYearID
		public DataTable PR_Transaction_SelectByFinYearID(ACC_ReceiptModel modelACC_Receipt)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Transaction_SelectByFinYearID");
				sqldb.AddInParameter(dbCMD, "FinYearID", SqlDbType.Int, modelACC_Receipt.FinYearID);

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

		#region PR_Transaction_SelectSerialNoReceiptNoDate
		public DataTable PR_Transaction_SelectSerialNoReceiptNoDate()
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Transaction_SelectSerialNoReceiptNoDate");
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

		#region PR_Transaction_Insert
		public bool? PR_Transaction_Insert(ACC_ReceiptModel modelACC_Receipt)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Transaction_Insert");
				sqldb.AddOutParameter(dbCMD, "TransactionID", SqlDbType.Int, 4);
				sqldb.AddInParameter(dbCMD, "Patient", SqlDbType.NVarChar, modelACC_Receipt.Patient);
				sqldb.AddInParameter(dbCMD, "TreatmentID", SqlDbType.Int, modelACC_Receipt.TreatmentID);
				sqldb.AddInParameter(dbCMD, "Amount", SqlDbType.Decimal, modelACC_Receipt.Amount);
				sqldb.AddInParameter(dbCMD, "SerialNo", SqlDbType.Int, modelACC_Receipt.SerialNo);
				sqldb.AddInParameter(dbCMD, "ReferenceDoctor ", SqlDbType.NVarChar, modelACC_Receipt.ReferenceDoctor);
				sqldb.AddInParameter(dbCMD, "ReceiptNo ", SqlDbType.Int, modelACC_Receipt.ReceiptNo);
				sqldb.AddInParameter(dbCMD, "Date", SqlDbType.DateTime, modelACC_Receipt.Date);
				sqldb.AddInParameter(dbCMD, "Remarks", SqlDbType.NVarChar, modelACC_Receipt.Remarks);
				sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, modelACC_Receipt.HospitalID);
				sqldb.AddInParameter(dbCMD, "FinYearID", SqlDbType.Int, CommonVariables.FinYearID());
				sqldb.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DBNull.Value);
				sqldb.AddInParameter(dbCMD, "DateOfAdmission", SqlDbType.DateTime, modelACC_Receipt.DateOfAdmission);
				sqldb.AddInParameter(dbCMD, "DateOfDischarge", SqlDbType.DateTime, modelACC_Receipt.DateOfDischarge);
				sqldb.AddInParameter(dbCMD, "Deposite", SqlDbType.Decimal, modelACC_Receipt.Deposite);
				sqldb.AddInParameter(dbCMD, "NetAmount", SqlDbType.Decimal, modelACC_Receipt.NetAmount);
				sqldb.AddInParameter(dbCMD, "NoOfDays", SqlDbType.Int, modelACC_Receipt.NoOfDays);
				sqldb.AddInParameter(dbCMD, "Count", SqlDbType.Int, modelACC_Receipt.Count);
				sqldb.AddInParameter(dbCMD, "ReceiptTypeID", SqlDbType.Int, modelACC_Receipt.ReceiptTypeID);

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
		#endregion
	}
}
