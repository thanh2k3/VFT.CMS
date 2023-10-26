using AutoMapper;
using VFT.CMS.Application.Roles.Dto;

namespace VFT.CMS.Admin.ViewModels.Roles
{
	public class RoleVMMapProfile : Profile
	{
		public RoleVMMapProfile()
		{
			CreateMap<RoleDto, RoleViewModel>().ReverseMap();
		}
	}
}
