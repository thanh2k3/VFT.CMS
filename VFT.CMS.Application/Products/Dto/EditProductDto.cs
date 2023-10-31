using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Core;
using Microsoft.AspNetCore.Http;

namespace VFT.CMS.Application.Products.Dto
{
	public class EditProductDto
	{
		public int Id { get; set; }
		[DisplayName("Tên sản phẩm")]
		public string Name { get; set; }
		[DisplayName("Mô tả")]
		public string? Description { get; set; }
		[DisplayName("Giá")]
		public int Price { get; set; }
		[DisplayName("Danh mục")]
		public int CategoryId { get; set; }
		[DisplayName("Ảnh")]
		public string? Image { get; set; }
	}
}
