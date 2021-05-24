using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aexsoftmdb.Models.Entities
{
	public class MovieGenreJunction
	{
		public long MovieId { get; set; }
		public Movie Movie { get; set; }

		public long GenreId { get; set; }
		public Genre Genre { get; set; }
	}

	public class Genre
	{
		[BindNever, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long GenreId { get; set; }

		[Required]
		public string Name { get; set; }

		[BindNever]
		public ICollection<MovieGenreJunction> MovieGenreJunctions { get; set; }
	}
}
