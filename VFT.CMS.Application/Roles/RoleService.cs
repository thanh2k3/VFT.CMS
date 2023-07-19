using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Products.Dto;
using VFT.CMS.Application.Roles.Dto;
using VFT.CMS.Core;
using VFT.CMS.Repository.Data;

namespace VFT.CMS.Application.Roles
{
	public class RoleService : IRoleService
	{
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;


		public RoleService(AppDBContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

        public async Task<IEnumerable<RoleDto>> GetAll()
        {
			var roles = await _context.Roles.ToListAsync(); 
			var roleDto = _mapper.Map<IEnumerable<RoleDto>>(roles);
			return roleDto;
        }

        public async Task<RoleDto> GetById(string id)
        {
			var role = await _context.Roles.FindAsync(id);
			var roleDto = _mapper.Map<RoleDto>(role);
			return roleDto;
        }

		public async Task Create(RoleDto model)
		{
			var roleDto = _mapper.Map<Role>(model);
			await _context.Roles.AddAsync(roleDto);
			await Save();
		}

        public async Task Edit(RoleDto model)
        {
			var role = _mapper.Map<Role>(model);
			_context.Roles.Update(role);
			await Save();
        }

		public Task Delete(RoleDto model)
		{
			throw new NotImplementedException();
		}

		public async Task Save()
		{
			await _context.SaveChangesAsync();
		}
	}
}
