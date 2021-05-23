using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aexsoftmdb.Models.Entities;

namespace aexsoftmdb.Models.ViewModels
{
	public class MoviesListViewModel
	{
		public IEnumerable<Movie> Movies { get; set; }
		public IEnumerable<Genre> Genres { get; set; }
		public IEnumerable<Actor> Actors { get; set; }
	}
}
