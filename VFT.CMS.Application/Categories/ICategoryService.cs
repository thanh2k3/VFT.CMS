using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Categories.Dto;

namespace VFT.CMS.Application.Categories
{
	public interface ICategoryService
	{
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(int id);
        Task<bool> Create(CategoryDto model);
        Task Update(CategoryDto model);
        Task Delete(int id);
    }
}
