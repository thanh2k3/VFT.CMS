using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VFT.CMS.Application.Products.Dto;
using VFT.CMS.Application.Roles;
using VFT.CMS.Application.Roles.Dto;
using VFT.CMS.Repository.Data;

namespace VFT.CMS.Admin.Controllers
{
	public class RoleController : Controller
	{
		private readonly IRoleService _roleService;

		public RoleController(IRoleService roleService)
		{
			_roleService = roleService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var roleDto = await _roleService.GetAll();
			return View(roleDto);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(RoleDto model)
		{
			if (ModelState.IsValid)
			{
				await _roleService.Create(model);
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Detail(string id)
		{
			RoleDto roleDto = await _roleService.GetById(id);

			if (roleDto != null)
			{
				return View(roleDto);
			}
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
			RoleDto roleDto = await _roleService.GetById(id);

			if (roleDto != null)
			{
				return View(roleDto);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Edit(RoleDto model)
		{
			if (ModelState.IsValid)
			{
				await _roleService.Edit(model);
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
