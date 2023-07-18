using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Core
{
	public class User : IdentityUser
	{
		public string FullName { get; set; }
		public bool Active { get; set; }
		public DateTime LastLogin { get; set; }
		public DateTime CreateDate { get; set; }
	}
}
