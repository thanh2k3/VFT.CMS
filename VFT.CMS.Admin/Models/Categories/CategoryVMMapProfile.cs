using AutoMapper;
using VFT.CMS.Application.Categories.Dto;

namespace VFT.CMS.Admin.Models.Categories
{
    public class CategoryVMMapProfile : Profile
    {
        public CategoryVMMapProfile()
        {
            CreateMap<CategoryViewModel, CategoryDto>();
            CreateMap<CategoryDto, CategoryViewModel>();
        }
    }
}
