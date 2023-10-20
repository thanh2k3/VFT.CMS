//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using VFT.CMS.Core;

//namespace VFT.CMS.Repository.Seed
//{
//    public static class SeedData
//    {
//        public static async Task InitializeAsync(IServiceProvider serviceProvider)
//        {
//            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
//            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

//            //string[] roleNames = { "Admin", "User" };

//            //IdentityResult roleResult;

//            //foreach (var role in roleNames)
//            //{
//            //    var roleExists = await roleManager.RoleExistsAsync(role);

//            //    if (!roleExists)
//            //    {
//            //        roleResult = await roleManager.CreateAsync(new Role(role));
//            //    }
//            //}


//            IdentityResult roleResult;

//            var roleExists = await roleManager.RoleExistsAsync("Admin");

//            if (!roleExists)
//            {
//                roleResult = await roleManager.CreateAsync(new Role("Admin"));
//            }

//            var email = "admin@gmail.com";

//            if (userManager.FindByEmailAsync(email).Result == null)
//            {
//                User user = new()
//                {
//                    UserName = email,
//                    NormalizedUserName = email.ToUpper(),
//                    Email = email,
//                    NormalizedEmail = email.ToUpper(),
//                };

//                IdentityResult result = userManager.CreateAsync(user, "qwer1234QWER!@#$").Result;

//                if (result.Succeeded)
//                {
//                    userManager.AddToRoleAsync(user, "Admin").Wait();
//                }
//            }
//        }
//    }
//}
