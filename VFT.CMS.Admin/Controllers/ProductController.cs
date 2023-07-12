using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VFT.CMS.Admin.Models;
using VFT.CMS.Application.Products;
using VFT.CMS.Core;
using VFT.CMS.Repository.Data;

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
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product model)
        {
            if (ModelState.IsValid)
            {
                await _productService.Create(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Product product = await _productService.GetById(id);

            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
            Product product = await _productService.GetById(id);

            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
		}

        [HttpPost]
        public async Task<IActionResult> Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                await _productService.Edit(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _productService.GetById(id);

            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.Delete(id);
            return RedirectToAction("Index");
        }
	}

}
