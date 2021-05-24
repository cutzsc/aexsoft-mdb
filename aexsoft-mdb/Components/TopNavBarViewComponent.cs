using Microsoft.AspNetCore.Mvc;
using aexsoftmdb.Models.ViewModels;

namespace aexsoftmdb.Components
{
	public class TopNavBarViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			ViewBag.SelectedMenu = RouteData?.Values;
			return View(NavigationMenuViewModel.GetNavigationMenuModels());
		}
	}
}
