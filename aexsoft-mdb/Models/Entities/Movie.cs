using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aexsoftmdb.Models.Entities
{
	public class Movie
	{
		[BindNever]
		public long MovieId { get; set; }

		[Required]
		public string Title { get; set; }

		[BindNever]
		public ICollection<Actor> Actors { get; set; }

		[BindNever]
		public ICollection<Genre> Genres { get; set; }
	}
}
