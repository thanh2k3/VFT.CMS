﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Core
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }
		public string FullName { get; set; }
		public string StreetAddress { get; set; }
		public string Ward { get; set; }
		public string City { get; set; }
		public string Province { get; set; }
		public string ZipCode { get; set; }
		public string PhoneNumber { get; set; }

		public ICollection<Address> Addresses { get; set; }
		public ICollection<Customer> Customers { get; set; }
	}
}
