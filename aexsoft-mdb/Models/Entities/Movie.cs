using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aexsoftmdb.Models.Entities
{
	public class MovieGenres
	{
		public long MovieGenresId { get; set; }
		public Genre Genre { get; set; }
	}

	public class MovieActors
	{
		public long MovieActorsId { get; set; }
		public Actor Actor { get; set; }
	}

	public class Movie
	{
		[BindNever]
		public long MovieId { get; set; }

		[Required]
		public string Title { get; set; }

		[DataType(DataType.Date)]
		[Required]
		public DateTime ReleaseDate { get; set; }

		[Required]
		public string Description { get; set; }

		[BindNever]
		public ICollection<MovieGenres> Genres { get; set; }

		[BindNever]
		public ICollection<MovieActors> Actors { get; set; }
	}
}
