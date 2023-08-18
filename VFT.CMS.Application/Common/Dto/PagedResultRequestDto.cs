using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Application.Common.Dto
{
	public class PagedResultRequestDto<T> : List<T>
	{
		public PagedResultRequestDto() { }

		public int TotalRecords { get; set; }

		public PagedResultRequestDto(List<T> source, int pageIndex, int pageSize)
		{
			TotalRecords = source.Count;

			var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

			this.AddRange(items);
		}
	}
}
