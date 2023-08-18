using Microsoft.AspNetCore.Mvc.Rendering;
using VFT.CMS.Application.Products.Dto;

namespace VFT.CMS.Admin.ViewModels.Products
{
	public class PagedViewModel : PagedProductResultRequestDto
	{
		public PagedViewModel(int input1, int input2, int input3) : base(input1, input2, input3) { }


		public List<SelectListItem> GetPageSize()
		{
			var pageSizes = new List<SelectListItem>();

			for (int i = 5; i <= 50;  i += 5)
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
