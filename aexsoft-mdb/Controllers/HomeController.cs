using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

		public int PageSize { get; } = 3;

		public HomeController(IMovieRepository movieRepository, IGenreRepository genreRepository,
			IActorRepository actorRepository) =>
			(this.movieRepository, this.genreRepository, this.actorRepository) = (movieRepository, genreRepository, actorRepository);

		public IActionResult Index(int page = 0)
		{
			Movie[] movies = movieRepository.Movies
				.Skip(PageSize * page)
				.Take(PageSize)
				.ToArray();

			ViewBag.Pagination = new PaginationOptions
			{
				PageSize = PageSize,
				CurrentPage = page,
				TotalElements = movieRepository.Movies.Count()
			};

			return View(CreateMovieViewModelResult(movies));
		}

		public IActionResult Search(long[] genres, long[] actors, int page = 0)
		{
			SearchDataViewModel data = new SearchDataViewModel();

			// Select movies that matches to any parameters
			//Movie[] movies = movieRepository.Movies
			//	.Where(m => m.MovieGenreJunctions.Any(j => genres.Length > 0 ? genres.Contains(j.GenreId) : true))
			//	.Where(m => m.MovieActorJunctions.Any(j => actors.Length > 0 ? actors.Contains(j.ActorId) : true))
			//	.ToArray();

			// Select movies that matches to all parameters
			var movies = movieRepository.Movies;
			foreach (long genreId in genres)
			{
				movies = movies
					.Where(m => m.MovieGenreJunctions.Any(j => j.GenreId == genreId));
			}
			foreach (long actorId in actors)
			{
				movies = movies
					.Where(m => m.MovieActorJunctions.Any(j => j.ActorId == actorId));
			}

			// Create Pagination options
			ViewBag.Pagination = new PaginationOptions
			{
				PageSize = PageSize,
				CurrentPage = page,
				TotalElements = movies.Count()
			};

			// Pagination
			movies = movies
				.Skip(PageSize * page)
				.Take(PageSize);

			// Get genres and actors for each movie
			MovieViewModel[] result = CreateMovieViewModelResult(movies.ToArray());

			data.Movies = result;
			// Parameters for search field
			data.Genres = genreRepository.Genres;
			data.Actors = actorRepository.Actors;
			// Remember selected options for pagination
			data.GenreIds = genres;
			data.ActorIds = actors;

			return View(data);
		}

		/// <summary>
		/// Creates MovieViewModel array from given movie array.
		/// </summary>
		/// <param name="movies"></param>
		/// <returns>MovieViewModel array which contains a movie with genres and actors that belong to this movie.</returns>
		private MovieViewModel[] CreateMovieViewModelResult(Movie[] movies)
		{
			MovieViewModel[] result = new MovieViewModel[movies.Length];
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = new MovieViewModel();
				result[i].Movie = movies[i];
				result[i].Genres = genreRepository.Genres
					.Where(g => g.MovieGenreJunctions.Any(j => j.MovieId == result[i].Movie.MovieId)).ToArray();
				result[i].Actors = actorRepository.Actors
					.Where(g => g.MovieActorJunctions.Any(j => j.MovieId == result[i].Movie.MovieId)).ToArray();
			}

			return result;
		}
	}
}
