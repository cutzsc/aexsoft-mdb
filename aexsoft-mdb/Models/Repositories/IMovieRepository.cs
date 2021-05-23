using System.Linq;
using aexsoftmdb.Models.Entities;

namespace aexsoftmdb.Models.Repositories
{
	public interface IMovieRepository
	{
		IQueryable<Movie> Movies { get; }
	}
}
