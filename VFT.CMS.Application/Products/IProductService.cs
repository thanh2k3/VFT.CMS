﻿using Microsoft.AspNetCore.Http;
using VFT.CMS.Application.Categories.Dto;
using VFT.CMS.Application.Products.Dto;

namespace VFT.CMS.Application.Products
{
	public interface IProductService
	{
		Task<IEnumerable<ProductDto>> GetAll();
		Task<ProductDto> GetById(int id);
		Task<bool> Create(CreateProductDto model, IFormFile? image);
		Task<bool> Update(EditProductDto model, IFormFile? image);
		Task<bool> CheckExists(EditProductDto model);
		Task Delete(int id);
	}
}