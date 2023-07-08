using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Product.Dto;

namespace VFT.CMS.Application.Product
{
    public class ProductService : IProductService
    {
        private List<ProductDto> _productDto; 

        public ProductService() 
        {
            _productDto = new List<ProductDto>()
            {
                new ProductDto{ Id = 1, Name = "Laptop"},
                new ProductDto{ Id = 2, Name = "TV"},
                new ProductDto{ Id = 3, Name = "Watch"}
            };
        }

        public List<ProductDto> GetAll() 
        {
            return _productDto;
        }

        public void Create(ProductDto productDto)
        {
            _productDto.Add(productDto);
        }

        public async Task<ProductDto> GetById(int id)
        {
            await Task.Delay(1000);
            return _productDto.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<ProductDto> Edit(ProductDto entity)
        {
            throw new NotImplementedException();
        }

        public List<ProductDto> Delete(ProductDto entity)
        {
            throw new NotImplementedException();
        }

        public List<ProductDto> Details(ProductDto entity)
        {
            throw new NotImplementedException();
        }

        public List<ProductDto> Add(ProductDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
