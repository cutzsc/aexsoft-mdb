using System.Linq;

namespace aexsoftmdb.Models.Repositories
{
	public interface IGenreRepository
	{
		IQueryable<Genre> Genres { get; }
	}
}
