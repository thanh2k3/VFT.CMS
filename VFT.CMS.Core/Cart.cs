using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Core.Common;

namespace VFT.CMS.Core
{
	public class Cart : BaseEntity
	{
		public int Quantity { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}
