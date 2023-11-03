using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VFT.CMS.Admin.ViewModels.Account;
using VFT.CMS.Application.Account;
using VFT.CMS.Application.Account.Dto;
using VFT.CMS.Core;
using VFT.CMS.Repository.Data;

namespace VFT.CMS.Admin.Controllers
{

    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper, RoleManager<Role> roleManager)
        {
            _accountService = accountService;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.allRoles = new SelectList(await _roleManager.Roles.ToListAsync(), "Id", "Name");
            var accountDto = await _accountService.GetAll();
            var accountVM = _mapper.Map<IEnumerable<AccountViewModel>>(accountDto);

            return View(accountVM);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

		[HttpPost]
		public async Task<ActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var loginDto = _mapper.Map<LoginDto>(model);
				var result = await _accountService.Login(loginDto);
				if (result)
				{
                    return RedirectToAction("Index", "Home");
				}

                return RedirectToAction("Login", "Account");
            }

            return RedirectToAction("Login", "Account");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();

            return RedirectToAction(nameof(Login));
        }
    }
}
