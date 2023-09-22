using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VFT.CMS.Admin.ViewModels.Roles;
using VFT.CMS.Application.Products.Dto;
using VFT.CMS.Application.Roles;
using VFT.CMS.Application.Roles.Dto;
using VFT.CMS.Repository.Data;

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

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var roleDto = await _roleService.GetAll();
			var roleVM = _mapper.Map<IEnumerable<RoleViewModel>>(roleDto);

			return View(roleVM);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(RoleViewModel model)
		{
			if (ModelState.IsValid)
			{
				var roleDto = _mapper.Map<RoleDto>(model);
				var result = await _roleService.Create(roleDto);

				if (result.StatusCode == 1)
				{
					return RedirectToAction("Index", "Role");
				}
				TempData["msg"] = result.Message;
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int Id)
		{
			var roleDto = await _roleService.GetById(Id);
			var roleVM = _mapper.Map<RoleViewModel>(roleDto);

			if (roleVM != null)
			{
				return View(roleVM);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Edit(RoleViewModel model)
		{
			if (ModelState.IsValid)
			{
				var roleDto = _mapper.Map<RoleDto>(model);
				await _roleService.Update(roleDto);

				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int Id)
		{
			var roleDto = await _roleService.GetById(Id);
			var roleVM = _mapper.Map<RoleViewModel>(roleDto);

			if (roleVM != null)
			{
				return View(roleVM);
			}

			return RedirectToAction("Index");
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int Id)
		{
			await _roleService.Delete(Id);

			return RedirectToAction("Index");
		}
	}
}
