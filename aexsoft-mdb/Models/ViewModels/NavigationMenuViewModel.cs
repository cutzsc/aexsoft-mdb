using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aexsoftmdb.Models.ViewModels
{
	/// <summary>
	/// Hard coded data for navigation menu.
	/// </summary>
	public class NavigationMenuViewModel
	{
		private NavigationMenuModel[] menuModels;

		public NavigationMenuViewModel()
		{
			menuModels = new NavigationMenuModel[]
			{
				new NavigationMenuModel
				{
					Controller = "Home",
					Action = "Index",
					Name = "Home"
				},
				new NavigationMenuModel
				{
					Controller = "Home",
					Action = "Search",
					Name = "Search"
				}
			};
		}

		public static NavigationMenuModel[] GetNavigationMenuModels()
		{
			return new NavigationMenuViewModel().menuModels;
		}
	}

	/// <summary>
	/// Data model for menu element.
	/// </summary>
	public class NavigationMenuModel
	{
		public string Controller { get; set; }
		public string Action { get; set; }
		public string Name { get; set; }
	}
}
