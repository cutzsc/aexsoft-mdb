using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aexsoftmdb.Models.ViewModels
{
	public class SearchDataViewModel
	{
		public IEnumerable<MovieViewModel> Movies { get; set; }
		public string Genre { get; set; }
		public string Actor { get; set; }
	}
}
