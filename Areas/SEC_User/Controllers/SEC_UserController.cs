using GNForm3C_.Areas.SEC_User.Models;
using GNForm3C_.BAL;
using GNForm3C_.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlTypes;

namespace GNForm3C_.Areas.SEC_User.Controllers
{
    [Area("SEC_User")]
    [Route("[Controller]/[action]")]
    public class SEC_UserController : Controller
    {
        MST_DAL dalMST = new MST_DAL();

        #region Function: SelectAll
        public IActionResult Index(SEC_UserModel modelSEC_User)
        {
            ViewBag.HospitalDropDown = CommonFillMethod.SelectDropDownListForHospital().ToList();

            DataTable dt = dalMST.PR_SEC_User_SelectAll(modelSEC_User);
            #region Fill the record into List
            List<SEC_UserModel> Users = new List<SEC_UserModel>();
            foreach (DataRow dr in dt.Rows)
            {
                SEC_UserModel UserModel = new SEC_UserModel();
                UserModel.UserID = Convert.ToInt32(dr["UserID"]);
                UserModel.UserName = dr["UserName"].ToString();
                UserModel.Hospital = dr["Hospital"].ToString();
                UserModel.IsActive = Convert.ToBoolean(dr["IsActive"]);
                UserModel.Created = Convert.ToDateTime(dr["Created"]);
                UserModel.Modified = Convert.ToDateTime(dr["Modified"]);
                Users.Add(UserModel);
            }
            ViewBag.UserList = Users;
            #endregion

            return View("SEC_UserList");
        }
        #endregion

        #region Function: Delete record
        public IActionResult Delete(string? UserID)
        {
            #region Decrypt the Id
            SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(UserID);
            int id = decryptedID.Value;
            #endregion

            #region Deleteing Record
            if (Convert.ToBoolean(dalMST.PR_User_Delete(id)))
            {
                TempData["success"] = "Record Deleted successfully.";
            }
            #endregion

            return RedirectToAction("Index");
        }
        #endregion

        #region Function: Upsert the Record

        #region Add Record
        public IActionResult Add(string? UserID)
        {

            if (ModelState.IsValid)
            {
                #region Form Title
                TempData["Action"] = "Add";
                #endregion


                ViewBag.HospitalDropDown =CommonFillMethod.SelectDropDownListForHospital().ToList();

                if (UserID != null)
                {
                    #region Form Title
                    TempData["Action"] = "Edit";
                    #endregion

                    #region Decrypt the Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(UserID);
                    int id = decryptedID.Value;
                    #endregion

                    #region PR_User_SelectPK record
                    DataTable dt = dalMST.PR_User_SelectPK(id);
                    SEC_UserModel modelSEC_User = new SEC_UserModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        modelSEC_User.UserID = Convert.ToInt32(dr["UserID"].ToString());
                        modelSEC_User.UserName = dr["UserName"].ToString();
                        modelSEC_User.Password = dr["Password"].ToString();
                        modelSEC_User.HospitalID = Convert.ToInt32(dr["HospitalID"]);
                        modelSEC_User.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    }
                    #endregion

                    return View("SEC_UserAddEdit", modelSEC_User);
                }
            }
            return View("SEC_UserAddEdit");
        }
        #endregion


        [HttpPost]
        #region Save Record
        public IActionResult Save(SEC_UserModel modelSEC_User, string UserID)
        {
            if (modelSEC_User.Password == modelSEC_User.ConfirmPassword)
            {

                if (modelSEC_User.UserID == null)
                {
                    if (UserID == null)
                    {
                        #region Inserting Record
                        if (Convert.ToBoolean(dalMST.PR_User_Insert(modelSEC_User)))
                        {
                            TempData["success"] = "Record Inserted Successfully";
                            return RedirectToAction("Index");
                        }
                        #endregion
                    }

                    else
                    {
                        #region Decrypt Id
                        SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(UserID);
                        int id = decryptedID.Value;
                        #endregion

                        #region Updating Record
                        if (Convert.ToBoolean(dalMST.PR_User_Update(modelSEC_User, id)))
                        {
                            TempData["success"] = "Record Updated Successfully";
                            return RedirectToAction("Index");
                        }
                        #endregion
                    }
                }
            }
            else
            {
                #region Error if Password & Confirm Password not Matched
                TempData["error"] = "password and confirm password are not matched!";
                #endregion

                return View("SEC_UserAddEdit");
            }
            return RedirectToAction("Index");
        }
        #endregion


        #endregion


        #region Function: Clear Search Result
        public IActionResult Clear()
        {
            return RedirectToAction("Index");
        }
        #endregion

        #region Login
        public IActionResult Login()
        {
            return View();
        }
        #endregion
    }
}
