using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VFT.CMS.Application.Products;
using VFT.CMS.Application.Roles;
using VFT.CMS.Repository.Data;

namespace VFT.CMS.Admin.Starup
{
    public static class RegisterLifeTime
    {
        public static void AddScoped(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRoleService, RoleService>();
        }
    }
}
