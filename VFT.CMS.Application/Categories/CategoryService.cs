using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Categories.Dto;
using VFT.CMS.Application.Products.Dto;
using VFT.CMS.Core;
using VFT.CMS.Repository.Data;

namespace VFT.CMS.Application.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public CategoryService(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var categories = await _context.Categories.ToListAsync();
            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoryDto;
        }

        public Task<CategoryDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Create(CategoryDto model)
        {
            var category = _mapper.Map<Category>(model);
            await _context.Categories.AddAsync(category);
            await Save();
        }

        public Task Delete(CategoryDto model)
        {
            throw new NotImplementedException();
        }

        public Task Edit(CategoryDto model)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
