using Microsoft.EntityFrameworkCore;
using System;
//using VFT.CMS.Application.Carts.Dto;
//using VFT.CMS.Application.Products.Dto;
//using VFT.CMS.Client.ViewModels.Products;
using VFT.CMS.Repository.Data;

namespace VFT.CMS.Client.Startup
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
			services.AddControllersWithViews().AddRazorRuntimeCompilation();

			string connectionString = Configuration.GetConnectionString("MyDatabase");
			services.AddDbContext<AppDBContext>(c => c.UseSqlServer(connectionString));

			//services.AddAutoMapper(typeof(ProductMapProfile).Assembly);
			//services.AddAutoMapper(typeof(ProductVMMapProfile).Assembly);
			//services.AddAutoMapper(typeof(CartMapProfile).Assembly);

			//services.AddScoped();

			services.AddDistributedMemoryCache();

			services.AddSession(options =>
			{
				//options.Cookie.Name = "MySession";
				options.IdleTimeout = TimeSpan.FromMinutes(30);
				options.Cookie.IsEssential = true;
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
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

			app.UseAuthorization();

			app.UseSession();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
