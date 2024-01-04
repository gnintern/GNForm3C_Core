using GNForm3C_.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GNForm3C_.Controllers
{
	public class ErrorController : Controller
	{
		[Route("Error/{statusCode}")]
		public IActionResult Error(int statusCode)
		{
			var feature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

			return View(new ErrorViewModel { StatusCode = statusCode, OriginalPath = feature?.OriginalPath });
		}
	}

}
