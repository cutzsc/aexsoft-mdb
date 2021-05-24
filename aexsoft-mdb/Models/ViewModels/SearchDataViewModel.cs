﻿using aexsoftmdb.Models.Entities;
using System.Collections.Generic;

namespace aexsoftmdb.Models.ViewModels
{
	public class SearchDataViewModel
	{
		public IEnumerable<Genre> Genres { get; set; }
		public IEnumerable<Actor> Actors { get; set; }
	}
}
