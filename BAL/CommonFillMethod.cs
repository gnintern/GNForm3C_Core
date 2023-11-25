﻿using GNForm3C_.Areas.MST_ExpenseType.Models;
using GNForm3C_.Areas.MST_FinYear.Models;
using GNForm3C_.Areas.MST_Hospital.Models;
using GNForm3C_.Areas.MST_IncomeType.Models;
using GNForm3C_.Areas.MST_ReceiptType.Models;
using GNForm3C_.Areas.MST_Treatment.Models;
using GNForm3C_.DAL;
using System.Data;

namespace GNForm3C_.BAL
{
    public class CommonFillMethod
    {
        public CommonFillMethod()
        {

        }

        #region HospitalDropDown
        public static List<HospitalDropDowmModel> SelectDropDownListForHospital()
        {
            MST_DAL dalMST = new MST_DAL();
            DataTable dt1 = dalMST.PR_Hospital_SelectComboBox();
            List<HospitalDropDowmModel> Hospital = new List<HospitalDropDowmModel>();
            foreach (DataRow dr1 in dt1.Rows)
            {
                HospitalDropDowmModel dropDownModel = new HospitalDropDowmModel();
                dropDownModel.HospitalID = Convert.ToInt32(dr1["HospitalID"]);
                dropDownModel.Hospital = dr1["Hospital"].ToString();
                Hospital.Add(dropDownModel);
            }
            return Hospital;
        }
        #endregion

        #region ExpenseTypeDropDown
        public static List<ExpenseTypeDropdownModel> SelectDropDownListForExpenseType()
        {
            MST_DAL dalMST = new MST_DAL();
            DataTable dt1 = dalMST.PR_ExpenseType_SelectComboBox();
            List<ExpenseTypeDropdownModel> Expensetype = new List<ExpenseTypeDropdownModel>();
            foreach (DataRow dr1 in dt1.Rows)
            {
                ExpenseTypeDropdownModel dropDownModel = new ExpenseTypeDropdownModel();
                dropDownModel.ExpenseTypeID = Convert.ToInt32(dr1["ExpenseTypeID"]);
                dropDownModel.ExpenseType = dr1["ExpenseType"].ToString();
                Expensetype.Add(dropDownModel);
            }
            return Expensetype;
        }
        #endregion

        #region IncomeTypeDropDown
        public static List<IncomeTypeDropdownModel> SelectDropDownListForIncomeType()
        {
            MST_DAL dalMST = new MST_DAL();
            DataTable dt1 = dalMST.PR_IncomeType_SelectComboBox();
            List<IncomeTypeDropdownModel> Incometype = new List<IncomeTypeDropdownModel>();
            foreach (DataRow dr1 in dt1.Rows)
            {
                IncomeTypeDropdownModel dropDownModel = new IncomeTypeDropdownModel();
                dropDownModel.IncomeTypeID = Convert.ToInt32(dr1["IncomeTypeID"]);
                dropDownModel.IncomeType = dr1["IncomeType"].ToString();
                Incometype.Add(dropDownModel);
            }
            return Incometype;
        }
        #endregion

        #region SelectComboBoxCurrentYear
        public static List<FinYearDropdownModel> SelectComboBoxCurrentYear()
        {
            MST_DAL dalMST = new MST_DAL();
            DataTable dt1 = dalMST.PR_FinYear_SelectComboBoxCurrentYear();
            List<FinYearDropdownModel> FinYear = new List<FinYearDropdownModel>();
            foreach (DataRow dr1 in dt1.Rows)
            {
                FinYearDropdownModel dropDownModel = new FinYearDropdownModel();
                dropDownModel.FinYearID = Convert.ToInt32(dr1["FinYearID"]);
                dropDownModel.FinYearName = dr1["FinYearName"].ToString();
                FinYear.Add(dropDownModel);
            }
            return FinYear;
        }
        #endregion

        #region FinYearDropDown
        public static List<FinYearDropdownModel> SelectDropDownListForFinYear()
        {
            MST_DAL dalMST = new MST_DAL();
            DataTable dt1 = dalMST.PR_FinYear_SelectComboBox();
            List<FinYearDropdownModel> FinYear = new List<FinYearDropdownModel>();
            foreach (DataRow dr1 in dt1.Rows)
            {
                FinYearDropdownModel dropDownModel = new FinYearDropdownModel();
                dropDownModel.FinYearID = Convert.ToInt32(dr1["FinYearID"]);
                dropDownModel.FinYearName = dr1["FinYearName"].ToString();
                FinYear.Add(dropDownModel);
            }
            return FinYear;
        }
		#endregion


		#region Receipt Type DropDown
		public static List<ReceiptDropDownModel> SelectDropDownListForReceiptType()
		{
			MST_DAL dalMST = new MST_DAL();
			DataTable dt1 = dalMST.PR_ReceiptType_SelectComboBox();
			List<ReceiptDropDownModel> ReceiptType = new List<ReceiptDropDownModel>();
			foreach (DataRow dr1 in dt1.Rows)
			{
				ReceiptDropDownModel dropDownModel = new ReceiptDropDownModel();
				dropDownModel.ReceiptTypeID = Convert.ToInt32(dr1["ReceiptTypeID"]);
				dropDownModel.ReceiptTypeName = dr1["ReceiptTypeName"].ToString();
				ReceiptType.Add(dropDownModel);
			}
			return ReceiptType;
		}
		#endregion

		#region Treatement DropDown Model
		public static List<TreatementDropDownModel> SelectDropDownListForTreatment()
		{
			MST_DAL dalMST = new MST_DAL();
			DataTable dt1 = dalMST.PR_Treatment_SelectComboBox();
			List<TreatementDropDownModel> Treatement = new List<TreatementDropDownModel>();
			foreach (DataRow dr1 in dt1.Rows)
			{
				TreatementDropDownModel dropDownModel = new TreatementDropDownModel();
				dropDownModel.TreatmentID = Convert.ToInt32(dr1["TreatmentID"]);
				dropDownModel.Treatment = dr1["Treatment"].ToString();
				Treatement.Add(dropDownModel);
			}
			return Treatement;
		}
		#endregion

	}
}
