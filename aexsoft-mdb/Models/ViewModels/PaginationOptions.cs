using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aexsoftmdb.Models.ViewModels
{
	/// <summary>
	/// Information for Pagination Tag Helper
	/// </summary>
	public class PaginationOptions
	{
		public int PageSize { get; set; }
		public int CurrentPage { get; set; }
		public int TotalElements { get; set; }
		public int TotalPages => (int)Math.Ceiling((double)TotalElements / PageSize);
	}
}
