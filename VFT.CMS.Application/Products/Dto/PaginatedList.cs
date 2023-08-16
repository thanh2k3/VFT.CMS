using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Application.Products.Dto
{
	public class PaginatedList<T> : List<T>
	{
		public int TotalRecords { get; set; }

		public PaginatedList(List<T> source, int pageIndex, int pageSize)
		{
			TotalRecords = source.Count;

			var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

			this.AddRange(items);
		}
	}
}
