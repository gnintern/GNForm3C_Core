using GNForm3C_.Areas.ACC_Expense.Models;
using GNForm3C_.Areas.ACC_Income.Models;
using GNForm3C_.BAL;
using GNForm3C_.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlTypes;

namespace GNForm3C_.Areas.ACC_Income.Controllers
{
    [CheckAccess]
    [Area("ACC_Income")]
    [Route("[Controller]/[action]")]
    public class ACC_IncomeController : Controller
    {
        ACC_DAL dalACC = new ACC_DAL();

        #region Function: SelectAll
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.HospitalDropDown = CommonFillMethod.SetDropDownListForHospital().ToList();
            ViewBag.FinYearDropDown = CommonFillMethod.SelectDropDownListForFinYear().ToList();
            ViewBag.IncomeTypeDropDown = CommonFillMethod.SelectDropDownListForIncomeType().ToList();
            return View("ACC_IncomeList");
        }


        [HttpPost]
        public IActionResult Index(ACC_IncomeModel modelACC_Income)
        {
            ViewBag.HospitalDropDown = CommonFillMethod.SetDropDownListForHospital().ToList();
            ViewBag.FinYearDropDown = CommonFillMethod.SelectDropDownListForFinYear().ToList();
            ViewBag.IncomeTypeDropDown = CommonFillMethod.SelectDropDownListForIncomeType().ToList();

            if (ModelState.IsValid || modelACC_Income.FinYearID != null)
            {

                if (modelACC_Income.FinYearID == 0)
                {
                    return View("ACC_IncomeList", modelACC_Income);
                }
                else
                {
                    DataTable dt = dalACC.PR_Income_SelectAll(modelACC_Income);

                    #region Fill the record into List
                    List<ACC_IncomeModel> Incomes = new List<ACC_IncomeModel>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        ACC_IncomeModel IncomeModel = new ACC_IncomeModel();
                        IncomeModel.IncomeID = Convert.ToInt32(dr["IncomeID"]);
                        //IncomeModel.IncomeTypeID = Convert.ToInt32(dr["IncomeTypeID"]);
                        IncomeModel.IncomeType = dr["IncomeType"].ToString();
                        IncomeModel.Date = Convert.ToDateTime(dr["Date"]);
                        IncomeModel.Amount = Convert.ToDecimal(dr["Amount"].ToString());
                        IncomeModel.Note = dr["Note"].ToString();
                        IncomeModel.Created = Convert.ToDateTime(dr["Created"]);
                        IncomeModel.Modified = Convert.ToDateTime(dr["Modified"]);
                        //IncomeModel.FinYearID = Convert.ToInt32(dr["FinYearID"]);
                        IncomeModel.FinYearName = dr["FinYearName"].ToString();
                        //IncomeModel.HospitalID = Convert.ToInt32(dr["HospitalID"]);
                        IncomeModel.Hospital = dr["Hospital"].ToString();
                        Incomes.Add(IncomeModel);
                    }
                    ViewBag.IncomeList = Incomes;
                    #endregion

                    return View("ACC_IncomeList");
                }
            }
            return View("ACC_IncomeList");

        }

        #endregion

        #region Function: Add Record
        public IActionResult Add(string? IncomeID)
        {
			ACC_IncomeModel modelACC_Income = new ACC_IncomeModel();

			if (ModelState.IsValid)
            {
                #region Form Title
                TempData["Action"] = "Add";
                #endregion

                ViewBag.HospitalDropDown = CommonFillMethod.SetDropDownListForHospital().ToList();
                ViewBag.IncomeTypeDropDown = CommonFillMethod.SelectDropDownListForIncomeType().ToList();


                if (IncomeID != null)
                {
                    #region Form Title
                    TempData["Action"] = "Edit";
                    #endregion

                    #region Decrypt the Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(IncomeID);
                    int id = decryptedID.Value;
                    #endregion

                    #region Update record
                    DataTable dt = dalACC.PR_Income_SelectPK(id);
                    foreach (DataRow dr in dt.Rows)
                    {
                        modelACC_Income.IncomeID = Convert.ToInt32(dr["IncomeID"]);
                        modelACC_Income.IncomeTypeID = Convert.ToInt32(dr["IncomeTypeID"]);
                        modelACC_Income.HospitalID = Convert.ToInt32(dr["HospitalID"]);
                        modelACC_Income.Date = Convert.ToDateTime(dr["Date"]);
                        modelACC_Income.Amount = Convert.ToDecimal(dr["Amount"].ToString());
                        modelACC_Income.Note = dr["Note"].ToString();
                    }
                    #endregion

                    return View("ACC_IncomeAddEdit", modelACC_Income);
                }
            }
            return View("ACC_IncomeAddEdit", modelACC_Income);
        }
        #endregion

        #region Function: Save Record
        [HttpPost]
        public IActionResult Save(ACC_IncomeModel modelACC_Income, string IncomeID)
        {
            if (modelACC_Income.IncomeID == null)
            {
                if (IncomeID == null)
                {
                    #region Inserting Record

                    if (Convert.ToBoolean(dalACC.PR_Income_Insert(modelACC_Income)))
                    {
                        TempData["success"] = "Record Inserted Successfully";
                        return RedirectToAction("Index");
                    }
                    #endregion
                }

                else
                {
                    #region Decrypt Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(IncomeID);
                    int id = decryptedID.Value;
                    #endregion

                    #region Updating Record
                    if (Convert.ToBoolean(dalACC.PR_Income_Update(modelACC_Income, id)))
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
        public IActionResult Delete(string? IncomeID)
        {
            #region Decrypt the Id
            SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(IncomeID);
            int id = decryptedID.Value;
            #endregion

            #region Deleteing Record
            if (Convert.ToBoolean(dalACC.PR_Income_Delete(id)))
            {
                TempData["success"] = "Record Deleted successfully.";
            }
            #endregion

            return RedirectToAction("Index");
        }
        #endregion

        #region Clear Search
        public IActionResult Clear()
        {
            return RedirectToAction("Index");
        }
        #endregion
    }
}
