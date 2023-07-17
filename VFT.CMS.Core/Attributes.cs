using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.CMS.Core
{
	public class Attributes
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<AttributesPrice> AttributesPrices { get; set; }
	}
}
