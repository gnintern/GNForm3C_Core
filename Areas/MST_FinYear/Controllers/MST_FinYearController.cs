using GNForm3C_.Areas.MST_FinYear.Models;
using GNForm3C_.Areas.SEC_User.Models;
using GNForm3C_.BAL;
using GNForm3C_.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlTypes;

namespace GNForm3C_.Areas.MST_FinYear.Controllers
{
    [Area("MST_FinYear")]
    [Route("[Controller]/[action]")]
    public class MST_FinYearController : Controller
    {
        MST_DAL dalMST = new MST_DAL();

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalMST.PR_FinYear_SelectAll();

            #region Fill the record into List
            List<MST_FinYearModel> FinYear = new List<MST_FinYearModel>();
            foreach (DataRow dr in dt.Rows)
            {
                MST_FinYearModel FinYearmodel = new MST_FinYearModel();
                FinYearmodel.FinYearID = Convert.ToInt32(dr["FinYearID"]);
                FinYearmodel.FinYearName = dr["FinYearName"].ToString();
                FinYearmodel.FromDate = Convert.ToDateTime(dr["FromDate"]);
                FinYearmodel.ToDate = Convert.ToDateTime(dr["ToDate"]);
                //FinYearmodel.Created = Convert.ToDateTime(dr["Created"]);
                FinYearmodel.Modified = Convert.ToDateTime(dr["Modified"]);
                FinYear.Add(FinYearmodel);
            }
            ViewBag.FinYearList = FinYear;
            #endregion
            return View("MST_FinYearList");
        }
        #endregion

        #region Function: Delete record
        public IActionResult Delete(string? FinYearID)
        {
            #region Decrypt the Id
            SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(FinYearID);
            int id = decryptedID.Value;
            #endregion

            #region Deleteing Record
            if (Convert.ToBoolean(dalMST.PR_FinYear_Delete(id)))
            {
                TempData["success"] = "Record Deleted successfully.";
            }
            #endregion

            return RedirectToAction("Index");
        }
        #endregion

        #region Function: Upsert the Record

        #region Add Record
        public IActionResult Add(string? FinYearID)
        {

            if (ModelState.IsValid)
            {
                #region Form Title
                TempData["Action"] = "Add";
                #endregion

                if (FinYearID != null)
                {
                    #region Form Title
                    TempData["Action"] = "Edit";
                    #endregion

                    #region Decrypt the Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(FinYearID);
                    int id = decryptedID.Value;
                    #endregion

                    #region PR_User_SelectPK record
                    DataTable dt = dalMST.PR_FinYear_SelectPK(id);
                    MST_FinYearModel modelMST_FinYear = new MST_FinYearModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        modelMST_FinYear.FinYearID = Convert.ToInt32(dr["FinYearID"]);
                        modelMST_FinYear.FinYearName = dr["FinYearName"].ToString();
                        modelMST_FinYear.FromDate = Convert.ToDateTime(dr["FromDate"]);
                        modelMST_FinYear.ToDate = Convert.ToDateTime(dr["ToDate"]);
                        modelMST_FinYear.Created = Convert.ToDateTime(dr["Created"]);
                        modelMST_FinYear.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                    #endregion

                    return View("MST_FinYearAddEdit", modelMST_FinYear);
                }
            }
            return View("MST_FinYearAddEdit");
        }
        #endregion


        [HttpPost]
        #region Save Record
        public IActionResult Save(MST_FinYearModel modelMST_FinYear, string FinYearID)
        {

            if (modelMST_FinYear.FinYearID == null)
            {
                if (FinYearID == null)
                {
                    #region Inserting Record
                    if (Convert.ToBoolean(dalMST.PR_FinYear_Insert(modelMST_FinYear)))
                    {
                        TempData["success"] = "Record Inserted Successfully";
                        return RedirectToAction("Index");
                    }
                    #endregion
                }

                else
                {
                    #region Decrypt Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(FinYearID);
                    int id = decryptedID.Value;
                    #endregion

                    #region Updating Record
                    if (Convert.ToBoolean(dalMST.PR_FinYear_Update(modelMST_FinYear, id)))
                    {
                        TempData["success"] = "Record Updated Successfully";
                        return RedirectToAction("Index");
                    }
                    #endregion
                }
            }
            return RedirectToAction("Index");
            #endregion
        }
        #endregion
    }
}