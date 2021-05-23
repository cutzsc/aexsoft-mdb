using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace aexsoftmdb.Models.Entities
{
	public class Genre
	{
		[BindNever]
		public long GenreId { get; set; }

		[Required]
		public string Name { get; set; }
	}
}
