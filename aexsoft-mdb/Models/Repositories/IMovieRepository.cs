using System.Linq;

namespace aexsoftmdb.Models.Repositories
{
	public interface IMovieRepository
	{
		IQueryable<Movie> Movies { get; }
	}
}
