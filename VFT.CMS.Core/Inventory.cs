using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Core.Common;

namespace VFT.CMS.Core
{
	public class Inventory : BaseEntity
	{
		public int Quantity { get; set; }

		public ICollection<Product> Products { get; set; }
	}
}
