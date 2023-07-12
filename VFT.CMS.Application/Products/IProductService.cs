using VFT.CMS.Application.Products.Dto;
using VFT.CMS.Core;

namespace VFT.CMS.Application.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task Create(Product model);
        Task Edit(Product model);
        Task Delete(int id);
    }
}