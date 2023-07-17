using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Core
{
	public class AttributesPrice
	{
		public int Id { get; set; }
		public int Price { get; set; }
		public bool Active { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public int AttributeId { get; set; }
		public Attributes Attributes { get; set; }
	}
}
