using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace VFT.CMS.Application.Products.Dto
{
	public class PagedProductResultRequestDto
	{
		public int TotalItems { get; set; }
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
		public int TotalPages { get; set; }
		public int StartPage { get; set; }
		public int EndPage { get; set; }
		public int StartRecord { get; set; }
		public int EndRecord { get; set; }

		public string Action { get; set; } = "Index";
		public string SearchText { get; set; }


		public PagedProductResultRequestDto(int totalItems, int currentPage, int pageSize)
		{
			this.TotalItems = totalItems;
			this.CurrentPage = currentPage;
			this.PageSize = pageSize;

			int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);

			TotalPages = totalPages;

			int startPage = currentPage - 5;
			int endPage = currentPage + 4;

			if (startPage <= 0)
			{
				endPage = endPage - (startPage - 1);
				startPage = 1;
			}

			if (endPage > totalPages)
			{
				endPage = totalPages;
				if (endPage > 10)
				{
					startPage = endPage - 9;
				}
			}

			StartRecord = (CurrentPage - 1) * PageSize + 1;

			EndRecord = StartRecord - 1 + PageSize;

			if (EndRecord > TotalItems)
			{
				EndRecord = TotalItems;
			}

			if (TotalItems == 0)
			{
				StartPage = 0;
				StartRecord = 0;
				CurrentPage = 0;
				EndRecord = 0;
			}
			else
			{
				StartPage = startPage;
				EndPage = endPage;
			}
		}
	}
}
