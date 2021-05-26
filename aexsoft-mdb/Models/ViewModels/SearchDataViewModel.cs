using aexsoftmdb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aexsoftmdb.Models.ViewModels
{
	public class SearchDataViewModel
	{
		// Result
		public IEnumerable<MovieViewModel> Movies { get; set; }

		// Search parameters
		public IEnumerable<Genre> Genres { get; set; }
		public IEnumerable<Actor> Actors { get; set; }
	}
}
