using GNForm3C_.Areas.MST_IncomeType.Models;
using GNForm3C_.BAL;
using GNForm3C_.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using System.Data;

namespace GNForm3C_.Areas.MST_IncomeType.Controllers
{
    [CheckAccess]
    [Area("MST_IncomeType")]
    [Route("[Controller]/[action]")]
    public class MST_IncomeTypeController : Controller
    {
        MST_DAL dalMST = new MST_DAL();

        #region Function: SelectAll
        public IActionResult Index(MST_IncomeTypeModel modelMST_IncomeType)
        {
			ViewBag.HospitalDropDown = CommonFillMethod.SetDropDownListForHospital().ToList();
			DataTable dt = dalMST.PR_IncomeType_SelectAll(modelMST_IncomeType);

            #region Fill the record into List
            List<MST_IncomeTypeModel> IncomeType = new List<MST_IncomeTypeModel>();
            foreach (DataRow dr in dt.Rows)
            {
                MST_IncomeTypeModel IncomeTypeModel = new MST_IncomeTypeModel();
                IncomeTypeModel.IncomeTypeID = Convert.ToInt32(dr["IncomeTypeID"]);
                IncomeTypeModel.IncomeType = dr["IncomeType"].ToString();
                IncomeTypeModel.Hospital = dr["Hospital"].ToString();
                IncomeTypeModel.Remarks = dr["Remarks"].ToString();
                IncomeTypeModel.Created = Convert.ToDateTime(dr["Created"]);
                IncomeTypeModel.Modified = Convert.ToDateTime(dr["Modified"]);
                IncomeType.Add(IncomeTypeModel);
            }
            ViewBag.IncomeTypeList = IncomeType;
            #endregion
                    
            return View("MST_IncomeTypeList");
        }
        #endregion

        #region Function: Add Record
        public IActionResult Add(string? IncomeTypeID)
        {

            if (ModelState.IsValid)
            {
                #region Form Title
                TempData["Action"] = "Add";
                #endregion

                #region Form Title
                ViewData["Title"] = "Add";
                #endregion
                ViewBag.HospitalDropDown = CommonFillMethod.SetDropDownListForHospital().ToList();
                if (IncomeTypeID != null)
                {
                    #region Form Title
                    TempData["Action"] = "Edit";
                    #endregion

                    #region Form Title
                    ViewData["Title"] = "Edit";
                    #endregion

                    #region Decrypt the Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(IncomeTypeID);
                    int id = decryptedID.Value;
					#endregion

					#region SelectPK 
					DataTable dt = dalMST.PR_IncomeType_SelectPK(id);
                    MST_IncomeTypeModel modelMST_IncomeType = new MST_IncomeTypeModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        modelMST_IncomeType.IncomeTypeID = Convert.ToInt32(dr["IncomeTypeID"].ToString());
                        modelMST_IncomeType.IncomeType = dr["IncomeType"].ToString();
                        modelMST_IncomeType.HospitalID = Convert.ToInt32(dr["HospitalID"]);
                        modelMST_IncomeType.Remarks = dr["Remarks"].ToString();
						modelMST_IncomeType.Created = Convert.ToDateTime(dr["Created"]);
						modelMST_IncomeType.Modified = Convert.ToDateTime(dr["Modified"]);
					}
                    #endregion

                    return View("MST_IncomeTypeAddEdit", modelMST_IncomeType);
                }
            }
            return View("MST_IncomeTypeAddEdit");
        }
        #endregion

        #region Function: Save Record
        [HttpPost]
        public IActionResult Save(MST_IncomeTypeModel modelMST_IncomeType, string IncomeTypeID)
        {


            if (modelMST_IncomeType.IncomeTypeID == null)
            {
                if (IncomeTypeID == null)
                {
                    #region Inserting Record
                    if (Convert.ToBoolean(dalMST.PR_IncomeType_Insert(modelMST_IncomeType)))
                    {
                        TempData["success"] = "Record Inserted Successfully";
                        return RedirectToAction("Index");
                    }
                    #endregion
                }

                else
                {
                    #region Decrypt Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(IncomeTypeID);
                    int id = decryptedID.Value;
                    #endregion

                    #region Updating Record
                    if (Convert.ToBoolean(dalMST.PR_IncomeType_Update(modelMST_IncomeType, id)))
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
        public IActionResult Delete(string? IncomeTypeID)
        {
            #region Decrypt the Id
            SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(IncomeTypeID);
            int id = decryptedID.Value;
            #endregion

            #region Deleteing Record
            if (Convert.ToBoolean(dalMST.PR_IncomeType_Delete(id)))
            {
                TempData["success"] = "Record Deleted successfully.";
            }
            #endregion

            return RedirectToAction("Index");
        }
        #endregion
    }
}
