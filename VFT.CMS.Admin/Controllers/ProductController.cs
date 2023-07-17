using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VFT.CMS.Admin.Models.Products;
using VFT.CMS.Application.Products;
using VFT.CMS.Application.Products.Dto;

namespace VFT.CMS.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productDto = await _productService.GetAll();
            var productVM = _mapper.Map<IEnumerable<ProductViewModel>>(productDto);
            return View(productVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productVM = _mapper.Map<ProductDto>(model);
                await _productService.Create(productVM);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ProductDto product = await _productService.GetById(id);
            var productVM = _mapper.Map<ProductViewModel>(product);

            if (productVM != null)
            {
                return View(productVM);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ProductDto product = await _productService.GetById(id);
            var productVM = _mapper.Map<ProductViewModel>(product);

            if (productVM != null)
            {
                return View(productVM);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productVM = _mapper.Map<ProductDto>(model);
                await _productService.Edit(productVM);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ProductDto product = await _productService.GetById(id);
            var productVM = _mapper.Map<ProductViewModel>(product);

            if (productVM != null)
            {
                return View(productVM);
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(ProductViewModel model)
        {
            var productVM = _mapper.Map<ProductDto>(model);
            await _productService.Delete(productVM);
            return RedirectToAction("Index");
        }
    }
}