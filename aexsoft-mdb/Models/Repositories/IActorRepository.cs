using System.Linq;
using aexsoftmdb.Models.Entities;

namespace aexsoftmdb.Models.Repositories
{
	public interface IActorRepository
	{
		IQueryable<Actor> Actors { get; }
	}
}
