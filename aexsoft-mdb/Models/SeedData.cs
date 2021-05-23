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

			//if (!context.Movies.Any())
			//{
			//	context.Movies.AddRange(
			//		new Movie() { Title = "" });
			//}
			context.SaveChanges();
		}
	}
}
