﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Core;

namespace VFT.CMS.Application.Categories.Dto
{
	public class CategoryDto
	{
		public int Id { get; set; }
		[DisplayName("Tên danh mục")]
		public string Name { get; set; }
	}
}
