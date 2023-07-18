using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Core
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int ParentId { get; set; }
		public int Levels { get; set; }
		public int Ordering { get; set; }
		public DateTime Published { get; set; }
		public string Thumbnail { get; set; }
		public string Title { get; set; }
		public string Alias { get; set; }
		public string MetaDesc { get; set; }
		public string MetaKey { get; set; }
		public string Cover { get; set; }
		public string SchemaMarkup { get; set; }

		public ICollection<Product> Products { get; set; }
	}
}
