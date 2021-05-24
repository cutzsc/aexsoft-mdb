using Xunit;
using Moq;
using aexsoftmdb.Models.Entities;
using aexsoftmdb.Models.Repositories;
using aexsoftmdb.Models.ViewModels;
using System.Linq;
using aexsoftmdb.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace aexsoftmdb.Tests
{
	public class RepositoryTests
	{
		//[Fact]
		//public void Can_Use_Movies_Repository()
		//{
		//	// Arrange
		//	Mock<IMovieRepository> mockMovies = new Mock<IMovieRepository>();
		//	mockMovies.Setup(m => m.Movies).Returns((new Movie[]
		//	{
		//		new Movie() { MovieId = 1, Title = "m1" },
		//		new Movie() { MovieId = 2, Title = "m2" },
		//		new Movie() { MovieId = 3, Title = "m3" }
		//	}).AsQueryable);

		//	Mock<IGenreRepository> mockGenres = new Mock<IGenreRepository>();
		//	mockGenres.Setup(m => m.Genres).Returns((new Genre[]
		//	{
		//			new Genre() { GenreId = 1, Name = "g1" },
		//			new Genre() { GenreId = 2, Name = "g2" },
		//			new Genre() { GenreId = 3, Name = "g3" },
		//			new Genre() { GenreId = 4, Name = "g4" }
		//	}).AsQueryable);

		//	Mock<IActorRepository> mockActors = new Mock<IActorRepository>();
		//	mockActors.Setup(m => m.Actors).Returns((new Actor[]
		//	{
		//			new Actor() { ActorId = 1, FirstName = "n1" },
		//			new Actor() { ActorId = 2, FirstName = "n2" }
		//	}).AsQueryable);

		//	HomeController controller = new HomeController(
		//		mockMovies.Object, mockGenres.Object, mockActors.Object);


		//	// Act
		//	MoviesListViewModel data = (controller.Index() as ViewResult).ViewData.Model as MoviesListViewModel;

		//	// Assert
		//	Assert.NotNull(data);
		//	Assert.True(data.Genres.Count() == 4);
		//	Assert.NotNull(data.Genres.FirstOrDefault(g => g.Name == "g3"));

		//	Assert.True(data.Actors.Count() == 2);
		//	Assert.NotNull(data.Actors.FirstOrDefault(a => a.FirstName == "n1"));
		//}
	}
}
