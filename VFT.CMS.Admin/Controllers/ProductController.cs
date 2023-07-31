using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VFT.CMS.Admin.ViewModels.Categories;
using VFT.CMS.Admin.ViewModels.Products;
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
        public async Task<IActionResult> Create()
        {
            var categoryDto = await _productService.GetAllCategories();
            var categoryVM = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDto);
            ViewBag.Categories = new SelectList(categoryVM, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productDto = _mapper.Map<ProductDto>(model);
                await _productService.Create(productDto);
                return RedirectToAction("Index");
            }

            var categoryDto = await _productService.GetAllCategories();
            var categoryVM = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDto);
            ViewBag.Categories = new SelectList(categoryVM, "CategoryId", "Name");
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
            ProductDto productDto = await _productService.GetById(id);
            var productVM = _mapper.Map<ProductViewModel>(productDto);

            var data = new ProductViewModel()
            {
                Name = productVM.Name,
                Description = productVM.Description,
                CategoryId = productVM.CategoryId,
                Price = productVM.Price,
                Quantity = productVM.Quantity,
            };

            var categoryDto = await _productService.GetAllCategories();
            var categoryVM = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDto);
            ViewBag.Categories = new SelectList(categoryVM, "Id", "Name");
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productDto = _mapper.Map<ProductDto>(model);
                await _productService.Update(productDto);
                return RedirectToAction("Index");
            }

            var categoryDto = await _productService.GetAllCategories();
            var categoryVM = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDto);
            ViewBag.Categories = new SelectList(categoryVM, "CategoryId", "Name");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ProductDto productDto = await _productService.GetById(id);
            var productVM = _mapper.Map<ProductViewModel>(productDto);

            if (productVM != null)
            {
                return View(productVM);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductViewModel model)
        {
            var productDto = _mapper.Map<ProductDto>(model);
            await _productService.Delete(productDto);
            return RedirectToAction("Index");
        }
    }
}