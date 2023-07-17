using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Core
{
	public class Page
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Content { get; set; }
		public string Thumbnail { get; set; }
		public bool Published { get; set; }
		public string Title { get; set; }
		public string MetaDesc { get; set; }
		public string MetaKey { get; set; }
		public string Alias { get; set; }
		public DateTime CreateDate { get; set; }
		public int Ordering { get; set; }
	}
}
