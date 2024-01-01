using GNForm3C_.Areas.MST_SubTreatment.Models;
using GNForm3C_.Areas.SEC_User.Models;
using GNForm3C_.BAL;
using GNForm3C_.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlTypes;

namespace GNForm3C_.Areas.MST_SubTreatment.Controllers
{
    [Area("MST_SubTreatment")]
    [Route("[Controller]/[action]")]
    public class MST_SubTreatmentController : Controller
    {
         MST_DAL dalMST = new MST_DAL();
         
        #region Function: SelectAll
        public IActionResult Index(MST_SubTreatmentModel modelMST_SubTreatment)
            {
                ViewBag.HospitalDropDown = CommonFillMethod.SetDropDownListForHospital().ToList();
                DataTable dt = dalMST.PR_SubTreatment_SelectAll(modelMST_SubTreatment);

                #region Fill the record into List
                List<MST_SubTreatmentModel> SubTreatment = new List<MST_SubTreatmentModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    MST_SubTreatmentModel SubTreatmentmodel = new MST_SubTreatmentModel();
                    SubTreatmentmodel.SubTreatmentID = Convert.ToInt32(dr["SubTreatmentID"]);
                    SubTreatmentmodel.SubTreatmentName = dr["SubTreatmentName"].ToString();
                    SubTreatmentmodel.SequenceNo = Convert.IsDBNull(dr["SequenceNo"]) ? null : Convert.ToInt32(dr["SequenceNo"]);
                    SubTreatmentmodel.Rate = Convert.IsDBNull(dr["Rate"]) ? null : Convert.ToDecimal(dr["Rate"]);
                    SubTreatmentmodel.IsInGrid = Convert.ToBoolean(dr["IsInGrid"]);
                    SubTreatmentmodel.IsPerDay = Convert.ToBoolean(dr["IsPerDay"]);
                    SubTreatmentmodel.Remarks = dr["Remarks"].ToString();
                    SubTreatmentmodel.Hospital = dr["Hospital"].ToString();
                    SubTreatmentmodel.DefaultUnit = dr["DefaultUnit"].ToString();
                    SubTreatmentmodel.Created = Convert.ToDateTime(dr["Created"]);
                    SubTreatmentmodel.Modified = Convert.ToDateTime(dr["Modified"]);
                    SubTreatment.Add(SubTreatmentmodel);
                }
                ViewBag.SubTreatmentList = SubTreatment;
                #endregion

                return View("MST_SubTreatmentList");
            }
        #endregion

        #region Function: Delete record
        public IActionResult Delete(string? SubTreatmentID)
        {
            #region Decrypt the Id
            SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(SubTreatmentID);
            int id = decryptedID.Value;
            #endregion

            #region Deleteing Record
            if (Convert.ToBoolean(dalMST.PR_SubTreatment_Delete(id)))
            {
                TempData["success"] = "Record Deleted successfully.";
            }
            #endregion

            return RedirectToAction("Index");
        }
        #endregion

        #region Function: Upsert the Record

        #region Add Record
        public IActionResult Add(string? SubTreatmentID)
        {

            if (ModelState.IsValid)
            {
                #region Form Title
                TempData["Action"] = "Add";
                #endregion

                ViewBag.HospitalDropDown = CommonFillMethod.SetDropDownListForHospital().ToList();

                if (SubTreatmentID != null)
                {
                    #region Form Title
                    TempData["Action"] = "Edit";
                    #endregion

                    #region Decrypt the Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(SubTreatmentID);
                    int id = decryptedID.Value;
                    #endregion

                    #region PR_SubTreatment_SelectPK record
                    DataTable dt = dalMST.PR_SubTreatment_SelectPK(id);
                    MST_SubTreatmentModel modelMST_SubTreatment = new MST_SubTreatmentModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        modelMST_SubTreatment.SubTreatmentID = Convert.ToInt32(dr["SubTreatmentID"].ToString());
                        modelMST_SubTreatment.SubTreatmentName = dr["SubTreatmentName"].ToString();
                        modelMST_SubTreatment.SequenceNo = Convert.IsDBNull(dr["SequenceNo"]) ? null : Convert.ToInt32(dr["SequenceNo"]);
                        modelMST_SubTreatment.Rate = Convert.IsDBNull(dr["Rate"]) ? null : Convert.ToDecimal(dr["Rate"]);
                        modelMST_SubTreatment.IsInGrid = Convert.ToBoolean(dr["IsInGrid"]);
                        modelMST_SubTreatment.IsPerDay = Convert.ToBoolean(dr["IsPerDay"]);
                        modelMST_SubTreatment.Remarks = dr["Remarks"].ToString();
                        modelMST_SubTreatment.HospitalID = Convert.ToInt32(dr["HospitalID"]);
                        modelMST_SubTreatment.DefaultUnit = dr["DefaultUnit"].ToString();
                        //SubTreatmentmodel.Created = Convert.ToDateTime(dr["Created"]);
                        modelMST_SubTreatment.Modified = Convert.ToDateTime(dr["Modified"]);
                    }
                    #endregion

                    return View("MST_SubTreatmentAddEdit", modelMST_SubTreatment);
                }
            }
            return View("MST_SubTreatmentAddEdit");
        }
        #endregion


        [HttpPost]
        #region Save Record
        public IActionResult Save(MST_SubTreatmentModel modelSubTreatment, string SubTreatmentID)
        {

            if (modelSubTreatment.SubTreatmentID == null)
            {
                if (SubTreatmentID == null)
                {
                    #region Inserting Record
                    if (Convert.ToBoolean(dalMST.PR_SubTreatment_Insert(modelSubTreatment)))
                    {
                        TempData["success"] = "Record Inserted Successfully";
                        return RedirectToAction("Index");
                    }
                    #endregion
                }

                else
                {
                    #region Decrypt Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(SubTreatmentID);
                    int id = decryptedID.Value;
                    #endregion

                    #region Updating Record
                    if (Convert.ToBoolean(dalMST.PR_SubTreatment_Update(modelSubTreatment, id)))
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

        #endregion
    }
}

