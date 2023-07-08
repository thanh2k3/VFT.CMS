using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VFT.CMS.Application.Product;
using VFT.CMS.Application.Product.Dto;
using VFT.CMS.Core;

namespace VFT.CMS.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_productService.GetAll());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            return View(_productService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            _productService.Create(productDto);
            return View();
        }
    }
}
