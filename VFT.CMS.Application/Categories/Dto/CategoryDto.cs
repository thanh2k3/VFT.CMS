using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.PostCategories.Dto;

namespace VFT.CMS.Application.Categories.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public ICollection<PostCategoryDto> PostCategories { get; set; } = new HashSet<PostCategoryDto>();
    }
}
