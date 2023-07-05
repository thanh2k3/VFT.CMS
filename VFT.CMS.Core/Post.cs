using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Core
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public int UserId { get; set; }
        public ICollection<PostCategory> PostCategories { get; set; } = new HashSet<PostCategory>();
        public User Author { get; set; }
    }
}
