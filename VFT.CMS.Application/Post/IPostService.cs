using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Post.Dto;
using VFT.CMS.Repository.GenericRepository;

namespace VFT.CMS.Application.Post
{
    public interface IPostService : IGenericRepository<PostDto>
    {
    }
}
