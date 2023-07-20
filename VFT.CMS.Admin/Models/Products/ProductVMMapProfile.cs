using AutoMapper;
using VFT.CMS.Application.Products.Dto;

namespace VFT.CMS.Admin.Models.Products
{
    public class ProductVMMapProfile : Profile
    {
        public ProductVMMapProfile()
        {
            CreateMap<ProductViewModel, ProductDto>().ReverseMap();
        }
    }
}
