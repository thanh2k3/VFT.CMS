using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Application.Users.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        [DisplayName("Họ và tên")]
        public string? FullName { get; set; }
        [DisplayName("Tài khoản")]
        public string UserName { get; set; }
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
