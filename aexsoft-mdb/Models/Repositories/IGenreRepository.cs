using System.Linq;
using aexsoftmdb.Models.Entities;

namespace aexsoftmdb.Models.Repositories
{
	public interface IGenreRepository
	{
		IQueryable<Genre> Genres { get; }
	}
}
