using VFT.CMS.Application.Products;

namespace VFT.CMS.Client.Startup
{
	public static class RegisterLifeTime
	{
		public static void AddScoped(this IServiceCollection services)
		{
			services.AddScoped<IProductService, ProductService>();
		}
	}
}