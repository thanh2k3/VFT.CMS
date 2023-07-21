using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Application.Categories.Dto
{
	public class CategoryDto
	{
		public int Id { get; set; }
		[DisplayName("Tên danh mục")]
		public string Name { get; set; }
		[DisplayName("Mô tả")]
		public string Description { get; set; }
	}
}
