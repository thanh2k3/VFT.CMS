//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using VFT.CMS.Core.Common;

//namespace VFT.CMS.Core
//{
//	public class Order : BaseEntity
//	{
//		[Key]
//		public int Id { get; set; }
//		public DateTime OrderDate { get; set; }
//		public int Total { get; set; }
//		public string Status { get; set; }
//		public int UserId { get; set; }
//		public User User { get; set; }
//		public int CustomerId { get; set; }
//		public Customer Customer { get; set; }

//		public ICollection<OrderDetail> OrderDetails { get; set; }
//		public ICollection<Payment> Payments { get; set; }
//	}
//}
