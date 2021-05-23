using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace aexsoftmdb.Models.Entities
{
	public class Actor
	{
		[BindNever]
		public long ActorId { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		public string FullName => FirstName + ' ' + LastName;
	}
}
