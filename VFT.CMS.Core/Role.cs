﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Core
{
	public class Role : IdentityRole
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}