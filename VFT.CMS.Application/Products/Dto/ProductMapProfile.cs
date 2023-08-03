using AutoMapper;
using VFT.CMS.Core;

namespace VFT.CMS.Application.Products.Dto
{
	public class ProductMapProfile : Profile
	{
		public ProductMapProfile()
		{
			CreateMap<Product, ProductDto>().ReverseMap();

			CreateMap<Product, CreateProductDto>().ReverseMap();

			CreateMap<Product, EditProductDto>().ReverseMap();

		}
    }
}
