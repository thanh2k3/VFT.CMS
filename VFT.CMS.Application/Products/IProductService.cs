using VFT.CMS.Application.Products.Dto;

namespace VFT.CMS.Application.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto> GetById(int id);
        Task Create(ProductDto model);
        Task Edit(ProductDto model);
        Task Delete(ProductDto model);
    }
}