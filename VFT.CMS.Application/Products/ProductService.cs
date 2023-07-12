using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Products.Dto;
using VFT.CMS.Core;
using VFT.CMS.Repository.Data;

namespace VFT.CMS.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly AppDBContext _context;

        public ProductService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task Create(Product model)
        {
            await _context.Products.AddAsync(model);
            await Save();
        }

        public async Task Edit(Product model)
        {
            var product = await _context.Products.FindAsync(model.Id);
            if (product != null)
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                _context.Update(product);
                await Save();
            }
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await Save();
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
