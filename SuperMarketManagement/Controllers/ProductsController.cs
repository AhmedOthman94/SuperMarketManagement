using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Models;
using SuperMarketManagement.ViewModels;

namespace SuperMarketManagement.Controllers
{
	public class ProductsController : Controller
	{
		public IActionResult Index()
		{
			var products = ProductsRepository.GetProducts(loadCategory: true);
			return View(products);
		}

		public IActionResult Add()
		{
			var productViewModel = new ProductViewModel
			{
				Categories = CategoriesRepository.GetCategories()
			};

			return View(productViewModel);
		}

		[HttpPost]
		public IActionResult Add(ProductViewModel productViewModel)
		{
			if (ModelState.IsValid)
			{
				ProductsRepository.AddProduct(productViewModel.Product);
				return RedirectToAction(nameof(Index));
			}
			productViewModel.Categories = CategoriesRepository.GetCategories();
			return View(productViewModel);
		}
	}
}
