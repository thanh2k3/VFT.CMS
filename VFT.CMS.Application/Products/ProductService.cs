using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VFT.CMS.Application.Categories.Dto;
using VFT.CMS.Application.Products.Dto;
using VFT.CMS.Core;
using VFT.CMS.Repository.Data;

namespace VFT.CMS.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public ProductService(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await _context.Products.Include(x => x.Category).ToListAsync();
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return productDto;
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task Create(ProductDto model)
        {
            var product = _mapper.Map<Product>(model);

            var newProduct = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Quantity = product.Quantity,
            };

            await _context.Products.AddAsync(newProduct);
            await Save();
        }

        public async Task Update(ProductDto model)
        {
            var product = _mapper.Map<Product>(model);
            _context.Products.Update(product);
            await Save();
        }

        public async Task Delete(ProductDto model)
        {
            var product = _mapper.Map<Product>(model);
            _context.Products.Remove(product);
            await Save();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoryDto;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
	}
}
