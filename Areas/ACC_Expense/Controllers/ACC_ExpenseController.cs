using GNForm3C_.Areas.ACC_Expense.Models;
using GNForm3C_.Areas.MST_Hospital.Models;
using GNForm3C_.BAL;
using GNForm3C_.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlTypes;

namespace GNForm3C_.Areas.ACC_Expense.Controllers
{
    [CheckAccess]
    [Area("ACC_Expense")]
    [Route("[Controller]/[action]")]
    public class ACC_ExpenseController : Controller
    {
        ACC_DAL dalACC = new ACC_DAL();

        #region Function: SelectAll
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.HospitalDropDown = CommonFillMethod.SetDropDownListForHospital().ToList();
            ViewBag.FinYearDropDown = CommonFillMethod.SelectDropDownListForFinYear().ToList();
            ViewBag.ExpenseTypeDropDown = CommonFillMethod.SelectDropDownListForExpenseType().ToList();
            return View("ACC_ExpenseList");
        }

        [HttpPost]
        public IActionResult Index(ACC_ExpenseModel modelACC_Expense)
        {
            ViewBag.HospitalDropDown = CommonFillMethod.SetDropDownListForHospital().ToList();
            ViewBag.FinYearDropDown = CommonFillMethod.SelectDropDownListForFinYear().ToList();
            ViewBag.ExpenseTypeDropDown = CommonFillMethod.SelectDropDownListForExpenseType().ToList();
            if(ModelState.IsValid || modelACC_Expense.FinYearID!=null)
            {

                if(modelACC_Expense.FinYearID == 0)
                {

                    return View("ACC_ExpenseList", modelACC_Expense);
                }
                else
                {


                    DataTable dt = dalACC.PR_Expense_SelectAll(modelACC_Expense);

                    #region Fill the record into List
                    List<ACC_ExpenseModel> Expenses = new List<ACC_ExpenseModel>();
                    foreach(DataRow dr in dt.Rows)
                    {
                        ACC_ExpenseModel ExpenseModel = new ACC_ExpenseModel();
                        ExpenseModel.ExpenseID = Convert.ToInt32(dr["ExpenseID"]);
                        //ExpenseModel.ExpenseTypeID = Convert.ToInt32(dr["ExpenseTypeID"]);
                        ExpenseModel.ExpenseType = dr["ExpenseType"].ToString();
                        ExpenseModel.Date = Convert.ToDateTime(dr["Date"]);
                        ExpenseModel.Amount = Convert.ToDecimal(dr["Amount"].ToString());
                        ExpenseModel.Note = dr["Note"].ToString();
                        ExpenseModel.Created = Convert.ToDateTime(dr["Created"]);
                        ExpenseModel.Modified = Convert.ToDateTime(dr["Modified"]);
                        //ExpenseModel.FinYearID = Convert.ToInt32(dr["FinYearID"]);
                        ExpenseModel.FinYearName = dr["FinYearName"].ToString();
                        //ExpenseModel.HospitalID = Convert.ToInt32(dr["HospitalID"]);
                        ExpenseModel.Hospital = dr["Hospital"].ToString();
                        Expenses.Add(ExpenseModel);
                    }
                    ViewBag.ExpenseList = Expenses;
                    #endregion

                    return View("ACC_ExpenseList");
                }


            }
            return View("ACC_ExpenseList");

        }
        #endregion

        #region Function: Add Record
        public IActionResult Add(string? ExpenseID)
        {
            ACC_ExpenseModel modelACC_Expense = new ACC_ExpenseModel();

            if(ModelState.IsValid)
            {
                #region Form Title
                TempData["Action"] = "Add";
                #endregion

                ViewBag.HospitalDropDown = CommonFillMethod.SetDropDownListForHospital().ToList();
                ViewBag.ExpenseTypeDropDown = CommonFillMethod.SelectDropDownListForExpenseType().ToList();


                if(ExpenseID != null)
                {
                    #region Form Title
                    TempData["Action"] = "Edit";
                    #endregion

                    #region Decrypt the Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(ExpenseID);
                    int id = decryptedID.Value;
                    #endregion

                    #region Select_PK record
                    DataTable dt = dalACC.PR_Expense_SelectPK(id);
                    foreach(DataRow dr in dt.Rows)
                    {
                        modelACC_Expense.ExpenseID = Convert.ToInt32(dr["ExpenseID"]);
                        modelACC_Expense.ExpenseTypeID = Convert.ToInt32(dr["ExpenseTypeID"]);
                        modelACC_Expense.HospitalID = Convert.ToInt32(dr["HospitalID"]);
                        modelACC_Expense.Date = Convert.ToDateTime(dr["Date"]);
                        modelACC_Expense.Amount = Convert.ToDecimal(dr["Amount"].ToString());
                        modelACC_Expense.Note = dr["Note"].ToString();
                    }
                    #endregion

                    return View("ACC_ExpenseAddEdit", modelACC_Expense);
                }
            }
            modelACC_Expense.Date = DateTime.Now;
            return View("ACC_ExpenseAddEdit", modelACC_Expense);
        }
        #endregion

        #region Function: Save Record
        [HttpPost]
        public IActionResult Save(ACC_ExpenseModel modelACC_Expense, string ExpenseID)
        {


            if(modelACC_Expense.ExpenseID == null)
            {
                if(ExpenseID == null)
                {
                    #region Inserting Record

                    if(Convert.ToBoolean(dalACC.PR_Expense_Insert(modelACC_Expense)))
                    {
                        TempData["success"] = "Record Inserted Successfully";
                        return RedirectToAction("Index",modelACC_Expense);
                    }
                    #endregion
                }

                else
                {
                    #region Decrypt Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(ExpenseID);
                    int id = decryptedID.Value;
                    #endregion

                    #region Updating Record
                    if(Convert.ToBoolean(dalACC.PR_Expense_Update(modelACC_Expense, id)))
                    {
                        TempData["success"] = "Record Updated Successfully";
                        return RedirectToAction("Index");
                    }
                    #endregion
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Function: Delete record
        public IActionResult Delete(string? ExpenseID)
        {
            #region Decrypt the Id
            SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(ExpenseID);
            int id = decryptedID.Value;
            #endregion

            #region Deleteing Record
            if(Convert.ToBoolean(dalACC.PR_Expense_Delete(id)))
            {
                TempData["success"] = "Record Deleted successfully.";
            }
            #endregion

            return RedirectToAction("Index");
        }
        #endregion

        public IActionResult Clear()
        {
            return RedirectToAction ("Index");
        }
    }
}
