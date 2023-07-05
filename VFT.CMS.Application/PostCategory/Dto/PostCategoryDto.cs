using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Category.Dto;
using VFT.CMS.Application.Post.Dto;

namespace VFT.CMS.Application.PostCategory.Dto
{
    public class PostCategoryDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int CategoryId { get; set; }
        public PostDto Post { get; set; }
        public CategoryDto Category { get; set; }
    }
}
