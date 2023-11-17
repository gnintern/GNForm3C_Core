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
        MST_DAL dalMST= new MST_DAL();

        #region SelectAll
        public IActionResult Index()
        { 
            DataTable dt =dalMST.PR_SEC_User_SelectAll();
            List<SEC_UserModel> Users = new List<SEC_UserModel>();
            foreach(DataRow dr in dt.Rows)
            {
                SEC_UserModel modelSEC_User = new SEC_UserModel();
                modelSEC_User.UserID = Convert.ToInt32(dr["UserID"]);
                modelSEC_User.UserName = dr["UserName"].ToString();
                modelSEC_User.Hospital = dr["Hospital"].ToString();
                modelSEC_User.Modified = Convert.ToDateTime(dr["Modified"]);
                Users.Add(modelSEC_User);
            }
            ViewBag.UserList = Users;
            return View("SEC_UserList");
        }
        #endregion

        #region Delete
        public IActionResult Delete(string? UserID)
        {
            #region Decrypt the Id
            SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(UserID);
            int id = decryptedID.Value;
            #endregion

            if (Convert.ToBoolean(dalMST.PR_User_Delete(id)))
            {
                TempData["success"] = "Record Deleted successfully.";
            }
            return RedirectToAction("Index");


        }
        #endregion

        #region AddEdit

        #region Add
        public IActionResult Add(string? UserID)
        {

            if (ModelState.IsValid)
            {

                if (UserID != null)
                {
                    #region Decrypt the Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(UserID);
                    int id = decryptedID.Value;
                    #endregion

                    DataTable dt = dalMST.PR_User_SelectPK(id);

                    SEC_UserModel modelSEC_User = new SEC_UserModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        modelSEC_User.UserID = Convert.ToInt32(dr["UserID"].ToString());
                        modelSEC_User.UserName = dr["UserName"].ToString();
                        modelSEC_User.Password = dr["Password"].ToString();
                    }
                    return View("SEC_UserAddEdit", modelSEC_User);
                }
            }
            return View("SEC_UserAddEdit");
        }
        #endregion


        [HttpPost]
        #region Save
        public IActionResult Save(SEC_UserModel modelSEC_User, string UserID)
        {
            if (modelSEC_User.Password == modelSEC_User.ConfirmPassword)
            {

            if (modelSEC_User.UserID == null)
            {
                if (UserID == null)
                {
                    if (Convert.ToBoolean(dalMST.PR_User_Insert(modelSEC_User)))
                    {
                        TempData["success"] = "Record Inserted Successfully";
                        return RedirectToAction("Index");
                    }
                }

                else
                {
                    #region Decrypt Id
                    SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(UserID);
                    int id = decryptedID.Value;
                    #endregion

                    if (Convert.ToBoolean(dalMST.PR_User_Update(modelSEC_User, id)))
                    {
                        TempData["success"] = "Record Updated Successfully";
                        return RedirectToAction("Index");
                    }
                }
            }
            }
            else
            {
                TempData["error"] ="password and confirm password are not matched!";
                return View("SEC_UserAddEdit");

            }
            return RedirectToAction("Index");


        }
        #endregion


        #endregion

    }
}
