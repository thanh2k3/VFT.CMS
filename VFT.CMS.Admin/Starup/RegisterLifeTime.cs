using VFT.CMS.Application.Account;
using VFT.CMS.Application.Categories;
using VFT.CMS.Application.Products;

namespace VFT.CMS.Admin.Starup
{
    public static class RegisterLifeTime
    {
        public static void AddScoped(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}
