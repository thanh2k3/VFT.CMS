namespace VFT.CMS.Admin.ViewModels.Products
{
	public class PageViewModel
	{
		public int TotalItems { get; set; }
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
		public int TotalPages { get; set; }
		public int StartPage { get; set; }
		public int EndPage { get; set; }
		public int StartRecord { get; set; }
		public int EndRecord { get; set; }




		public PageViewModel() { }


		public PageViewModel(int totalItems, int page, int pageSize = 5)
		{
			int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
			int currentPage = page;

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


			TotalItems = totalItems;
			CurrentPage = currentPage;
			PageSize = pageSize;
			TotalPages = totalPages;
			StartPage = startPage;
			EndPage = endPage;
		}
	}
}
