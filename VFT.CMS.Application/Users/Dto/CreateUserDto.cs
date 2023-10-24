using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Application.Users.Dto
{
	public class CreateUserDto
	{
		[DisplayName("Tên đăng nhập")]
		public string UserName { get; set; }
		[DisplayName("Mật khẩu")]
		public string Password { get; set; }
        [DisplayName("Xác minh mật khẩu")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [DisplayName("Họ và tên")]
		public string? FullName { get; set; }
		[DisplayName("Ảnh đại diện")]
		public string? Avatar { get; set; }
		[DisplayName("Email")]
		public string Email { get; set; }
		[DisplayName("Ngày sinh")]
		public DateTime? Birthday { get; set; }
		[DisplayName("Ngày tạo")]
		public DateTime CreatedDate { get; set; }
		[DisplayName("Ngày sửa đổi")]
		public DateTime? ModifiedDate { get; set; }
	}
}
