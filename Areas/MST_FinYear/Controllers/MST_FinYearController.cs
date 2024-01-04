using GNForm3C_.Areas.MST_FinYear.Models;
using GNForm3C_.Areas.SEC_User.Models;
using GNForm3C_.BAL;
using GNForm3C_.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlTypes;
using System.Reflection;

namespace GNForm3C_.Areas.MST_FinYear.Controllers
{
    [CheckAccess]
    [Area("MST_FinYear")]
	[Route("[Controller]/[action]")]
	public class MST_FinYearController : Controller
	{
		MST_DAL dalMST = new MST_DAL();

		#region SelectAll
		public IActionResult Index(MST_FinYearModel modelMST_FinYear)
		{
			DataTable dt = dalMST.PR_FinYear_SelectAll(modelMST_FinYear);

			#region Fill the record into List
			List<MST_FinYearModel> FinYear = new List<MST_FinYearModel>();
			foreach(DataRow dr in dt.Rows)
			{
				MST_FinYearModel FinYearmodel = new MST_FinYearModel();
				FinYearmodel.FinYearID = Convert.ToInt32(dr["FinYearID"]);
				FinYearmodel.FinYearName = dr["FinYearName"].ToString();
				FinYearmodel.FromDate = Convert.ToDateTime(dr["FromDate"]);
				FinYearmodel.ToDate = Convert.ToDateTime(dr["ToDate"]);
				FinYearmodel.Created = Convert.ToDateTime(dr["Created"]);
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
			if(Convert.ToBoolean(dalMST.PR_FinYear_Delete(id)))
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
			MST_FinYearModel modelMST_FinYear = new MST_FinYearModel();

			if(ModelState.IsValid)
			{
				#region Form Title
				TempData["Action"] = "Add";
				#endregion

				if(FinYearID != null)
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
					foreach(DataRow dr in dt.Rows)
					{
						modelMST_FinYear.FinYearID = Convert.ToInt32(dr["FinYearID"].ToString());
						modelMST_FinYear.FinYearName = dr["FinYearName"].ToString();
						modelMST_FinYear.FromDate = Convert.ToDateTime(dr["FromDate"]);
						modelMST_FinYear.ToDate = Convert.ToDateTime(dr["ToDate"]);
						modelMST_FinYear.Modified = Convert.ToDateTime(dr["Modified"]);

					}
					#endregion

					return View("MST_FinYearAddEdit", modelMST_FinYear);
				}
			}
			return View("MST_FinYearAddEdit");
		}
        #endregion

        #region Save Record
        [HttpPost]
        public IActionResult Save(MST_FinYearModel modelMST_FinYear, string FinYearID)
        {
            var fromDate = modelMST_FinYear.FromDate;
            var toDate = modelMST_FinYear.ToDate;

            if(FinYearID != null)
            {
                #region Decrypt Id
                SqlInt32 decryptedID = CommonFunctions.DecryptBase64Int32(FinYearID);
                int id = decryptedID.Value;
                #endregion

                modelMST_FinYear.FinYearID = id;
            }

            if(fromDate > toDate)
            {
                TempData["error"] = "From Date cannot be greater than To Date.";
                //return View("MST_FinYearAddEdit", modelMST_FinYear);
                if(modelMST_FinYear.FinYearID == null)
                {
                    return RedirectToAction("Add");
                }
                else
                {
                    return View("MST_FinYearAddEdit", modelMST_FinYear);
                }
            }

            // Calculate the difference between From Date and To Date
            var daysBetweenDates = (toDate - fromDate).TotalDays;

            // Check if the difference is exactly one year, considering leap years
            if(daysBetweenDates == 364 || (daysBetweenDates == 365 && IsLeapYear(toDate.Year)))
            {
                var financialYearStart = fromDate.Year;
                var financialYearEnd = toDate.Year;

                modelMST_FinYear.FinYearName = $"{financialYearStart}-{financialYearEnd.ToString().Substring(2, 2)}";
            }
            else
            {


                TempData["error"] = "The difference between From Date and To Date must be exactly one year.";
                if(modelMST_FinYear.FinYearID == null)
                {
                    return RedirectToAction("Add");
                }
                else
                {

                    return View("MST_FinYearAddEdit", modelMST_FinYear);
                }
            }


            bool isFinYearNameExists = dalMST.PR_FinYear_CheckISExist(modelMST_FinYear.FinYearName);

            if(isFinYearNameExists)
            {
                TempData["error"] = "FinYearName already exists.";

                if(modelMST_FinYear.FinYearID == null)
                {
                    return RedirectToAction("Add");
                }
                else
                {
                    return View("MST_FinYearAddEdit", modelMST_FinYear);
                }

            }



            if(FinYearID == null)
            {

                #region Inserting Record
                if(Convert.ToBoolean(dalMST.PR_FinYear_Insert(modelMST_FinYear)))
                {
                    TempData["success"] = "Record Inserted Successfully";
                    return RedirectToAction("Index");
                }
                #endregion
            }

            else
            {

                #region Updating Record
                if(Convert.ToBoolean(dalMST.PR_FinYear_Update(modelMST_FinYear)))
                {
                    TempData["success"] = "Record Updated Successfully";
                    return RedirectToAction("Index");
                }
                #endregion
            }

            return RedirectToAction("Index");
        }
        #endregion

        #endregion

        #region IsLeapYear
        private bool IsLeapYear(int year)
		{
			if(year % 4 == 0)
			{
				if(year % 100 == 0)
				{
					return year % 400 == 0;
				}
				else
				{
					return true;
				}
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
}
