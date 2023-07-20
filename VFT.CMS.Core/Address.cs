using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Core.Common;

namespace VFT.CMS.Core
{
	public class Address
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string StreetAddress { get; set; }
		public string Ward { get; set; }
		public string City { get; set; }
		public string Province { get; set; }
		public string ZipCode { get; set; }
		public string PhoneNumber { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
	}
}
