using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aexsoftmdb.Models.Entities;

namespace aexsoftmdb.Models
{
	/// <summary>
	/// Regular db context of entity framework 
	/// </summary>
	public class AEXSoftMdbDbContext : DbContext
	{
		public AEXSoftMdbDbContext(DbContextOptions<AEXSoftMdbDbContext> options)
			: base(options) { }

		public DbSet<Movie> Movies { get; set; }
		public DbSet<Actor> Actors { get; set; }
		public DbSet<Genre> Genres { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<MovieGenreJunction>()
				.HasKey(t => new { t.MovieId, t.GenreId });

			builder.Entity<MovieGenreJunction>()
				.HasOne(mg => mg.Movie)
				.WithMany(m => m.MovieGenreJunctions)
				.HasForeignKey(mg => mg.MovieId);

			builder.Entity<MovieGenreJunction>()
				.HasOne(mg => mg.Genre)
				.WithMany(g => g.MovieGenreJunctions)
				.HasForeignKey(mg => mg.GenreId);

			builder.Entity<MovieActorJunction>()
				.HasKey(t => new { t.MovieId, t.ActorId });

			builder.Entity<MovieActorJunction>()
				.HasOne(mg => mg.Movie)
				.WithMany(m => m.MovieActorJunctions)
				.HasForeignKey(mg => mg.MovieId);

			builder.Entity<MovieActorJunction>()
				.HasOne(mg => mg.Actor)
				.WithMany(g => g.MovieActorJunctions)
				.HasForeignKey(mg => mg.ActorId);
		}
	}
}
