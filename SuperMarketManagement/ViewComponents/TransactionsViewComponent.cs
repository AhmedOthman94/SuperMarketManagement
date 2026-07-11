using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Models;

namespace SuperMarketManagement.ViewComponents
{
	[ViewComponent]
	public class TransactionsViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(string userName)
		{
			var transactions = TransactionsRepository.GetByDayAndCashier(userName, DateTime.Now);
			return View(transactions);
		}
	}
}
