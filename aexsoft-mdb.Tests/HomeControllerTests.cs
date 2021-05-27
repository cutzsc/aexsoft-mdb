using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Moq;
using aexsoftmdb.Models;
using aexsoftmdb.Models.Entities;
using aexsoftmdb.Models.Repositories;
using aexsoftmdb.Models.ViewModels;
using aexsoftmdb.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace aexsoftmdb.Tests
{
	public class HomeControllerTests
	{
		[Fact]
		public void Can_Get_Movies_Data()
		{
			// Arrange
			Mock<IMovieRepository> mockMovies = new Mock<IMovieRepository>();
			mockMovies.Setup(m => m.Movies).Returns((new Movie[]
			{
				new Movie() { MovieId = 1, Title = "m1" },
				new Movie() { MovieId = 2, Title = "m2" },
				new Movie() { MovieId = 3, Title = "m3" }
			}).AsQueryable);

			Mock<IGenreRepository> mockGenres = new Mock<IGenreRepository>();
			mockGenres.Setup(m => m.Genres).Returns((new Genre[]
			{
					new Genre() { GenreId = 1, Name = "g1", MovieGenreJunctions = new MovieGenreJunction[] { new MovieGenreJunction() { GenreId = 1, MovieId = 1 } } },
					new Genre() { GenreId = 2, Name = "g2", MovieGenreJunctions = new MovieGenreJunction[] { new MovieGenreJunction() { GenreId = 2, MovieId = 1 } } },
					new Genre() { GenreId = 3, Name = "g3", MovieGenreJunctions = new MovieGenreJunction[] { new MovieGenreJunction() { GenreId = 3, MovieId = 2 } } },
					new Genre() { GenreId = 4, Name = "g4", MovieGenreJunctions = new MovieGenreJunction[] { new MovieGenreJunction() { GenreId = 4, MovieId = 3 } } }
			}).AsQueryable);

			Mock<IActorRepository> mockActors = new Mock<IActorRepository>();
			mockActors.Setup(m => m.Actors).Returns((new Actor[]
			{
					new Actor() { ActorId = 1, FirstName = "n1", MovieActorJunctions = new MovieActorJunction[] { new MovieActorJunction() { ActorId = 1, MovieId = 1 } } },
					new Actor() { ActorId = 2, FirstName = "n2", MovieActorJunctions = new MovieActorJunction[] { new MovieActorJunction() { ActorId = 2, MovieId = 1 } } }
			}).AsQueryable);

			HomeController controller = new HomeController(
				mockMovies.Object, mockGenres.Object, mockActors.Object);


			// Act
			MovieViewModel[] data = (controller.Index() as ViewResult).ViewData.Model as MovieViewModel[];

			// Assert
			Assert.NotNull(data);
			Assert.True(data.Length == 3);
			Assert.True(data[0].Genres.Count() == 2);
			Assert.True(data[1].Genres.Count() == 1);
			Assert.True(data[2].Genres.Count() == 1);

			Assert.True(data[0].Actors.Count() == 2);
			Assert.True(data[1].Actors.Count() == 0);
			Assert.True(data[2].Actors.Count() == 0);

			Assert.Equal("n1", data[0].Actors.First().FirstName);
			Assert.Equal("g2", data[0].Genres.First(g => g.GenreId == 2).Name);
		}
	}
}
