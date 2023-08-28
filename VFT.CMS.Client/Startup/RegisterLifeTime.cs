using VFT.CMS.Application.Carts;
using VFT.CMS.Application.Products;
//using VFT.CMS.Application.Sessions;

namespace VFT.CMS.Client.Startup
{
	public static class RegisterLifeTime
	{
		public static void AddScoped(this IServiceCollection services)
		{
			services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();
        }
	}
}
