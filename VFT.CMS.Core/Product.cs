using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Core
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ShortDesc { get; set; }
		public string Description { get; set; }
		public int Price { get; set; }
		public int Discount { get; set; }
		public string Thumbnail { get; set; }
		public string Video { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public bool BestSellers { get; set; }
		public bool HomeFlag { get; set; }
		public bool Active { get; set; }
		public string Tags { get; set; }
		public string Title { get; set; }
		public string Alias { get; set; }
		public string MetaDesc { get; set; }
		public string MetaKey { get; set; }
		public int UnitsInStock { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }

		public ICollection<AttributesPrice> AttributesPrices { get; set; }
	}
}
