using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aexsoftmdb.Models.Entities;
using aexsoftmdb.Models.Repositories;
using aexsoftmdb.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace aexsoftmdb.Controllers
{
	public class HomeController : Controller
	{
		private IMovieRepository movieRepository;

		public HomeController(IMovieRepository movieRepository,
			IActorRepository actorRepository) =>
			(this.movieRepository) = (movieRepository);

		public IActionResult Index(string genre)
		{
			if (genre != null)
			{
				////var movies = movieRepository.Movies
				//	.Include(m => m.Genres.Select(g => g.Genre).Where(g => g.Name == genre));
				//var movies = movieRepository.Movies.Join(movieRepository.Movies.Select(m => m.Genres.Select(g => g.Genre)),
				//	p => p.MovieId,
				//	a => a.Select(a => a.GenreId),
				//	(p, g) =>
				//	{

				//	});
				//var arrayMovies = movies.ToArray();
				//return View(arrayMovies);
			}
			return View(movieRepository.Movies);
		}
	}
}
