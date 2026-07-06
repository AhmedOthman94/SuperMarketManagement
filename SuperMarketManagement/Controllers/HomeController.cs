using Microsoft.AspNetCore.Mvc;

namespace SuperMarketManagement.Controllers
{
	public class HomeController : Controller

	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
