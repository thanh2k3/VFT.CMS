using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Core
{
	public class Customer
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public DateTime Birthday { get; set; }
		public string Avatar { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public int LocationId { get; set; }
		public int District { get; set; }
		public int Ward { get; set; }
		public DateTime CreatedDate { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
		public DateTime LastLogin { get; set; }
		public bool Active { get; set; }

		public ICollection<Order> Orders { get; set; }
	}
}
