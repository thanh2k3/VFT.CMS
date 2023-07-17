using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Core
{
	public class TransactStatus
	{
		public int Id { get; set; }
		public string Status { get; set; }
		public string Description { get; set; }

		public ICollection<Order> Orders { get; set; }
	}
}
