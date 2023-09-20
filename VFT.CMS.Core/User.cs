using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Core
{
	public class User : IdentityUser<int>
	{
		public string? FullName { get; set; }
		public string? Avatar { get; set; }
		public DateTime? Birthday { get; set; }
		public bool Active { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }

	}
}
