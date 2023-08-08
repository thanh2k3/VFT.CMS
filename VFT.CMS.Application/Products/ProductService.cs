﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IO;
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
			var productDto = _mapper.Map<IEnumerable<ProductDto>>(products);
			return productDto;
		}

		public async Task<ProductDto> GetById(int id)
		{
			var product = await _context.Products.Include(x => x.Category)
												 .FirstOrDefaultAsync(x => x.Id == id);
			var productDto = _mapper.Map<ProductDto>(product);
			return productDto;
		}

		public async Task Create(CreateProductDto model, IFormFile? image)
		{
			var product = _mapper.Map<Product>(model);

			if (image != null)
			{
				var name = Path.Combine(_environment.WebRootPath + "/images/product", Path.GetFileName(image.FileName));
				await image.CopyToAsync(new FileStream(name, FileMode.Create));
				product.Image = "images/product/" + image.FileName;
			}
			if (image == null)
			{
				product.Image = "images/product/noimage.PNG";
			}

			var data = new Product()
			{
				Name = product.Name,
				Description = product.Description,
				CategoryId = product.CategoryId,
				Price = product.Price,
				Quantity = product.Quantity,
				Image = product.Image,
			};

			await _context.Products.AddAsync(data);
			await Save();
		}

		public async Task Update(EditProductDto model, IFormFile? image)
		{
			var product = _mapper.Map<Product>(model);

			if (image != null)
			{
				var name = Path.Combine(_environment.WebRootPath + "/images/product", Path.GetFileName(image.FileName));
				await image.CopyToAsync(new FileStream(name, FileMode.Create));
				product.Image = "images/product/" + image.FileName;
			}
			if(image == null)
			{
				product.Image = "images/product/noimage.PNG";
			}

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

		// Check sản phẩm đã tồn tại hay chưa
		public bool FindProduct(CreateProductDto model)
		{
			var product = _mapper.Map<Product>(model);
			var searchProduct = _context.Products.FirstOrDefault(x => x.Name == product.Name);
			if (searchProduct != null)
			{
				return true;
			}
			return false;
		}

		public async Task Save()
		{
			await _context.SaveChangesAsync();
		}
	}
}
