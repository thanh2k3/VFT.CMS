using AutoMapper;
using VFT.CMS.Application.Account.Dto;

namespace VFT.CMS.Admin.ViewModels.Account
{
    public class AccountVMMapProfile : Profile
    {
        public AccountVMMapProfile()
        {
            CreateMap<LoginViewModel, LoginDto>();
        }
    }
}
