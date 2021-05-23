using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aexsoftmdb.Models.Entities;


namespace aexsoftmdb.Models.Repositories
{
	public class EFActorRepository : IActorRepository
	{
		private AEXSoftMdbDbContext context;

		public EFActorRepository(AEXSoftMdbDbContext context) =>
			this.context = context;

		public IQueryable<Actor> Actors => context.Actors;
	}
}
