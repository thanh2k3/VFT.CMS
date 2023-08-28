using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Carts.Dto;

namespace VFT.CMS.Application.Carts
{
	public interface ICartService
	{
		Task<IEnumerable<CartDto>> GetAll();
	}
}
