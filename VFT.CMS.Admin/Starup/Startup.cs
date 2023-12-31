﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VFT.CMS.Admin.ViewModels.Account;
using VFT.CMS.Admin.ViewModels.Categories;
using VFT.CMS.Admin.ViewModels.Products;
using VFT.CMS.Admin.ViewModels.Roles;
using VFT.CMS.Admin.ViewModels.Users;
using VFT.CMS.Application.Account.Dto;
using VFT.CMS.Application.Categories.Dto;
using VFT.CMS.Application.Products.Dto;
using VFT.CMS.Application.Roles.Dto;
using VFT.CMS.Application.Users.Dto;
using VFT.CMS.Core;
using VFT.CMS.Repository.Data;
using VFT.CMS.Repository.Seed;

namespace VFT.CMS.Admin.Starup
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("MyDatabase");
            services.AddDbContext<AppDBContext>(c => c.UseSqlServer(connectionString));

            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<AppDBContext>()
                    .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                // Xóa cookie
                //options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
                options.Cookie.MaxAge = TimeSpan.FromHours(1);
                // Không xóa cookie
                //options.ExpireTimeSpan = TimeSpan.FromSeconds(30);
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddAutoMapper(typeof(ProductMapProfile).Assembly);
            services.AddAutoMapper(typeof(ProductVMMapProfile).Assembly);

            services.AddAutoMapper(typeof(CategoryMapProfile).Assembly);
            services.AddAutoMapper(typeof(CategoryVMMapProfile).Assembly);

            services.AddAutoMapper(typeof(AccountMapProfile).Assembly);
            services.AddAutoMapper(typeof(AccountVMMapProfile).Assembly);

            services.AddAutoMapper(typeof(RoleMapProfile).Assembly);
            services.AddAutoMapper(typeof(RoleVMMapProfile).Assembly);

            services.AddAutoMapper(typeof(UserMapProfile).Assembly);
            services.AddAutoMapper(typeof(UserVMMapProfile).Assembly);

            services.AddScoped();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Data Seeding
                SeedData.InitializeAsync(app);
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
