//using AutoMapper;
//using Microsoft.EntityFrameworkCore;
//using VFT.CMS.Application.Products.Dto;
//using VFT.CMS.Core;
//using VFT.CMS.Repository.Data;

//namespace VFT.CMS.Application.Products
//{
//    public class ProductService : IProductService
//    {
//        private readonly AppDBContext _context;
//        private readonly IMapper _mapper;

//        public ProductService(AppDBContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        public async Task<IEnumerable<ProductDto>> GetAll()
//        {
//            var products = await _context.Products.ToListAsync();
//            var productDto = _mapper.Map<IEnumerable<ProductDto>>(products);
//            return productDto;
//        }

//        public async Task<ProductDto> GetById(int id)
//        {
//            var product = await _context.Products.FindAsync(id);
//            var productDto = _mapper.Map<ProductDto>(product);
//            return productDto;
//        }

//        public async Task Create(ProductDto model)
//        {
//            var product = _mapper.Map<Product>(model);
//            await _context.Products.AddAsync(product);
//            await Save();
//        }

//        public async Task Edit(ProductDto model)
//        {
//            var product = _mapper.Map<Product>(model);
//            _context.Products.Update(product);
//            await Save();
//        }

//        public async Task Delete(ProductDto model)
//        {
//            var product = _mapper.Map<Product>(model);
//            _context.Products.Remove(product);
//            await Save();
//        }

//        public async Task Save()
//        {
//            await _context.SaveChangesAsync();
//        }
//    }
//}
