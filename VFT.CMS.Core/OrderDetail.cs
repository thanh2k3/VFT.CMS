using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Core
{
	public class OrderDetail
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int OrderNumber { get; set; }
		public int Quantity { get; set; }
		public int Discount { get; set; }
		public int Total { get; set; }
		public DateTime ShipDate { get; set; }
	}
}
