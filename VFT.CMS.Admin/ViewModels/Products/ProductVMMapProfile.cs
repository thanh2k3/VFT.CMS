using AutoMapper;
using VFT.CMS.Application.Products.Dto;

namespace VFT.CMS.Admin.ViewModels.Products
{
	public class ProductVMMapProfile : Profile
	{
		public ProductVMMapProfile()
		{
			CreateMap<ProductViewModel, ProductDto>().ReverseMap();

			CreateMap<CreateProductViewModel, CreateProductDto>().ReverseMap();

			CreateMap<EditProductDto, EditProductViewModel>().ReverseMap();
        }
    }
}
