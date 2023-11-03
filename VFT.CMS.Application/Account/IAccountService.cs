using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Account.Dto;
using VFT.CMS.Application.Roles.Dto;

namespace VFT.CMS.Application.Account
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> GetAll();
        //Task<StatusDto> Register(RegisterDto model);
        //Task<StatusDto> Login(LoginDto model);
        Task<bool> Login(LoginDto model);
        Task Logout();
    }
}
