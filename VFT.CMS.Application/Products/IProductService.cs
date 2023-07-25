using VFT.CMS.Application.Categories.Dto;
using VFT.CMS.Application.Products.Dto;
using VFT.CMS.Core;

namespace VFT.CMS.Application.Products
{
    public interface IProductService
    {
		Task<IEnumerable<ProductDto>> GetAll();

		Task<ProductDto> GetById(int id);

		Task Create(ProductDto model);

        Task Update(ProductDto model);
        //Task Edit(ProductDto model);

        Task Delete(ProductDto model);

		Task<IEnumerable<CategoryDto>> GetAllCategories();
	}
}