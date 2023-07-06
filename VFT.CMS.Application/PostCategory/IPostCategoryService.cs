using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.PostCategory.Dto;
using VFT.CMS.Repository.GenericRepository;

namespace VFT.CMS.Application.PostCategory
{
    public interface IPostCategoryService : IGenericRepository<PostCategoryDto>
    {
    }
}
