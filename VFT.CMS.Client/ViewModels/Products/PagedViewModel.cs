using Microsoft.AspNetCore.Mvc.Rendering;
using VFT.CMS.Application.Products.Dto;

namespace VFT.CMS.Client.ViewModels.Products
{
	public class PagedViewModel : PagedProductResultRequestDto
	{
		public PagedViewModel(int totalItems, int currentPage, int pageSize) : base(totalItems, currentPage, pageSize) { }

		public List<SelectListItem> GetPageSize()
		{
			var pageSizes = new List<SelectListItem>();

			for (int i = 12; i <= 120; i += 12)
			{
				if (i == this.PageSize)
				{
					pageSizes.Add(new SelectListItem(i.ToString(), i.ToString(), true));
				}
				else
				{
					pageSizes.Add(new SelectListItem(i.ToString(), i.ToString()));
				}
			}
			return pageSizes;
		}
	}
}
