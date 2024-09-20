using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core
{
	public abstract class PagedRequest
	{
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
	}
}
