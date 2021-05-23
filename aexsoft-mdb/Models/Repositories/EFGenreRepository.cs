using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aexsoftmdb.Models.Repositories
{
	public class EFGenreRepository : IGenreRepository
	{
		private AEXSoftMdbDbContext context;

		public EFGenreRepository(AEXSoftMdbDbContext context) =>
			this.context = context;

		public IQueryable<Genre> Genres => context.Genres;
	}
}
