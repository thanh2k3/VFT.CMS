using Microsoft.AspNetCore.Http;
using VFT.CMS.Application.Categories.Dto;
using VFT.CMS.Application.Common.Dto;
using VFT.CMS.Application.Products.Dto;
using VFT.CMS.Core;

namespace VFT.CMS.Application.Products
{
    public interface IProductService
    {
		//Task<IEnumerable<ProductDto>> GetAll(string SearchText="");
		Task<PagedResultRequestDto<ProductDto>> GetAll(string SearchText="", int pg = 1, int pageSize = 5);

		Task<ProductDto> GetById(int id);

		Task Create(CreateProductDto model, IFormFile? image);

		Task Update(EditProductDto model);

        Task Delete(ProductDto model);

		Task<IEnumerable<CategoryDto>> GetAllCategories();

		bool FindProduct(CreateProductDto model);
	}
}