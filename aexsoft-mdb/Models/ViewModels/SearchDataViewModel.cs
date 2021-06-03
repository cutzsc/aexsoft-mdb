using aexsoftmdb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aexsoftmdb.Models.ViewModels
{
	/// <summary>
	/// A model with data for searching and Movies that filtered with specific parameters.
	/// </summary>
	public class SearchDataViewModel
	{
		// Result
		public IEnumerable<MovieViewModel> Movies { get; set; }

		// Search parameters
		public IEnumerable<Genre> Genres { get; set; }
		public IEnumerable<Actor> Actors { get; set; }

		// Search selected options
		public long[] GenreIds { get; set; }
		public long[] ActorIds { get; set; }
	}
}
