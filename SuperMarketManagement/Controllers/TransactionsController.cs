using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Models;
using SuperMarketManagement.ViewModels;

namespace SuperMarketManagement.Controllers
{
	public class TransactionsController : Controller
	{
		public IActionResult Index()
		{
			TransactionsViewModel transactionsViewModel = new TransactionsViewModel();
			return View(transactionsViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Search(TransactionsViewModel transactionsViewModel)
		{
			var transactions = TransactionsRepository.Search(
				transactionsViewModel.CashierName ?? string.Empty,
				transactionsViewModel.StartDate,
				transactionsViewModel.EndDate);

			transactionsViewModel.Transactions = transactions;

			return View("Index", transactionsViewModel);
		}
	}
}
