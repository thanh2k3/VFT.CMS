	using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Core.Common;

namespace VFT.CMS.Core
{
	public class Product
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public string? Description { get; set; }

		[Required]
		[ForeignKey("Category")]
		public int CategoryId { get; set; }
		public Category Category { get; set; }

        public int? Price { get; set; }

		public int? Quantity { get; set; }

		public string? Image { get; set; }
	}
}
