using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Common.Dto;
using VFT.CMS.Application.Products.Dto;
using VFT.CMS.Application.Roles.Dto;
using VFT.CMS.Core;
using VFT.CMS.Repository.Data;

namespace VFT.CMS.Application.Roles
{
	public class RoleService : IRoleService
	{
		private readonly AppDBContext _context;
		private readonly RoleManager<Role> _roleManager;
		private readonly IMapper _mapper;

		public RoleService(AppDBContext context, IMapper mapper, RoleManager<Role> roleManager)
		{
			_context = context;
			_roleManager = roleManager;
			_mapper = mapper;
		}

		public async Task<IEnumerable<RoleDto>> GetAll()
		{
			var roles = await _roleManager.Roles.ToListAsync();
			var roleDto = _mapper.Map<IEnumerable<RoleDto>>(roles);
			return roleDto;
		}
		public async Task<StatusDto> Create(RoleDto model)
		{
			var status = new StatusDto();
			var data = _mapper.Map<Role>(model);
			var roleExists = await _roleManager.RoleExistsAsync(data.Name);
			if (roleExists)
			{
				status.StatusCode = 0;
				status.Message = "Quyền đã tồn tại!";

				return status;
			}

			Role role = new Role
			{
				Name = data.Name
			};

			var result = await _roleManager.CreateAsync(role);
			if (result.Succeeded)
			{
				status.StatusCode = 1;
				status.Message = "Tạo quyền thành công";

				return status;
			}

			status.StatusCode = 0;
			status.Message = "Lỗi!";

			return status;
		}

		public async Task<RoleDto> GetById(int Id)
		{
			var role = await _roleManager.Roles.Where(x => x.Id == Id).FirstOrDefaultAsync();
			var roleDto = _mapper.Map<RoleDto>(role);

			return roleDto;
		}

		public async Task Delete(int Id)
		{
			var role = await _roleManager.Roles.Where(x => x.Id == Id).FirstOrDefaultAsync();
			await _roleManager.DeleteAsync(role);
		}

		public async Task Update(RoleDto model)
		{
			var data = _mapper.Map<Role>(model);
			var role = await _roleManager.Roles.Where(x => x.Id == data.Id && x.Name != data.Name).FirstOrDefaultAsync();
			if (role != null)
			{
				role.Name = data.Name;
				await _roleManager.UpdateAsync(role);
			}
		}
	}
}
