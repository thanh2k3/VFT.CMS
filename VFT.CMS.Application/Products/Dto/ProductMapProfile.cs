using AutoMapper;
using VFT.CMS.Core;

namespace VFT.CMS.Application.Products.Dto
{
	public class ProductMapProfile : Profile
	{
		public ProductMapProfile()
		{
			CreateMap<Product, ProductDto>();
			CreateMap<ProductDto, Product>();
		}
	}
}
