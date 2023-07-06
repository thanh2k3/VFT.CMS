using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Category.Dto;
using VFT.CMS.Repository.GenericRepository;

namespace VFT.CMS.Application.Category
{
    public interface ICategoryService : IGenericRepository<CategoryDto>
    {
    }
}
