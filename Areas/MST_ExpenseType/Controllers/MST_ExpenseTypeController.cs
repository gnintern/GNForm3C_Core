using GNForm3C_.Areas.MST_ExpenseType.Models;
using GNForm3C_.Areas.MST_Hospital.Models;
using GNForm3C_.BAL;
using GNForm3C_.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlTypes;

namespace GNForm3C_.Areas.MST_ExpenseType
{
     [Area("MST_ExpenseType")]
     [Route("[Controller]/[action]")]
    public class MST_ExpenseTypeController : Controller 
    { 
        MST_DAL dalMST = new MST_DAL();

        #region Function: SelectAll
        public IActionResult Index(MST_ExpenseTypeModel modelMST_ExpenseType)
        {
            DataTable dt = dalMST.PR_ExpenseType_SelectAll(modelMST_ExpenseType);

            #region Fill the record into List
            List<MST_ExpenseTypeModel> ExpenseType = new List<MST_ExpenseTypeModel>();
            foreach(DataRow dr in dt.Rows)
            {
                MST_ExpenseTypeModel ExpenseTypeModel = new MST_ExpenseTypeModel();
                ExpenseTypeModel.ExpenseTypeID= Convert.ToInt32(dr["ExpenseTypeID"]);
                ExpenseTypeModel.ExpenseType = dr["ExpenseType"].ToString();
                ExpenseTypeModel.Hospital = dr["Hospital"].ToString();
                ExpenseTypeModel.Remarks = dr["Remarks"].ToString();
                ExpenseTypeModel.Created = Convert.ToDateTime(dr["Created"]);
                ExpenseTypeModel.Modified = Convert.ToDateTime(dr["Modified"]);
                ExpenseType.Add(ExpenseTypeModel);
            }
            ViewBag.ExpenseTypeList = ExpenseType;
            #endregion

            return View("MST_ExpenseTypeList");
        }
        #endregion

        #region Function: Add Record
        public IActionResult Add(string? ExpenseTypeID)
        {

            if(ModelState.IsValid)
            {
                #region Form Title
                TempData["Action"] = "Add";
                #endregion
                ViewBag.HospitalDropDown = CommonFillMethod.SelectDropDownListForHospital().ToList();
                if(ExpenseTypeID != null)
                {
                    #region Form Title
                    TempData["Action"] = "Edit";
                    #endregion

                    #region Decrypt the Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(ExpenseTypeID);
                    int id = decryptedID.Value;
                    #endregion

                    #region Update record
                    DataTable dt = dalMST.PR_ExpenseType_SelectPK(id);
                    MST_ExpenseTypeModel modelMST_ExpenseType = new MST_ExpenseTypeModel();
                    foreach(DataRow dr in dt.Rows)
                    {
                        modelMST_ExpenseType.ExpenseTypeID = Convert.ToInt32(dr["ExpenseTypeID"].ToString());
                        modelMST_ExpenseType.ExpenseType = dr["ExpenseType"].ToString();
                        modelMST_ExpenseType.HospitalID = Convert.ToInt32(dr["HospitalID"]);
                        modelMST_ExpenseType.Remarks = dr["Remarks"].ToString();
                      
                    }
                    #endregion

                    return View("MST_ExpenseTypeAddEdit", modelMST_ExpenseType);
                }
            }
            return View("MST_ExpenseTypeAddEdit");
        }
        #endregion

        #region Function: Save Record
        [HttpPost]
        public IActionResult Save(MST_ExpenseTypeModel modelMST_ExpenseType, string ExpenseTypeID)
        {


            if(modelMST_ExpenseType.ExpenseTypeID == null)
            {
                if(ExpenseTypeID == null)
                {
                    #region Inserting Record
                    if(Convert.ToBoolean(dalMST.PR_ExpenseType_Insert(modelMST_ExpenseType)))
                    {
                        TempData["success"] = "Record Inserted Successfully";
                        return RedirectToAction("Index");
                    }
                    #endregion
                }

                else
                {
                    #region Decrypt Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(ExpenseTypeID);
                    int id = decryptedID.Value;
                    #endregion

                    #region Updating Record
                    if(Convert.ToBoolean(dalMST.PR_ExpenseType_Update(modelMST_ExpenseType, id)))
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
        public IActionResult Delete(string? ExpenseTypeID)
        {
            #region Decrypt the Id
            SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(ExpenseTypeID);
            int id = decryptedID.Value;
            #endregion

            #region Deleteing Record
            if(Convert.ToBoolean(dalMST.PR_ExpenseType_Delete(id)))
            {
                TempData["success"] = "Record Deleted successfully.";
            }
            #endregion

            return RedirectToAction("Index");
        }
        #endregion

    }
}
