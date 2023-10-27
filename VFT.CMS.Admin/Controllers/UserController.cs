using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web.Helpers;
using VFT.CMS.Admin.ViewModels.Users;
using VFT.CMS.Application.Users;
using VFT.CMS.Application.Users.Dto;
using VFT.CMS.Core;

namespace VFT.CMS.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetData()
        {
            var usersDto = await _userService.GetAll();
            var usersVM = _mapper.Map<IEnumerable<UserViewModel>>(usersDto);

            return Json(usersVM);
        }

        [HttpPost]
        public async Task<JsonResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDto = _mapper.Map<CreateUserDto>(model);
                var res = await _userService.Create(userDto);
                if (res)
                {
                    return Json(new { success = true, message = "Thêm mới người dùng thành công" });
                }

                return Json(new { success = false, message = "Tài khoản đã tồn tại" });
            }

            return Json(new { success = false, message = "Thêm mới người dùng thất bại" });
        }

        public async Task<ActionResult> Edit(int id)
        {
            var userDto = await _userService.GetById(id);
            var userVM = _mapper.Map<EditUserViewModel>(userDto);

            return PartialView("_EditModal", userVM);
        }

        [HttpPost]
        public async Task<JsonResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDto = _mapper.Map<EditUserDto>(model);
                await _userService.Update(userDto);

                return Json(new { success = true, message = "Cập nhật người dùng thành công" });

            }
            return Json(new { success = false, message = "Cập nhật người dùng thất bại" });
        }

        public async Task<ActionResult> ViewModal(int id)
        {
			var userDto = await _userService.GetById(id);
			var userVM = _mapper.Map<UserViewModel>(userDto);

			return PartialView("_ViewModal", userVM);
		}

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _userService.Delete(id);

                return Json(new { success = true, message = "Xóa thành công" });
            }
            return Json(new { success = false, message = "Xóa thất bại" });
        }
    }
}
