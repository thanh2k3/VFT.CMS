using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Core.Common;

namespace VFT.CMS.Core
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[DisplayName("Tên danh mục")]
		[Required]
		public string Name { get; set; }
	}
}
