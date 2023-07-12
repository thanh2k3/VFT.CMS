using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.PostCategories.Dto;
using VFT.CMS.Application.Users.Dto;

namespace VFT.CMS.Application.Posts.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public int UserId { get; set; }
        public ICollection<PostCategoryDto> PostCategories { get; set; } = new HashSet<PostCategoryDto>();
        public UserDto Author { get; set; }
    }
}
