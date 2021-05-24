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
		private IGenreRepository genreRepository;

		public HomeController(IMovieRepository movieRepository, IGenreRepository genreRepository,
			IActorRepository actorRepository) =>
			(this.movieRepository, this.genreRepository) = (movieRepository, genreRepository);

		public IActionResult Index(string genre)
		{
			//if (genre != null)
			//{
			//	var movies = movieRepository.Movies.Select(m => m.Genres.Select(g => g.Genre).Where(g => g.Name == genre)).ToArray();
			//	////var movies = movieRepository.Movies
			//	//	.Include(m => m.Genres.Select(g => g.Genre).Where(g => g.Name == genre));
			//	//var movies = movieRepository.Movies.Join(movieRepository.Movies.Select(m => m.Genres.Select(g => g.Genre)),
			//	//	p => p.MovieId,
			//	//	a => a.Select(a => a.GenreId),
			//	//	(p, g) =>
			//	//	{

			//	//	});
			//	//var arrayMovies = movies.ToArray();
			//	//return View(arrayMovies);
			//	return View(movies);
			//}
			return View(movieRepository.Movies);
		}
	}
}
