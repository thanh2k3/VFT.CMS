using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Carts.Dto;
using VFT.CMS.Repository.Data;

namespace VFT.CMS.Application.Carts
{
	public class CartService : ICartService
	{
		public readonly AppDBContext _context;
		public readonly IMapper _mapper;

		public CartService(AppDBContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}


		public async Task<IEnumerable<CartDto>> GetAll()
		{
			var cart = await _context.Carts.Include(x => x.Product).ToListAsync();
			var cartDto = _mapper.Map<IEnumerable<CartDto>>(cart);
			return cartDto;
		}
	}
}
