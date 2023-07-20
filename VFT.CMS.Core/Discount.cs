using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Core.Common;

namespace VFT.CMS.Core
{
	public class Discount : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int DiscountPercent { get; set; }
		public bool Active { get; set; }

		public ICollection<Product> Products { get; set; }
	}
}
