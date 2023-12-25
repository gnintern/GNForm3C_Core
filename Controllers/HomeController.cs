using GNForm3C_.BAL;
using GNForm3C_.DAL;
using GNForm3C_.Models;
using GNForm3C_.Models.Viewmodel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace GNForm3C_.Controllers
{
	[CheckAccess]
	public class HomeController : Controller
	{
		MST_DAL dalMST = new MST_DAL();

		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		#region Function: Dashboard
		public IActionResult Index()
		{
			DataTable dt1 = dalMST.PR_MST_CountHospitalTreatmentIncomeExpenseDashboard();
			DataTable dtReceipt = dalMST.PR_Dashboard_TransactionRecentlyAdded();
			DataTable dtTreatment = dalMST.PR_Dashboard_TreatmentRecentlyAdded();
			DataTable dtIncome = dalMST.PR_Dashboard_IncomeRecentlyAdded();
			DataTable dtExpense = dalMST.PR_Dashboard_ExpenseRecentlyAdded();




			var viewModel = new DataTable_ViewModel
			{
				DataTable1 = dt1,
				DataTableReceipt = dtReceipt,
				DataTableTreatment = dtTreatment,
				DataTableIncome = dtIncome,
				DataTableExpense = dtExpense,
				//DataTable3 = dt3
			};

			return View(viewModel);
		}
		#endregion

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}