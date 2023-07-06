using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Category.Dto;

namespace VFT.CMS.Application.Category
{
    public class CategoryService : ICategoryService
    {
        public List<CategoryDto> Add(CategoryDto entity)
        {
            throw new NotImplementedException();
        }

        public List<CategoryDto> Delete(CategoryDto entity)
        {
            throw new NotImplementedException();
        }

        public List<CategoryDto> Edit(CategoryDto entity)
        {
            throw new NotImplementedException();
        }

        public List<CategoryDto> GetAll()
        {
            return new List<CategoryDto>
            {
                new CategoryDto { Id = 1, Title = "My Dependency Injection - 1", Description = "Hello World - 1"},
                new CategoryDto { Id = 2, Title = "My Dependency Injection - 2", Description = "Hello World - 2"},
                new CategoryDto { Id = 3, Title = "My Dependency Injection - 3", Description = "Hello World - 3"},
            };
        }
    }
}
