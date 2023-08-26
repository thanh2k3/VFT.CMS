﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Core.Common;

namespace VFT.CMS.Core
{
	public class Cart
	{
		[Key]
		public int Id { get; set; }
		public int Quantity { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}
