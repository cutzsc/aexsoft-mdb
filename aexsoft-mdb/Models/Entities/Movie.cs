using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aexsoftmdb.Models.Entities
{
	public class Movie
	{
		[BindNever, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long MovieId { get; set; }

		[Required]
		public string Title { get; set; }

		[DataType(DataType.Date)]
		[Required]
		public DateTime ReleaseDate { get; set; }

		[Required]
		public string Description { get; set; }

		[BindNever]
		public ICollection<MovieGenreJunction> MovieGenreJunctions { get; set; }

		[BindNever]
		public ICollection<MovieActorJunction> MovieActorJunctions { get; set; }
	}
}
