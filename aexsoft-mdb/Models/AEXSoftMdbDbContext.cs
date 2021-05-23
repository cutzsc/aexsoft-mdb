using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aexsoftmdb.Models.Entities;

namespace aexsoftmdb.Models
{
	public class AEXSoftMdbDbContext : DbContext
	{
		public AEXSoftMdbDbContext(DbContextOptions<AEXSoftMdbDbContext> options)
			: base(options) { }

		public DbSet<Movie> Movies { get; set; }
		public DbSet<Actor> Actors { get; set; }
		public DbSet<Genre> Genres { get; set; }
	}
}
