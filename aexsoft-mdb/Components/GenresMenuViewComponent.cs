using aexsoftmdb.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aexsoftmdb.Components
{
	public class GenresMenuViewComponent : ViewComponent
	{
		private IGenreRepository genreRepository;

		public GenresMenuViewComponent(IGenreRepository genreRepository) =>
			this.genreRepository = genreRepository;

		public IViewComponentResult Invoke()
		{
			return View(genreRepository.Genres);
		}
	}
}
