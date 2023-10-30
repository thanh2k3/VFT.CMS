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
				var roleUserExists = await _roleManager.RoleExistsAsync("User");

				if (!roleExists)
				{
					await _roleManager.CreateAsync(new Role { Name = "Admin" });
				}

				if (!roleUserExists)
				{
					await _roleManager.CreateAsync(new Role { Name = "User" });
				}

				var admin = "admin@gmail.com";
				var userdefault = "userdefault@gmail.com";

				if (!_context.Users.Any(user => user.UserName == admin))
				{
					User user = new User()
					{
						UserName = admin,
						NormalizedUserName = admin.ToUpper(),
						Email = admin,
						NormalizedEmail = admin.ToUpper(),
						CreatedDate = DateTime.Now,
						FullName = "Admin",
					};

					IdentityResult result = _userManager.CreateAsync(user, "qwer1234QWER!@#$").Result;

					if (result.Succeeded)
					{
						_userManager.AddToRoleAsync(user, "Admin").Wait();
					}
				}

				if (!_context.Users.Any(user => user.UserName == userdefault))
				{
					User user = new User()
					{
						UserName = userdefault,
						NormalizedUserName = userdefault.ToUpper(),
						Email = userdefault,
						NormalizedEmail = userdefault.ToUpper(),
						CreatedDate = DateTime.Now,
						FullName = "User Default",
					};

					IdentityResult result = _userManager.CreateAsync(user, "UserDefault!@#123").Result;

					if (result.Succeeded)
					{
						_userManager.AddToRoleAsync(user, "User").Wait();
					}
				}
			}
		}
	}
}
