using VFT.CMS.Application.Product.Dto;
using VFT.CMS.Repository.GenericRepository;

namespace VFT.CMS.Application.Product
{
    public interface IProductService : IGenericRepository<ProductDto>
    {
        void Create(ProductDto productDto);
    }
}