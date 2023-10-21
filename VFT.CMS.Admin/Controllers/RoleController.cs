using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VFT.CMS.Admin.ViewModels.Roles;
using VFT.CMS.Application.Roles;
using VFT.CMS.Application.Roles.Dto;

namespace VFT.CMS.Admin.Controllers
{
	public class RoleController : Controller
	{
		private readonly IRoleService _roleService;
		private readonly IMapper _mapper;

		public RoleController(IRoleService roleService, IMapper mapper)
		{
			_roleService = roleService;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<JsonResult> GetData()
		{
			var roleDto = await _roleService.GetAll();
			var roleVM = _mapper.Map<IEnumerable<RoleViewModel>>(roleDto);

			return Json(roleVM);
		}

		[HttpPost]
		public async Task<JsonResult> Create(RoleViewModel model)
		{
			if (ModelState.IsValid)
			{
				var roleDto = _mapper.Map<RoleDto>(model);
				var role = await _roleService.Create(roleDto);

				if (role)
				{
					return Json(new { success = true, message = "Thêm mới quyền thành công" });
				}

				return Json(new { success = false, message = "Quyền này đã tồn tại" });
            }

            return Json(new { success = false, message = "Thêm mới quyền thất bại" });
        }

		public async Task<ActionResult> Edit(int Id)
		{
			var roleDto = await _roleService.GetById(Id);
			var roleVM = _mapper.Map<RoleViewModel>(roleDto);

			return PartialView("_EditModal", roleVM);
		}

		[HttpPost]
		public async Task<JsonResult> Edit(RoleViewModel model)
		{
			if (ModelState.IsValid)
			{
				var roleDto = _mapper.Map<RoleDto>(model);
				await _roleService.Update(roleDto);

				return Json(new { success = true, message = "Cập nhật dữ liệu thành công" });
            }

            return Json(new { success = false, message = "Cập nhật dữ liệu thất bại" });
        }
	}
}
