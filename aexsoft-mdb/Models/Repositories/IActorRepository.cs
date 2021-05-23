using System.Linq;

namespace aexsoftmdb.Models.Repositories
{
	public interface IActorRepository
	{
		IQueryable<Actor> Actors { get; }
	}
}
