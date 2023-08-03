using AutoMapper;
using VFT.CMS.Application.Categories.Dto;

namespace VFT.CMS.Admin.ViewModels.Categories
{
	public class CategoryVMMapProfile : Profile
	{
		public CategoryVMMapProfile()
		{
			CreateMap<CategoryDto, CategoryViewModel>().ReverseMap();
		}
	}
}
