using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aexsoftmdb.Models.Entities;

namespace aexsoftmdb.Models
{
	public static class SeedData
	{
		public static void EnsurePopulated(IApplicationBuilder app)
		{
			AEXSoftMdbDbContext context = app.ApplicationServices
				.CreateScope().ServiceProvider.GetRequiredService<AEXSoftMdbDbContext>();

			if (context.Database.GetPendingMigrations().Any())
			{
				context.Database.Migrate();
			}

			if (!context.Genres.Any())
			{
				context.Genres.AddRange(
					new Genre() { Name = "Action" },
					new Genre() { Name = "Adventure" },
					new Genre() { Name = "Animation" },
					new Genre() { Name = "Biography" },
					new Genre() { Name = "Comedy" },
					new Genre() { Name = "Crime" },
					new Genre() { Name = "Documentary" },
					new Genre() { Name = "Drama" },
					new Genre() { Name = "Family" },
					new Genre() { Name = "Fantasy" },
					new Genre() { Name = "History" },
					new Genre() { Name = "Horror" },
					new Genre() { Name = "Music" },
					new Genre() { Name = "Musical" },
					new Genre() { Name = "Mystery" },
					new Genre() { Name = "Romance" },
					new Genre() { Name = "Sci-Fi" },
					new Genre() { Name = "Sport" },
					new Genre() { Name = "Superhero" },
					new Genre() { Name = "Thriller" },
					new Genre() { Name = "War" },
					new Genre() { Name = "Western" });
			}
			context.SaveChanges();

			if (!context.Actors.Any())
			{
				context.Actors.AddRange(
					new Actor() { FirstName = "Джесси", LastName = "Айзенберг" },
					new Actor() { FirstName = "Вуди", LastName = "Харрельсон" },
					new Actor() { FirstName = "Дэйв", LastName = "Франко" },
					new Actor() { FirstName = "Кристен", LastName = "Стюарт" },
					new Actor() { FirstName = "Роберт", LastName = "Паттинсон" },
					new Actor() { FirstName = "Дэниэл", LastName = "Рэдклифф" },
					new Actor() { FirstName = "Эмма", LastName = "Уотсон" },
					new Actor() { FirstName = "Сирша", LastName = "Ронан" },
					new Actor() { FirstName = "Марго", LastName = "Робби" });
			}
			context.SaveChanges();

			if (!context.Movies.Any())
			{
				Movie movie = new Movie();
				List<MovieActors> actors = new List<MovieActors>();
				List<MovieGenres> genres = new List<MovieGenres>();

				// ------------------------------------------

				movie.Title = "Now You See Me";
				movie.ReleaseDate = new DateTime(2013, 6, 6);
				movie.Description = "An F.B.I. Agent and an Interpol Detective track a team of illusionists who pull off bank heists during their performances, and reward their audiences with the money.";
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Джесси") });
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Дэйв") });
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Вуди") });
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Дэниэл") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Thriller") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Crime") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Mystery") });

				movie.Actors = actors.ToArray();
				movie.Genres = genres.ToArray();

				context.AttachRange(movie.Actors.Select(a => a.Actor));
				context.Movies.Add(movie);

				// ------------------------------------------
				movie = new Movie();
				actors = new List<MovieActors>();
				genres = new List<MovieGenres>();

				movie.Title = "Zombieland";
				movie.ReleaseDate = new DateTime(2009, 10, 8);
				movie.Description = "A shy student trying to reach his family in Ohio, a gun-toting bruiser in search or the last Twinkie and a pair of sisters striving to get to an amusement park join forces in a trek across a zombie-filled America.";
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Джесси") });
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Эмма") });
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Вуди") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Adventure") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Comedy") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Fantasy") });

				movie.Actors = actors.ToArray();
				movie.Genres = genres.ToArray();

				context.AttachRange(movie.Actors.Select(a => a.Actor));
				context.Movies.Add(movie);

				// ------------------------------------------
				movie = new Movie();
				actors = new List<MovieActors>();
				genres = new List<MovieGenres>();

				movie.Title = "American Ultra";
				movie.ReleaseDate = new DateTime(2015, 8, 27);
				movie.Description = "A stoner - who is in fact a government agent - is marked as a liability and targeted for extermination. But he's too well-trained and too high for them to handle.";
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Джесси") });
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Кристен") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Action") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Comedy") });

				movie.Actors = actors.ToArray();
				movie.Genres = genres.ToArray();

				context.AttachRange(movie.Actors.Select(a => a.Actor));
				context.Movies.Add(movie);

				// ------------------------------------------
				movie = new Movie();
				actors = new List<MovieActors>();
				genres = new List<MovieGenres>();

				movie.Title = "Twilight";
				movie.ReleaseDate = new DateTime(2008, 11, 20);
				movie.Description = "When Bella Swan moves to a small town in the Pacific Northwest, she falls in love with Edward Cullen, a mysterious classmate who reveals himself to be a 108-year-old vampire.";
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Кристен") });
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Роберт") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Drama") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Fantasy") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Romance") });

				movie.Actors = actors.ToArray();
				movie.Genres = genres.ToArray();

				context.AttachRange(movie.Actors.Select(a => a.Actor));
				context.Movies.Add(movie);

				// ------------------------------------------
				movie = new Movie();
				actors = new List<MovieActors>();
				genres = new List<MovieGenres>();

				movie.Title = "The Twilight Saga: Breaking Dawn - Part 2";
				movie.ReleaseDate = new DateTime(2012, 11, 15);
				movie.Description = "After the birth of Renesmee/Nessie, the Cullens gather other vampire clans in order to protect the child from a false allegation that puts the family in front of the Volturi.";
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Кристен") });
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Роберт") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Drama") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Fantasy") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Romance") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Adventure") });

				movie.Actors = actors.ToArray();
				movie.Genres = genres.ToArray();

				context.AttachRange(movie.Actors.Select(a => a.Actor));
				context.Movies.Add(movie);

				// ------------------------------------------
				movie = new Movie();
				actors = new List<MovieActors>();
				genres = new List<MovieGenres>();

				movie.Title = "Harry Potter and the Goblet of Fire";
				movie.ReleaseDate = new DateTime(2005, 12, 22);
				movie.Description = "Harry Potter finds himself competing in a hazardous tournament between rival schools of magic, but he is distracted by recurring nightmares.";
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Эмма") });
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Дэниэл") });
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Роберт") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Adventure") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Family") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Fantasy") });

				movie.Actors = actors.ToArray();
				movie.Genres = genres.ToArray();

				context.AttachRange(movie.Actors.Select(a => a.Actor));
				context.Movies.Add(movie);

				// ------------------------------------------
				movie = new Movie();
				actors = new List<MovieActors>();
				genres = new List<MovieGenres>();

				movie.Title = "Now You See Me 2";
				movie.ReleaseDate = new DateTime(2016, 6, 9);
				movie.Description = "The Four Horsemen resurface, and are forcibly recruited by a tech genius to pull off their most impossible heist yet.";
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Джесси") });
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Дэйв") });
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Вуди") });
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Дэниэл") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Action") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Adventure") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Comedy") });

				movie.Actors = actors.ToArray();
				movie.Genres = genres.ToArray();

				context.AttachRange(movie.Actors.Select(a => a.Actor));
				context.Movies.Add(movie);

				// ------------------------------------------
				movie = new Movie();
				actors = new List<MovieActors>();
				genres = new List<MovieGenres>();

				movie.Title = "Little Women";
				movie.ReleaseDate = new DateTime(2020, 1, 30);
				movie.Description = "Jo March reflects back and forth on her life, telling the beloved story of the March sisters - four young women, each determined to live life on her own terms.";
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Эмма") });
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Сирша") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Drama") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Romance") });

				movie.Actors = actors.ToArray();
				movie.Genres = genres.ToArray();

				context.AttachRange(movie.Actors.Select(a => a.Actor));
				context.Movies.Add(movie);

				// ------------------------------------------
				movie = new Movie();
				actors = new List<MovieActors>();
				genres = new List<MovieGenres>();

				movie.Title = "Mary Queen of Scots";
				movie.ReleaseDate = new DateTime(2019, 1, 17);
				movie.Description = "Mary Stuart's (Saoirse Ronan's) attempt to overthrow her cousin Elizabeth I (Margot Robbie), Queen of England, finds her condemned to years of imprisonment before facing execution.";
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Сирша") });
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Марго") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Drama") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Biography") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "History") });

				movie.Actors = actors.ToArray();
				movie.Genres = genres.ToArray();

				context.AttachRange(movie.Actors.Select(a => a.Actor));
				context.Movies.Add(movie);

				// ------------------------------------------
				movie = new Movie();
				actors = new List<MovieActors>();
				genres = new List<MovieGenres>();

				movie.Title = "The Wolf of Wall Street";
				movie.ReleaseDate = new DateTime(2014, 2, 6);
				movie.Description = "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.";
				actors.Add(new MovieActors() { Actor = context.Actors.First(a => a.FirstName == "Марго") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Biography") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Crime") });
				genres.Add(new MovieGenres() { Genre = context.Genres.First(g => g.Name == "Drama") });

				movie.Actors = actors.ToArray();
				movie.Genres = genres.ToArray();

				context.AttachRange(movie.Actors.Select(a => a.Actor));
				context.Movies.Add(movie);
			}
			context.SaveChanges();
		}
	}
}
