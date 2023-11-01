using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Web.Mvc;
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
        private readonly IHostingEnvironment _environment;

        public ProductService(AppDBContext context, IMapper mapper, IHostingEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await _context.Products.Include(x => x.Category).ToListAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productsDto;
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _context.Products.Include(x => x.Category)
                                                 .FirstOrDefaultAsync(x => x.Id == id);
            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task<bool> Create(CreateProductDto model, IFormFile? image)
        {
            var product = _mapper.Map<Product>(model);
            var searchProduct = await _context.Products.FirstOrDefaultAsync(x => x.Name == product.Name);
            if (searchProduct == null)
            {
                if (image != null)
                {
                    var imageName = "product_" + Guid.NewGuid().ToString() + "_" + image.FileName;

                    var name = Path.Combine(_environment.WebRootPath + "/image/product", imageName);
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    product.Image = "image/product/" + imageName;
                }
                else
                {
                    product.Image = "image/product/noimage.PNG";
                }

                await _context.Products.AddAsync(product);
                await Save();

                return true;
            }

            return false;
        }

        public async Task Update(EditProductDto model, IFormFile? image)
        {
            //var product = _mapper.Map<Product>(model);
            //var data = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);

            //if (data != null)
            //{
            //    if (image != null)
            //    {
            //        var imageName = "product_" + Guid.NewGuid().ToString() + "_" + image.FileName;

            //        var name = Path.Combine(_environment.WebRootPath + "/image/product", imageName);
            //        await image.CopyToAsync(new FileStream(name, FileMode.Create));
            //        product.Image = "image/product/" + imageName;
            //    }
            //    else
            //    {
            //        //product.Image = "image/user/noimage.png";
            //        product.Image = data.Image;
            //    }

            //    _context.Products.Update(product);
            //    await Save();
            //}

            var product = _mapper.Map<Product>(model);

            if (image != null)
            {
                var imageName = "product_" + Guid.NewGuid().ToString() + "_" + image.FileName;

                var name = Path.Combine(_environment.WebRootPath + "/image/product", imageName);
                await image.CopyToAsync(new FileStream(name, FileMode.Create));
                product.Image = "image/product/" + imageName;
            }
            else
            {
                product.Image = "image/user/noimage.png";
            }

            _context.Products.Update(product);
            await Save();
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            _context.Products.Remove(product);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
