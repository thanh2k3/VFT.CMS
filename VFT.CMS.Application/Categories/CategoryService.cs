using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        public async Task Create(CategoryDto model)
        {
            var category = _mapper.Map<Category>(model);
            await _context.Categories.AddAsync(category);
            await Save();
        }

        public async Task Update(CategoryDto model)
        {
            var category = _mapper.Map<Category>(model);
            _context.Categories.Update(category);
			await Save();
        }

        public async Task Delete(CategoryDto model)
        {
            var category = _mapper.Map<Category>(model);
            _context.Categories.Remove(category);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
