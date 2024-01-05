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
    [CheckAccess]
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

        #region Post Index

        [HttpPost]
        public IActionResult Index(ViewBagReceiptModel modelViewBagReceiptModel)
        {
            if (ModelState.IsValid)
            {
                var fromDate = modelViewBagReceiptModel.FromDate;
                var toDate = modelViewBagReceiptModel.ToDate;

                if (fromDate > toDate)
                {
                    TempData["error"] = "From Date cannot be greater than To Date.";
                    return View("ACC_ReceiptList");
                }


                #region Fetch Record from Database

                DataTable dt = dalACC.PP_Transaction_SelectReceiptsByFromDateToDateHospitalID(modelViewBagReceiptModel);


                #region Fill the record into List
                List<ACC_ReceiptModel> Receipts = new List<ACC_ReceiptModel>();
                foreach (DataRow dr in dt.Rows)
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
                    if (dr["DateOfAdmission"].ToString().Trim() != string.Empty)
                        ReceiptModel.DateOfAdmission = Convert.ToDateTime(dr["DateOfAdmission"].ToString());
                    if (dr["DateOfDischarge"].ToString().Trim() != string.Empty)
                        ReceiptModel.DateOfDischarge = Convert.ToDateTime(dr["DateOfDischarge"].ToString());
                    if (dr["NoOfDays"].ToString().Trim() != string.Empty)
                        ReceiptModel.NoOfDays = Convert.ToInt32(dr["NoOfDays"].ToString());
                    if (dr["Deposite"].ToString().Trim() != string.Empty)
                        ReceiptModel.Deposite = Convert.ToDecimal(dr["Deposite"].ToString());
                    if (dr["NetAmount"].ToString().Trim() != string.Empty)
                        ReceiptModel.NetAmount = Convert.ToDecimal(dr["NetAmount"].ToString());
                    if (dr["Remarks"].ToString().Trim() != string.Empty)
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
            return View("ACC_ReceiptList");
            #endregion

        }
        #endregion


        #region Add
        public IActionResult Add()
        {

            #region Button Title
            TempData["ButtonAction"] = "Save";
            #endregion

            ACC_ReceiptModel modelACC_Receipt = new ACC_ReceiptModel();
            ViewBag.HospitalDropDown = CommonFillMethod.SetDropDownListForHospital().ToList();
            ViewBag.ReceiptTypeDropDown = CommonFillMethod.SelectDropDownListForReceiptType().ToList();
            ViewBag.TreatmentDropDown = CommonFillMethod.SelectDropDownListForTreatment().ToList();
            
            #region Add record
            DataTable dt = dalACC.PR_Transaction_SelectSerialNoReceiptNoDate();
            foreach (DataRow dr in dt.Rows)
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


            if (modelACC_Receipt.TransactionID == null)
            {
                #region Inserting Record

                if (Convert.ToBoolean(dalACC.PR_Transaction_Insert(modelACC_Receipt)))
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
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
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

        #region Fill Receipt Modal
        public IActionResult ReceiptDetail(int? modalID)
        {

            ACC_ReceiptModel ReceiptModel = new ACC_ReceiptModel();

            #region Select_PK record
            DataTable dt = dalACC.PR_Transaction_SelectView(modalID);
            foreach (DataRow dr in dt.Rows)
            {
                ReceiptModel.TransactionID = Convert.ToInt32(dr["TransactionID"]);
                ReceiptModel.Patient = dr["Patient"].ToString();
                ReceiptModel.TreatmentID = Convert.ToInt32(dr["TreatmentID"]);
                ReceiptModel.Treatment = dr["Treatment"].ToString();
                ReceiptModel.Amount = Convert.ToDecimal(dr["SerialNo"].ToString());
                ReceiptModel.SerialNo = Convert.ToInt32(dr["TransactionID"]);
                ReceiptModel.ReferenceDoctor = dr["ReferenceDoctor"].ToString();
                if (dr["Count"].ToString().Trim() != string.Empty)
                    ReceiptModel.Count = Convert.ToInt32(dr["Count"]);
                ReceiptModel.ReceiptNo = Convert.ToInt32(dr["ReceiptNo"]);
                ReceiptModel.Date = Convert.ToDateTime(dr["Date"]);
                if (dr["DateOfAdmission"].ToString().Trim() != string.Empty)
                    ReceiptModel.DateOfAdmission = Convert.ToDateTime(dr["DateOfAdmission"].ToString());
                if (dr["DateOfDischarge"].ToString().Trim() != string.Empty)
                    ReceiptModel.DateOfDischarge = Convert.ToDateTime(dr["DateOfDischarge"].ToString());
                if (dr["NoOfDays"].ToString().Trim() != string.Empty)
                    ReceiptModel.NoOfDays = Convert.ToInt32(dr["NoOfDays"].ToString());
                if (dr["Deposite"].ToString().Trim() != string.Empty)
                    ReceiptModel.Deposite = Convert.ToDecimal(dr["Deposite"].ToString());
                if (dr["NetAmount"].ToString().Trim() != string.Empty)
                    ReceiptModel.NetAmount = Convert.ToDecimal(dr["NetAmount"].ToString());
                if (dr["Remarks"].ToString().Trim() != string.Empty)
                    ReceiptModel.Remarks = dr["Remarks"].ToString();
                ReceiptModel.HospitalID = Convert.ToInt32(dr["HospitalID"]);
                ReceiptModel.Hospital = dr["Hospital"].ToString();
                ReceiptModel.FinYearID = Convert.ToInt32(dr["FinYearID"]);
                ReceiptModel.FinYearName = dr["FinYearName"].ToString();
                ReceiptModel.Modified = Convert.ToDateTime(dr["Modified"]);


            }
            #endregion
            return PartialView("~/Areas/ACC_Receipt/Views/Shared/_ReceiptDetails.cshtml", ReceiptModel);
        }
        #endregion
    }
}
