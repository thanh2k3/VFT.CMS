using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VFT.CMS.Admin.ViewModels.Users;
using VFT.CMS.Application.Products.Dto;
using VFT.CMS.Application.Users;
using VFT.CMS.Application.Users.Dto;
using VFT.CMS.Core;
using VFT.CMS.Repository.Data;

namespace VFT.CMS.Admin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly AppDBContext _context;

        public UserController(IUserService userService, IMapper mapper, AppDBContext context)
        {
            _userService = userService;
            _mapper = mapper;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetUsers()
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
				IQueryable<User> userData = _context.Users;
				if (!string.IsNullOrEmpty(searchValue))
				{
					userData = userData.Where(m => m.UserName.Contains(searchValue));
				}
				recordsTotal = userData.Count();
				var data = userData.OrderByDescending(x => x.Id).Skip(skip).Take(pageSize).ToList();
				var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                throw;
            }
		}

        [HttpPost]
        public async Task<JsonResult> Create(CreateUserViewModel model, IFormFile? image)
        {
            if (ModelState.IsValid)
            {
                var userDto = _mapper.Map<CreateUserDto>(model);
                var res = await _userService.Create(userDto, image);
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
        public async Task<JsonResult> Edit(EditUserViewModel model, IFormFile? image)
        {
            if (ModelState.IsValid)
            {
                var userDto = _mapper.Map<EditUserDto>(model);
                await _userService.Update(userDto, image);

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
