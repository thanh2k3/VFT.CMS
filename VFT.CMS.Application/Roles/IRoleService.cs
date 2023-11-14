using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Roles.Dto;

namespace VFT.CMS.Application.Roles
{
	public interface IRoleService
	{
		Task<IEnumerable<RoleDto>> GetAll();
		Task<RoleDto> GetById(int Id);
		Task<bool> Create(RoleDto model);
		Task Update(RoleDto model);
        Task Delete(int id);
    }
}
