using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Core
{
	public class News
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string SContent { get; set; }
		public string Content { get; set; }
		public string Thumbnail { get; set; }
		public int Published { get; set; }
		public string Alias { get; set; }
		public DateTime CreatedDate { get; set; }
		public string Author { get; set; }
		public int UserId { get; set; }
		public string Tags { get; set; }
		public int CategoryId { get; set; }
		public bool IsHot { get; set; }
		public bool IsNewfeed { get; set; }
		public string MetaKey { get; set; }
		public string MetaDesc { get; set; }
		public int Views { get; set; }
	}
}
