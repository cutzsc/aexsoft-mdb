using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aexsoftmdb.Models.Repositories
{
	public class EFMovieRepository : IMovieRepository
	{
		private AEXSoftMdbDbContext context;

		public EFMovieRepository(AEXSoftMdbDbContext context) =>
			this.context = context;

		public IQueryable<Movie> Movies => context.Movies;
	}
}
