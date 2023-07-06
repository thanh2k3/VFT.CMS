using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.User.Dto;
using VFT.CMS.Repository.GenericRepository;

namespace VFT.CMS.Application.User
{
    public interface IUserService : IGenericRepository<UserDto>
    {
    }
}
