using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VFT.CMS.Admin.ViewModels.Roles;
using VFT.CMS.Application.Roles;
using VFT.CMS.Application.Roles.Dto;
using VFT.CMS.Core;
using VFT.CMS.Repository.Data;

namespace VFT.CMS.Admin.Controllers
{
    [Authorize]
    public class RoleController : Controller
	{
		private readonly IRoleService _roleService;
		private readonly IMapper _mapper;
		private readonly AppDBContext _context;

		public RoleController(IRoleService roleService, IMapper mapper, AppDBContext context)
		{
			_roleService = roleService;
			_mapper = mapper;
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult GetRoles()
		{
			try
			{
				var draw = Request.Form["draw"].FirstOrDefault();
				var start = Request.Form["start"].FirstOrDefault();
				var length = Request.Form["length"].FirstOrDefault();
				var searchValue = Request.Form["search[value]"].FirstOrDefault();
				int pageSize = length != null ? Convert.ToInt32(length) : 0;
				int skip = start != null ? Convert.ToInt32(start) : 0;
				int recordsTotal = 0;
				IQueryable<Role> roleData = _context.Roles;
				if (!string.IsNullOrEmpty(searchValue))
				{
					roleData = roleData.Where(m => m.Name.Contains(searchValue));
				}
				recordsTotal = roleData.Count();
				var data = roleData.OrderByDescending(x => x.Id).Skip(skip).Take(pageSize).ToList();
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
				return Ok(jsonData);
            }
			catch (Exception ex)
			{
				throw;
			}
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

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _roleService.Delete(id);

                return Json(new { success = true, message = "Xóa thành công" });
            }
            return Json(new { success = false, message = "Xóa thất bại" });
        }
    }
}
