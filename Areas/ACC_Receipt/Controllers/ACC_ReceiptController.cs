using GNForm3C_.Areas.ACC_Expense.Models;
using GNForm3C_.Areas.ACC_Receipt.Models;
using GNForm3C_.Areas.MST_FinYear.Models;
using GNForm3C_.Areas.MST_Hospital.Models;
using GNForm3C_.BAL;
using GNForm3C_.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlTypes;
using System.Transactions;

namespace GNForm3C_.Areas.ACC_Receipt.Controllers
{
    [Area("ACC_Receipt")]
    [Route("[Controller]/[action]")]
    public class ACC_ReceiptController : Controller
    {
        ACC_DAL dalACC = new ACC_DAL();
        MST_DAL dalMST = new MST_DAL();

        #region Function: SelectAll
        [HttpGet]
        public IActionResult Index()
        {
            return View("ACC_ReceiptList");

        }

        [HttpPost]
        public IActionResult Index(ACC_ReceiptModel modelACC_Receipt)
        {
            

            if(ModelState.IsValid || modelACC_Receipt.FromDate == null || modelACC_Receipt.ToDate ==null)
            {
                MST_FinYearModel modelMST_FinYear = new MST_FinYearModel();
                var fromDate = modelACC_Receipt.FromDate;
                var toDate = modelACC_Receipt.ToDate;

                if(fromDate > toDate)
                {
                    TempData["error"] = "From Date cannot be greater than To Date.";
                    return View("ACC_ReceiptList");
                }

                // Calculate the difference between From Date and To Date
                var daysBetweenDates = (toDate - fromDate).TotalDays;

                // Check if the difference is exactly one year, considering leap years
                if(daysBetweenDates == 364 || (daysBetweenDates == 365 && IsLeapYear(toDate.Year)))
                {
                    #region Fetch Record from Database

                    DataTable dt1 = dalMST.PR_FinYear_SelectFinYearIDFromFromDateAndToDate(modelACC_Receipt);
                    DataTable dt = dalACC.PR_Transaction_SelectByFinYearID(modelACC_Receipt);


                    #region Fill the record into List
                    List<ACC_ReceiptModel> Receipts = new List<ACC_ReceiptModel>();
                    foreach(DataRow dr in dt.Rows)
                    {
                        ACC_ReceiptModel ReceiptModel = new ACC_ReceiptModel();
                        ReceiptModel.TransactionID = Convert.ToInt32(dr["TransactionID"]);
                        ReceiptModel.Date = Convert.ToDateTime(dr["Date"]);
                        ReceiptModel.SerialNo = Convert.ToInt32(dr["SerialNo"]);
                        ReceiptModel.ReceiptTypeName = dr["ReceiptTypeName"].ToString();
                        ReceiptModel.ReceiptNo = Convert.ToInt32(dr["ReceiptNo"]);
                        ReceiptModel.Patient = dr["Patient"].ToString();
                        ReceiptModel.Treatment = dr["Treatment"].ToString();
                        ReceiptModel.Amount = Convert.ToDecimal(dr["Amount"].ToString());
                        if(dr["DateOfAdmission"].ToString().Trim() != string.Empty)
                            ReceiptModel.DateOfAdmission = Convert.ToDateTime(dr["DateOfAdmission"].ToString());
                        if(dr["DateOfDischarge"].ToString().Trim() != string.Empty)
                            ReceiptModel.DateOfDischarge = Convert.ToDateTime(dr["DateOfDischarge"].ToString());
                        if(dr["NoOfDays"].ToString().Trim() != string.Empty)
                            ReceiptModel.NoOfDays = Convert.ToInt32(dr["NoOfDays"].ToString());
                        if(dr["Deposite"].ToString().Trim() != string.Empty)
                            ReceiptModel.Deposite = Convert.ToDecimal(dr["Deposite"].ToString());
                        if(dr["NetAmount"].ToString().Trim() != string.Empty)
                            ReceiptModel.NetAmount = Convert.ToDecimal(dr["NetAmount"].ToString());
                        if(dr["Remarks"].ToString().Trim() != string.Empty)
                            ReceiptModel.Remarks = dr["Remarks"].ToString();
                        ReceiptModel.FinYearName = dr["FinYearName"].ToString();
                        ReceiptModel.Hospital = dr["Hospital"].ToString();
                        ReceiptModel.Modified = Convert.ToDateTime(dr["Modified"]);

                        Receipts.Add(ReceiptModel);
                    }
                    ViewBag.ReceiptsList = Receipts;
                    #endregion

                    return View("ACC_ReceiptList");

                    #endregion
                }
                else
                {
                    TempData["error"] = "The difference between From Date and To Date must be exactly one year.";
                    return View("ACC_ReceiptList");
                }
            }

            return View("ACC_ReceiptList");
        }
        #endregion

        #region Add
        public IActionResult Add()
        {
            ACC_ReceiptModel modelACC_Receipt = new ACC_ReceiptModel();
            ViewBag.HospitalDropDown = CommonFillMethod.SetDropDownListForHospital().ToList();
            ViewBag.ReceiptTypeDropDown = CommonFillMethod.SelectDropDownListForReceiptType().ToList();
            ViewBag.TreatmentDropDown = CommonFillMethod.SelectDropDownListForTreatment().ToList();
            #region Add record
            DataTable dt = dalACC.PR_Transaction_SelectSerialNoReceiptNoDate();
            foreach(DataRow dr in dt.Rows)
            {
                modelACC_Receipt.SerialNo = Convert.ToInt32(dr["SerialNo"].ToString());
                modelACC_Receipt.ReceiptNo = Convert.ToInt32(dr["ReceiptNo"].ToString());
                modelACC_Receipt.Date = Convert.ToDateTime(dr["Date"]);
            }
            #endregion

            return View("ACC_ReceiptAddEdit", modelACC_Receipt);
        }
        #endregion

        #region Function: Save Record
        [HttpPost]
        public IActionResult Save(ACC_ReceiptModel modelACC_Receipt)
        {


            if(modelACC_Receipt.TransactionID == null)
            {
                #region Inserting Record

                if(Convert.ToBoolean(dalACC.PR_Transaction_Insert(modelACC_Receipt)))
                {
                    TempData["success"] = "Record Inserted Successfully";
                    return RedirectToAction("Index");
                }
                #endregion
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region IsLeapYear
        private bool IsLeapYear(int year)
        {
            if(year % 4 == 0)
            {
                if(year % 100 == 0)
                {
                    return year % 400 == 0;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
