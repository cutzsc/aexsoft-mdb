using Microsoft.AspNetCore.Mvc;
using aexsoftmdb.Models.ViewModels;

namespace aexsoftmdb.Components
{
	/// <summary>
	/// Component which represents navigation for header.
	/// </summary>
	public class TopNavBarViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			ViewBag.SelectedMenu = RouteData?.Values["action"];
			return View(NavigationMenuViewModel.GetNavigationMenuModels());
		}
	}
}
