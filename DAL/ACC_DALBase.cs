using GNForm3C_.Areas.MST_Hospital.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using GNForm3C_.Areas.ACC_Expense.Models;
using GNForm3C_.Areas.SEC_User.Models;
using GNForm3C_.BAL;

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
    }
}
