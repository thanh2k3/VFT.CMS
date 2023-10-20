using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using VFT.CMS.Core;
using VFT.CMS.Repository.Data;

namespace VFT.CMS.Repository.Seed
{
    public static class SeedData
    {
		public static async Task InitializeAsync(IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.CreateScope())
			{
				var _context = serviceScope.ServiceProvider.GetRequiredService<AppDBContext>();
				var _roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
				var _userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();

				var roleExists = await _roleManager.RoleExistsAsync("Admin");

				if (!roleExists)
				{
					await _roleManager.CreateAsync(new Role { Name = "Admin" });
				}

				var userName = "admin@gmail.com";

				if (!_context.Users.Any(user => user.UserName == userName))
				{
					User user = new User()
					{
						UserName = userName,
						NormalizedUserName = userName.ToUpper(),
						Email = userName,
						NormalizedEmail = userName.ToUpper(),
					};

					IdentityResult result = _userManager.CreateAsync(user, "qwer1234QWER!@#$").Result;

					if (result.Succeeded)
					{
						_userManager.AddToRoleAsync(user, "Admin").Wait();
					}
				}
			}
		}
	}
}
