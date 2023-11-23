using GNForm3C_.Areas.ACC_Expense.Models;
using GNForm3C_.Areas.ACC_Income.Models;
using GNForm3C_.BAL;
using GNForm3C_.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlTypes;

namespace GNForm3C_.Areas.ACC_Income.Controllers
{
    [Area("ACC_Income")]
    [Route("[Controller]/[action]")]
    public class ACC_IncomeController : Controller
    {
        ACC_DAL dalACC = new ACC_DAL();

        #region Function: SelectAll
        public IActionResult Index(ACC_IncomeModel modelACC_Income)
        {
            ViewBag.HospitalDropDown = CommonFillMethod.SelectDropDownListForHospital().ToList();
            ViewBag.FinYearDropDown = CommonFillMethod.SelectDropDownListForFinYear().ToList();
            ViewBag.IncomeTypeDropDown = CommonFillMethod.SelectDropDownListForIncomeType().ToList();

            DataTable dt = dalACC.PR_Income_SelectAll(modelACC_Income);

            #region Fill the record into List
            List<ACC_IncomeModel> Incomes = new List<ACC_IncomeModel>();
            foreach (DataRow dr in dt.Rows)
            {
                ACC_IncomeModel IncomeModel = new ACC_IncomeModel();
                IncomeModel.IncomeID = Convert.ToInt32(dr["IncomeID"]);
                IncomeModel.IncomeType = dr["IncomeType"].ToString();
                IncomeModel.Date = Convert.ToDateTime(dr["Date"]);
                IncomeModel.Amount = Convert.ToDecimal(dr["Amount"].ToString());
                IncomeModel.Note = dr["Note"].ToString();
                IncomeModel.Created = Convert.ToDateTime(dr["Created"]);
                IncomeModel.Modified = Convert.ToDateTime(dr["Modified"]);
                IncomeModel.FinYearName = dr["FinYearName"].ToString();
                IncomeModel.Hospital = dr["Hospital"].ToString();
                Incomes.Add(IncomeModel);
            }
            ViewBag.IncomeList = Incomes;
            #endregion

            return View("ACC_IncomeList");
        }
        #endregion

        #region Function: Add Record
        public IActionResult Add(string? IncomeID)
        {
            if (ModelState.IsValid)
            {
                #region Form Title
                TempData["Action"] = "Add";
                #endregion

                ViewBag.HospitalDropDown = CommonFillMethod.SelectDropDownListForHospital().ToList();
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
                    ACC_IncomeModel modelACC_Income = new ACC_IncomeModel();
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
            return View("ACC_IncomeAddEdit");
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
    }
}
