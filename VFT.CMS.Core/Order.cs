using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Core
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime ShipDate { get; set; }
		public bool Deleted { get; set; }
		public bool Paid { get; set; }
		public DateTime PaymentDate { get; set; }
		public int PaymentId { get; set; }
		public string Note { get; set; }
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
		public int TransactStatusId { get; set; }
		public TransactStatus TransactStatus { get; set; }

		public ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
