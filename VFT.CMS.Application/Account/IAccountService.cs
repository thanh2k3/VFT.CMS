using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Account.Dto;

namespace VFT.CMS.Application.Account
{
    public interface IAccountService
    {
        Task<StatusDto> Login(LoginDto model);
        Task Logout();
    }
}
