	using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Core.Common;

namespace VFT.CMS.Core
{
	public class Product : BaseEntity
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public int? Price { get; set; }
		public int? Quantity { get; set; }
		//public string Image { get; set; }
		//public int? DiscountId { get; set; }
		//public Discount? Discount { get; set; }
		//public int? InventoryId { get; set; }
		//public Inventory? Inventory { get; set; }

		//public ICollection<Cart> Carts { get; set; }
		//public ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
