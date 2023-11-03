using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Core;

namespace VFT.CMS.Application.Account.Dto
{
    public class AccountMapProfile : Profile
    {
        public AccountMapProfile()
        {
            CreateMap<User, AccountDto>();
            CreateMap<RegisterDto, User>();
        }
    }
}
