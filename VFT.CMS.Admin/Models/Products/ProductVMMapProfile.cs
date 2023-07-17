using AutoMapper;
using VFT.CMS.Application.Products.Dto;
using VFT.CMS.Core;

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
