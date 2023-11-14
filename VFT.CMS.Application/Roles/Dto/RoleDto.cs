using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Application.Roles.Dto
{
	public class RoleDto
	{
		public int Id { get; set; }
		[DisplayName("Tên quyền")]
		public string Name { get; set; }
        [DisplayName("Mô tả")]
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
