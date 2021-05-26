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
		private IActorRepository actorRepository;

		public HomeController(IMovieRepository movieRepository, IGenreRepository genreRepository,
			IActorRepository actorRepository) =>
			(this.movieRepository, this.genreRepository, this.actorRepository) = (movieRepository, genreRepository, actorRepository);

		public IActionResult Index(string genre)
		{
			Movie[] movies = movieRepository.Movies.Select(m => m).ToArray();
			return View(CreateMovieViewModelResult(movies));
		}

		public IActionResult Search(long[] genres, long[] actors)
		{
			SearchDataViewModel data = new SearchDataViewModel();

			Movie[] movies = movieRepository.Movies
				.Where(m => m.MovieGenreJunctions
					.Any(j => genres.Length > 0 ? genres[0] == 0 || genres[0] == j.GenreId : true))
				.Where(m => m.MovieActorJunctions
					.Any(j => actors.Length > 0 ? actors[0] == 0 || actors[0] == j.ActorId : true))
				.ToArray();

			MovieViewModel[] result = CreateMovieViewModelResult(movies);

			data.Movies = result;
			data.Genres = genreRepository.Genres;
			data.Actors = actorRepository.Actors;

			return View(data);
		}

		private MovieViewModel[] CreateMovieViewModelResult(Movie[] movies)
		{
			MovieViewModel[] result = new MovieViewModel[movies.Length];
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = new MovieViewModel();
				result[i].Movie = movies[i];
				result[i].Genres = genreRepository.Genres
					.Where(g => g.MovieGenreJunctions.Any(mg => mg.MovieId == result[i].Movie.MovieId)).ToArray();
				result[i].Actors = actorRepository.Actors
					.Where(g => g.MovieActorJunctions.Any(ma => ma.MovieId == result[i].Movie.MovieId)).ToArray();
			}

			return result;
		}
	}
}
