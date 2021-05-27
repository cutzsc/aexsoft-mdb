using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aexsoftmdb.Models.Entities
{
	/// <summary>
	/// Table that provides "many to many" relationships with movies and actors
	/// </summary>
	public class MovieActorJunction
	{
		public long MovieId { get; set; }
		public Movie Movie { get; set; }

		public long ActorId { get; set; }
		public Actor Actor { get; set; }
	}

	/// <summary>
	/// Table of actors
	/// </summary>
	public class Actor
	{
		[BindNever, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long ActorId { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[BindNever]
		public ICollection<MovieActorJunction> MovieActorJunctions { get; set; }
	}
}
