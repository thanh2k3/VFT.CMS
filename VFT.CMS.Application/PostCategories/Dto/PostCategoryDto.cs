using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Categories.Dto;
using VFT.CMS.Application.Posts.Dto;

namespace VFT.CMS.Application.PostCategories.Dto
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
