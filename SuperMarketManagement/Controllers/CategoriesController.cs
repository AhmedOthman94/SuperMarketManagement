using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Models;

namespace SuperMarketManagement.Controllers
{
	public class CategoriesController : Controller
	{
		public IActionResult Index()
		{
			var categories = CategoriesRepository.GetCategories();
			return View(categories);
		}

		public IActionResult Edit(int? id)
		{
			ViewBag.Action = "Edit";
			var category = CategoriesRepository.GetCategoryById(id.HasValue?id.Value:0);

			return View(category);
		}

		[HttpPost]
		public IActionResult Edit(Category category)
		{
			if (ModelState.IsValid)
			{
				CategoriesRepository.UpdateCategory(category.CategoryId, category);
				return RedirectToAction(nameof(Index));
			}

			return View(category);
		}

		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			return View(new Category());
		}

		[HttpPost]
		public IActionResult Add(Category category) 
		{
			if (ModelState.IsValid)
			{
				CategoriesRepository.AddCategory(category);
				return RedirectToAction(nameof(Index));
			}

			return View(category);
		}

		public IActionResult Delete(int categoryId)
		{
			CategoriesRepository.DeleteCategory(categoryId);
			return RedirectToAction(nameof(Index));
		}

	}
}
