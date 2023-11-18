using GNForm3C_.Areas.MST_Hospital.Models;
using GNForm3C_.Areas.SEC_User.Models;
using GNForm3C_.BAL;
using GNForm3C_.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlTypes;

namespace GNForm3C_.Areas.MST_Hospital.Controllers
{
    [Area("MST_Hospital")]
    [Route("[Controller]/[action]")]
    public class MST_HospitalController : Controller
    {
        MST_DAL dalMST = new MST_DAL();
        #region Function: SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalMST.PR_Hospital_SelectAll();

            #region Fill the record into List
            List<MST_HospitalModel> Hospitals = new List<MST_HospitalModel>();
            foreach (DataRow dr in dt.Rows)
            {
                MST_HospitalModel modelMST_Hospital = new MST_HospitalModel();
                modelMST_Hospital.HospitalID = Convert.ToInt32(dr["HospitalID"]);             
                modelMST_Hospital.Hospital = dr["Hospital"].ToString();
                modelMST_Hospital.PrintName = dr["PrintName"].ToString();
                modelMST_Hospital.PrintLine1 = dr["PrintLine1"].ToString();
                modelMST_Hospital.PrintLine2 = dr["PrintLine2"].ToString();
                modelMST_Hospital.PrintLine3 = dr["PrintLine3"].ToString();            
                //modelMST_Hospital.Modified = Convert.ToDateTime(dr["Modified"]);
                modelMST_Hospital.FooterName = dr["FooterName"].ToString();
                modelMST_Hospital.ReportHeaderName = dr["ReportHeaderName"].ToString();
                Hospitals.Add(modelMST_Hospital);
            }
            ViewBag.HospitalList = Hospitals;
            #endregion
            return View("MST_HospitalList");
        }
        #endregion

        #region Function: Delete record
        public IActionResult Delete(string? HospitalID)
        {
            #region Decrypt the Id
            SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(HospitalID);
            int id = decryptedID.Value;
            #endregion

            #region Deleteing Record
            if (Convert.ToBoolean(dalMST.PR_Hospital_Delete(id)))
            {
                TempData["success"] = "Record Deleted successfully.";
            }
            #endregion

            return RedirectToAction("Index");
        }
        #endregion

        #region Function: Upsert the Record

        #region Add Record
        public IActionResult Add(string? HospitalID)
        {

            if (ModelState.IsValid)
            {
                #region Form Title
                TempData["Action"] = "Add";
                #endregion

                if (HospitalID != null)
                {
                    #region Form Title
                    TempData["Action"] = "Edit";
                    #endregion

                    #region Decrypt the Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(HospitalID);
                    int id = decryptedID.Value;
                    #endregion

                    #region Update record
                    DataTable dt = dalMST.PR_Hospital_SelectPK(id);
                    MST_HospitalModel modelMST_Hospital = new MST_HospitalModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        modelMST_Hospital.HospitalID = Convert.ToInt32(dr["HospitalID"].ToString());
                        modelMST_Hospital.Hospital = dr["Hospital"].ToString();
                        modelMST_Hospital.PrintName = dr["PrintName"].ToString();
                        modelMST_Hospital.PrintLine1 = dr["PrintLine1"].ToString();
                        modelMST_Hospital.PrintLine2 = dr["PrintLine2"].ToString();
                        modelMST_Hospital.PrintLine3 = dr["PrintLine3"].ToString();
                        modelMST_Hospital.Modified = Convert.ToDateTime(dr["Modified"].ToString());
                        modelMST_Hospital.FooterName = dr["FooterName"].ToString();
                        modelMST_Hospital.ReportHeaderName = dr["ReportHeaderName"].ToString();
                    }
                    #endregion

                    return View("MST_HospitalAddEdit", modelMST_Hospital);
                }
            }
            return View("MST_HospitalAddEdit");
        }
        #endregion


        [HttpPost]
        #region Save Record
        public IActionResult Save(MST_HospitalModel modelMST_Hospital, string HospitalID)
        {
           

                if (modelMST_Hospital.HospitalID == null)
                {
                    if (HospitalID == null)
                    {
                        #region Inserting Record
                        if (Convert.ToBoolean(dalMST.PR_Hospital_Insert(modelMST_Hospital)))
                        {
                            TempData["success"] = "Record Inserted Successfully";
                            return RedirectToAction("Index");
                        }
                        #endregion
                    }

                    else
                    {
                        #region Decrypt Id
                        SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(HospitalID);
                        int id = decryptedID.Value;
                        #endregion

                        #region Updating Record
                        if (Convert.ToBoolean(dalMST.PR_Hospital_Update(modelMST_Hospital, id)))
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
