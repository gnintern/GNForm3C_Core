﻿using GNForm3C_.Areas.MST_IncomeType.Models;
using GNForm3C_.Areas.MST_ReceiptType.Models;
using GNForm3C_.Areas.MST_ReceiptType.Models;
using GNForm3C_.BAL;
using GNForm3C_.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlTypes;

namespace GNForm3C_.Areas.MST_ReceiptType.Controllers
{
    [CheckAccess]
    [Area("MST_ReceiptType")]
    [Route("[Controller]/[action]")]
    public class MST_ReceiptTypeController : Controller
    {     
            MST_DAL dalMST = new MST_DAL();

            #region Function: SelectAll
            public IActionResult Index(MST_ReceiptTypeModel modelMST_ReceiptType)
            {
			ViewBag.HospitalDropDown = CommonFillMethod.SetDropDownListForHospital().ToList();
			DataTable dt = dalMST.PR_ReceiptType_SelectAll(modelMST_ReceiptType);

                #region Fill the record into List
                List<MST_ReceiptTypeModel> ReceiptType = new List<MST_ReceiptTypeModel>();
                foreach (DataRow dr in dt.Rows)
                {
                MST_ReceiptTypeModel ReceiptTypeModel = new MST_ReceiptTypeModel();
                ReceiptTypeModel.ReceiptTypeID = Convert.ToInt32(dr["ReceiptTypeID"]);
                ReceiptTypeModel.ReceiptTypeName = dr["ReceiptTypeName"].ToString();
                ReceiptTypeModel.PrintName = dr["PrintName"].ToString();
                ReceiptTypeModel.IsDefault = Convert.ToBoolean(dr["IsDefault"]);
                ReceiptTypeModel.Hospital = dr["Hospital"].ToString();
                ReceiptTypeModel.Remarks = dr["Remarks"].ToString();
                ReceiptTypeModel.Created = Convert.ToDateTime(dr["Created"]);
                ReceiptTypeModel.Modified = Convert.ToDateTime(dr["Modified"]);
                ReceiptType.Add(ReceiptTypeModel);
                }
                ViewBag.ReceiptTypeList = ReceiptType;
                #endregion

                return View("MST_ReceiptTypeList");
            }
        #endregion

            #region Function: Delete record
        public IActionResult Delete(string? ReceiptTypeID)
        {
            #region Decrypt the Id
            SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(ReceiptTypeID);
            int id = decryptedID.Value;
            #endregion

            #region Deleteing Record
            if (Convert.ToBoolean(dalMST.PR_ReceiptType_Delete(id)))
            {
                TempData["success"] = "Record Deleted successfully.";
            }
            #endregion

            return RedirectToAction("Index");
        }
        #endregion

            #region Add Record
        public IActionResult Add(string? ReceiptTypeID)
        {

            if (ModelState.IsValid)
            {
                #region Form Title
                TempData["Action"] = "Add";
				#endregion

				#region Button Title
				TempData["ButtonAction"] = "Save";
				#endregion

				ViewBag.HospitalDropDown = CommonFillMethod.SetDropDownListForHospital().ToList();

                if (ReceiptTypeID != null)
                {
                    #region Form Title
                    TempData["Action"] = "Edit";
					#endregion

					#region Button Title
					TempData["ButtonAction"] = "Update";
					#endregion

					#region Decrypt the Id
					SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(ReceiptTypeID);
                    int id = decryptedID.Value;
                    #endregion

                    #region PR_ReceiptType_SelectPK record
                    DataTable dt = dalMST.PR_ReceiptType_SelectPK(id);
                    MST_ReceiptTypeModel modelMST_ReceiptType = new MST_ReceiptTypeModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        modelMST_ReceiptType.ReceiptTypeID = Convert.ToInt32(dr["ReceiptTypeID"].ToString());
                        modelMST_ReceiptType.ReceiptTypeName = dr["ReceiptTypeName"].ToString();
                        modelMST_ReceiptType.PrintName = dr["PrintName"].ToString();
                        modelMST_ReceiptType.IsDefault = Convert.ToBoolean(dr["IsDefault"]);
                        modelMST_ReceiptType.Remarks = dr["Remarks"].ToString();
                        modelMST_ReceiptType.HospitalID = Convert.ToInt32(dr["HospitalID"]);
                        //ReceiptTypemodel.Created = Convert.ToDateTime(dr["Created"]);
                        modelMST_ReceiptType.Modified = Convert.ToDateTime(dr["Modified"]);
                    }
                    #endregion

                    return View("MST_ReceiptTypeAddEdit", modelMST_ReceiptType);
                }
            }
            return View("MST_ReceiptTypeAddEdit");
        }
        #endregion

        

        #region Save Record
        [HttpPost]
        public IActionResult Save(MST_ReceiptTypeModel modelReceiptType, string ReceiptTypeID)
        {

            if (modelReceiptType.ReceiptTypeID == null)
            {
                if (ReceiptTypeID == null)
                {
                    #region Inserting Record
                    if (Convert.ToBoolean(dalMST.PR_ReceiptType_Insert(modelReceiptType)))
                    {
                        TempData["success"] = "Record Inserted Successfully";
                        return RedirectToAction("Index");
                    }
                    #endregion
                }

                else
                {
                    #region Decrypt Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(ReceiptTypeID);
                    int id = decryptedID.Value;
                    #endregion

                    #region Updating Record
                    if (Convert.ToBoolean(dalMST.PR_ReceiptType_Update(modelReceiptType, id)))
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

        #region Fill ReceiptType Modal
        public IActionResult ReceiptTypeDetail(string? modalID)
        {

            MST_ReceiptTypeModel modelMST_ReceiptType = new MST_ReceiptTypeModel();
            #region Decrypt the Id
            SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(modalID);
            int id = decryptedID.Value;
            #endregion

            #region Select_PK record
            DataTable dt = dalMST.PR_ReceiptType_SelectView(id);
            foreach (DataRow dr in dt.Rows)
            {
                modelMST_ReceiptType.ReceiptTypeID = Convert.ToInt32(dr["ReceiptTypeID"].ToString());
                modelMST_ReceiptType.ReceiptTypeName = dr["ReceiptTypeName"].ToString();
                modelMST_ReceiptType.PrintName = dr["PrintName"].ToString();
                modelMST_ReceiptType.IsDefault = Convert.ToBoolean(dr["IsDefault"]);
                modelMST_ReceiptType.Remarks = dr["Remarks"].ToString();
                modelMST_ReceiptType.Hospital = dr["Hospital"].ToString();
                modelMST_ReceiptType.Modified = Convert.ToDateTime(dr["Modified"]);
            }
            #endregion
            return PartialView("~/Areas/MST_ReceiptType/Views/Shared/_ReceiptTypeDetails.cshtml", modelMST_ReceiptType);
        }
        #endregion


    }
}

