using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Core;

namespace VFT.CMS.Application.Carts.Dto
{
	public class CartDto
	{
		public int Quantity { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}
