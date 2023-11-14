using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Roles.Dto;
using VFT.CMS.Core;

namespace VFT.CMS.Application.Roles
{
	public class RoleService : IRoleService
	{
		private readonly RoleManager<Role> _roleManager;
		private readonly IMapper _mapper;

		public RoleService(IMapper mapper, RoleManager<Role> roleManager)
		{
			_roleManager = roleManager;
			_mapper = mapper;
		}

		public async Task<IEnumerable<RoleDto>> GetAll()
		{
			var roles = await _roleManager.Roles.ToListAsync();
			var roleDto = _mapper.Map<IEnumerable<RoleDto>>(roles);

			return roleDto;
		}

		public async Task<bool> Create(RoleDto model)
		{
			var role = _mapper.Map<Role>(model);
			var roleExists = await _roleManager.RoleExistsAsync(model.Name);
			if (!roleExists)
			{
				Role data = new Role
				{
					Name = role.Name,
					Description = role.Description,
					CreatedDate = DateTime.Now,
				};
				await _roleManager.CreateAsync(data);

				return true;
			}

			return false;
		}

		public async Task<RoleDto> GetById(int Id)
		{
			var role = await _roleManager.FindByIdAsync(Id.ToString());
			var roleDto = _mapper.Map<RoleDto>(role);

			return roleDto;
		}

        public async Task Update(RoleDto model)
        {
            var data = _mapper.Map<Role>(model);
			var role = await _roleManager.FindByIdAsync(model.Id.ToString());
			if (role != null)
			{
				role.Name = data.Name;
				role.Description = data.Description;
				role.ModifiedDate = DateTime.Now;

				await _roleManager.UpdateAsync(role);
			}
        }

        public async Task Delete(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            await _roleManager.DeleteAsync(role);
        }
    }
}
