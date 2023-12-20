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
        
        public IActionResult Index(ACC_ReceiptModel modelACC_Receipt)
        {
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
            
        }

  
        #region Add
        public IActionResult Add()
        {
            ACC_ReceiptModel modelACC_Receipt = new ACC_ReceiptModel();
            ViewBag.HospitalDropDown = CommonFillMethod.SelectDropDownListForHospital().ToList();
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
        
        
    }
}
