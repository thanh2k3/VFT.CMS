using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Core;

namespace VFT.CMS.Application.Products.Dto
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Please enter article title")]
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; }

        [DisplayName("Mô tả")]
        public string? Description { get; set; }

        [DisplayName("Giá")]
        public int? Price { get; set; }

        [DisplayName("Số lượng")]
        public int? Quantity { get; set; }

        [DisplayName("Danh mục")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [DisplayName("Ảnh")]
        public string? Image { get; set; }
    }
}
