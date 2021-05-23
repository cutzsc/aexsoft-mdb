using System.Collections.Generic;


namespace aexsoftmdb.Models
{
	public class Movie
	{
		public long MovieId { get; set; }

		public string Title { get; set; }

		public ICollection<Actor> Actors { get; set; }

		public ICollection<Genre> Genres { get; set; }
	}
}
