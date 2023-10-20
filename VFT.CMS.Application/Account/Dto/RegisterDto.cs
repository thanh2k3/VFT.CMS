//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace VFT.CMS.Application.Account.Dto
//{
//	public class RegisterDto
//	{
//		[Required]
//		[DisplayName("Tên tài khoản")]
//		public string UserName { get; set; }
//		[Required]
//		[DisplayName("Họ và tên")]
//		public string Name { get; set; }
//		[Required]
//		[EmailAddress]
//		[DisplayName("Gmail")]
//		public string Email { get; set; }
//		[Required]
//		[Compare("Password")]
//		[DisplayName("Mật khẩu")]
//		public string Password { get; set; }
//		[Required]
//		[DisplayName("Nhập lại mật khẩu")]
//		public string PasswordConfirm { get; set; }
//		[DisplayName("Quyền")]
//		public string? Role { get; set; }
//		[DisplayName("Ảnh đại diện")]
//		public string Avatar { get; set; }
//	}
//}
