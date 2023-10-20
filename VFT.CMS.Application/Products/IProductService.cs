using Microsoft.AspNetCore.Http;
using VFT.CMS.Application.Categories.Dto;
using VFT.CMS.Application.Products.Dto;

namespace VFT.CMS.Application.Products
{
	public interface IProductService
	{
		Task<IEnumerable<ProductDto>> GetAll();
		Task<ProductDto> GetById(int id);
		Task<bool> Create(CreateProductDto model);
		//Task Update(EditProductDto model);
		Task<bool> Update(EditProductDto model);
		Task Delete(int id);





		//Task<PagedResultRequestDto<ProductDto>> GetAll(string searchText, int pg, int pageSize);

		//Task<ProductDto> GetById(int id);

		//Task Create(CreateProductDto model, IFormFile? image);

		//Task Update(EditProductDto model);

		//Task Delete(ProductDto model);

		//Task<IEnumerable<CategoryDto>> GetAllCategories();

		//bool FindProduct(CreateProductDto model);
	}
}