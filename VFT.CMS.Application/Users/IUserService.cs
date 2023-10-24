using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Users.Dto;

namespace VFT.CMS.Application.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<bool> Create(CreateUserDto model);
        Task<UserDto> GetById(int id);
        Task Update(EditUserDto model);
        Task Delete(int id);
    }
}
