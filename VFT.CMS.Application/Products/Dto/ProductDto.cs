using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VFT.CMS.Core;

namespace VFT.CMS.Application.Products.Dto
{
    public class ProductDto
    {
		public int Id { get; set; }

		public ProductDto()
		{
			categories = new List<Category>();
		}


		[Required(ErrorMessage = "Please enter article title")]
		[DisplayName("Tên sản phẩm")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please enter article content")]
		[DisplayName("Mô tả")]
		public string Description { get; set; }
		public int CategoryId { get; set; }


		//[DisplayName("Giá")]
		//public int Price { get; set; }
		//[DisplayName("Ảnh")]
		//public string Image { get; set; }
		//[DisplayName("Số lượng")]
		//public int Quantity { get; set; }


        public List<Category> categories { get; set; }
    }
}
