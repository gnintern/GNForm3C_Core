using GNForm3C_.BAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace GNForm3C_.DAL
{
    public class MST_DAL : MST_DALBase
    {
		#region Dashboard

		#region Method: PR_MST_CountHospitalTreatmentIncomeExpenseDashboard
		public DataTable PR_MST_CountHospitalTreatmentIncomeExpenseDashboard()
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_MST_CountHospitalTreatmentIncomeExpenseDashboard");
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

		#region Method: PR_Dashboard_TransactionRecentlyAdded
		public DataTable PR_Dashboard_TransactionRecentlyAdded()
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Dashboard_TransactionRecentlyAdded");
                sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, CommonVariables.HospitalID());

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

		#region Method: PR_Dashboard_TreatmentRecentlyAdded
		public DataTable PR_Dashboard_TreatmentRecentlyAdded()
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Dashboard_TreatmentRecentlyAdded");
				sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, CommonVariables.HospitalID());
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

		#region Method: PR_Dashboard_IncomeRecentlyAdded
		public DataTable PR_Dashboard_IncomeRecentlyAdded()
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Dashboard_IncomeRecentlyAdded");

				sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, CommonVariables.HospitalID());

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

		#region Method: PR_Dashboard_ExpenseRecentlyAdded
		public DataTable PR_Dashboard_ExpenseRecentlyAdded()
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqldb.GetStoredProcCommand("PR_Dashboard_ExpenseRecentlyAdded");
				sqldb.AddInParameter(dbCMD, "HospitalID", SqlDbType.Int, CommonVariables.HospitalID());

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
	}
}
