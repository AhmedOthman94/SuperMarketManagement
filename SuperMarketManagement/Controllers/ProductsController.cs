using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Models;

namespace SuperMarketManagement.Controllers
{
	public class ProductsController : Controller
	{
		public IActionResult Index()
		{
			var products = ProductsRepository.GetProducts(loadCategory: true);
			return View(products);
		}
	}
}
