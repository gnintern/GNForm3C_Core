using GNForm3C_.Areas.MST_ExpenseType.Models;
using GNForm3C_.BAL;
using GNForm3C_.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using System.Data;
using GNForm3C_.Areas.MST_Treatment.Models;

namespace GNForm3C_.Areas.MST_Treatment.Controllers
{
    [Area("MST_Treatment")]
    [Route("[Controller]/[action]")]
    public class MST_TreatmentController : Controller
    {
        MST_DAL dalMST = new MST_DAL();

        #region Function: SelectAll
        public IActionResult Index(MST_TreatmentModel modelMST_Treatment)
        {
            DataTable dt = dalMST.PR_Treatment_SelectAll(modelMST_Treatment);

            ViewBag.HospitalDropDown = CommonFillMethod.SelectDropDownListForHospital().ToList();

            #region Fill the record into List
            List<MST_TreatmentModel> Treatment = new List<MST_TreatmentModel>();
            foreach (DataRow dr in dt.Rows)
            {
                MST_TreatmentModel TreatmentModel = new MST_TreatmentModel();
                TreatmentModel.TreatmentID = Convert.ToInt32(dr["TreatmentID"]);
                TreatmentModel.Treatment = dr["Treatment"].ToString();
                TreatmentModel.Hospital = dr["Hospital"].ToString();
                TreatmentModel.Remarks = dr["Remarks"].ToString();
                TreatmentModel.Created = Convert.ToDateTime(dr["Created"]);
                TreatmentModel.Modified = Convert.ToDateTime(dr["Modified"]);
                Treatment.Add(TreatmentModel);
            }
            ViewBag.TreatmentList = Treatment;
            #endregion

            return View("MST_TreatmentList");
        }
        #endregion

        #region Function: Add Record
        public IActionResult Add(string? TreatmentID)
        {

            if (ModelState.IsValid)
            {
                #region Form Title
                TempData["Action"] = "Add";
                #endregion

                ViewBag.HospitalDropDown = CommonFillMethod.SelectDropDownListForHospital().ToList();
                if (TreatmentID != null)
                {
                    #region Form Title
                    TempData["Action"] = "Edit";
                    #endregion

                    #region Decrypt the Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(TreatmentID);
                    int id = decryptedID.Value;
                    #endregion

                    #region SelectByPk 
                    DataTable dt = dalMST.PR_Treatment_SelectPK(id);
                    MST_TreatmentModel modelMST_Treatment = new MST_TreatmentModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        modelMST_Treatment.TreatmentID = Convert.ToInt32(dr["TreatmentID"].ToString());
                        modelMST_Treatment.Treatment = dr["Treatment"].ToString();
                        modelMST_Treatment.HospitalID = Convert.ToInt32(dr["HospitalID"]);
                        modelMST_Treatment.Remarks = dr["Remarks"].ToString();
                    }
                    #endregion

                    return View("MST_TreatmentAddEdit", modelMST_Treatment);
                }
            }
            return View("MST_TreatmentAddEdit");
        }
        #endregion

        #region Function: Save Record
        [HttpPost]
        public IActionResult Save(MST_TreatmentModel modelMST_Treatment, string TreatmentID)
        {
            if (modelMST_Treatment.TreatmentID == null)
            {
                if (TreatmentID == null)
                {
                    #region Inserting Record
                    if (Convert.ToBoolean(dalMST.PR_Treatment_Insert(modelMST_Treatment)))
                    {
                        TempData["success"] = "Record Inserted Successfully";
                        return RedirectToAction("Index");
                    }
                    #endregion
                }

                else
                {
                    #region Decrypt Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(TreatmentID);
                    int id = decryptedID.Value;
                    #endregion

                    #region Updating Record
                    if (Convert.ToBoolean(dalMST.PR_Treatment_Update(modelMST_Treatment, id)))
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
        public IActionResult Delete(string? TreatmentID)
        {
            #region Decrypt the Id
            SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(TreatmentID);
            int id = decryptedID.Value;
            #endregion

            #region Deleteing Record
            if (Convert.ToBoolean(dalMST.PR_Treatment_Delete(id)))
            {
                TempData["success"] = "Record Deleted successfully.";
            }
            #endregion

            return RedirectToAction("Index");
        }
        #endregion
    }
}
