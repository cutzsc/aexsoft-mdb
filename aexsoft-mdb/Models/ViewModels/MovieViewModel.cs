﻿using aexsoftmdb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aexsoftmdb.Models.ViewModels
{
	public class MovieViewModel
	{
		public Movie Movie { get; set; }
		public IEnumerable<Actor> Actors { get; set; }
		public IEnumerable<Genre> Genres { get; set; }
	}
}
