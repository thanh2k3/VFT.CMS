using AutoMapper;
using VFT.CMS.Application.Users.Dto;

namespace VFT.CMS.Admin.ViewModels.Users
{
    public class UserVMMapProfile : Profile
    {
        public UserVMMapProfile()
        {
            CreateMap<UserDto, UserViewModel>();
            CreateMap<CreateUserViewModel, CreateUserDto>();
            CreateMap<UserDto, EditUserViewModel>();
            CreateMap<EditUserViewModel, EditUserDto>();
        }
    }
}
