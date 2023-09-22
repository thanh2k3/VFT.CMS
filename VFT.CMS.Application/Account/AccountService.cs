using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Account.Dto;
using VFT.CMS.Application.Roles.Dto;
using VFT.CMS.Core;
using VFT.CMS.Repository.Data;

namespace VFT.CMS.Application.Account
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly AppDBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IMapper mapper,
            AppDBContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<AccountDto>> GetAll()
        {
            var currentName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var accounts = await _userManager.Users.Where(x => x.UserName != currentName).ToListAsync();
            var accountDto = _mapper.Map<IEnumerable<AccountDto>>(accounts);

            return accountDto;
        }


		public async Task<StatusDto> Login(LoginDto model)
        {
            var status = new StatusDto();
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                status.StatusCode = 0;
                status.Message = "Tên đăng nhập không hợp lệ!";

                return status;
            }
            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                status.StatusCode = 0;
                status.Message = "Mật khẩu không hợp lệ!";

                return status;
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);
            if (signInResult.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                status.StatusCode = 1;
                status.Message = "Đăng nhập thành công!";

                return status;
            }
            else if (signInResult.IsLockedOut)
            {
                status.StatusCode = 0;
                status.Message = "Tài khoản của bạn đã bị khóa";

                return status;
            }
            else
            {
                status.StatusCode = 0;
                status.Message = "Lỗi đăng nhập";

                return status;
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<StatusDto> Register(RegisterDto model)
        {
            var status = new StatusDto();
            var register = _mapper.Map<RegisterDto>(model);
            var userExists = await _userManager.FindByNameAsync(register.UserName);
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "User already exists";

                return status;
            }

            User user = new User
            {
                UserName = register.UserName,
                Email = register.Email,
                FullName = register.Name,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            if(!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "User creation failed";

                return status;
            }

            // role management
            if (!await _roleManager.RoleExistsAsync(register.Role))
            {
                await _roleManager.CreateAsync(new Role(register.Role));
            }
            await _userManager.AddToRoleAsync(user, register.Role);

            status.StatusCode = 1;
            status.Message = "User has registered successfully!";

            return status;
        }
	}
}
