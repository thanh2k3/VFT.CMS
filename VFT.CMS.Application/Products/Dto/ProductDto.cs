using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VFT.CMS.Core;

namespace VFT.CMS.Application.Products.Dto
{
	public class ProductDto
	{
		public int Id { get; set; }
		[DisplayName("Tên sản phẩm")]
		public string Name { get; set; }
		[DisplayName("Mô tả")]
		public string? Description { get; set; }
		[DisplayName("Giá")]
		public int Price { get; set; }
		[DisplayName("Tên danh mục")]
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		[DisplayName("Ảnh")]
		public string? Image { get; set; }
	}
}
