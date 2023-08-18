using Microsoft.AspNetCore.Mvc;
using VFT.CMS.Application.Products;
using VFT.CMS.Repository.Data;

namespace VFT.CMS.Client.Controllers
{
	public class ProductController : Controller
	{
		public readonly AppDBContext _context;

		public ProductController(AppDBContext context)
		{
			_context = context;
		}


		public IActionResult Index()
		{
			return View(_context.Products.ToList());
		}
	}
}
