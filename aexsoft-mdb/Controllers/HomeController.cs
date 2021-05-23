using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aexsoftmdb.Models.Entities;
using aexsoftmdb.Models.Repositories;
using aexsoftmdb.Models.ViewModels;

namespace aexsoftmdb.Controllers
{
	public class HomeController : Controller
	{
		private IMovieRepository movieRepository;
		private IGenreRepository genreRepository;
		private IActorRepository actorRepository;

		public HomeController(IMovieRepository movieRepository,
			IGenreRepository genreRepository,
			IActorRepository actorRepository) =>
			(this.movieRepository, this.genreRepository, this.actorRepository) =
			(movieRepository, genreRepository, actorRepository);

		public IActionResult Index()
		{
			return View(new MoviesListViewModel()
			{
				Genres = genreRepository.Genres,
				Actors = actorRepository.Actors
			});
		}
	}
}
