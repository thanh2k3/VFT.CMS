using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VFT.CMS.Admin.ViewModels.Categories;
using VFT.CMS.Admin.ViewModels.Products;
using VFT.CMS.Application.Products;
using VFT.CMS.Application.Products.Dto;
using VFT.CMS.Core;
using VFT.CMS.Repository.Data;

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
		public async Task<IActionResult> Create(CreateProductViewModel model, IFormFile? image)
		{
			if (ModelState.IsValid)
			{
				// Kiểm tra xem sản phẩm đã tồn tại hay chưa
				var data = _mapper.Map<CreateProductDto>(model);
				var findProduct = _productService.FindProduct(data);
				if (findProduct)
				{
					ViewBag.message = "Sản phẩm đã tồn tại";
					var categoryDtos = await _productService.GetAllCategories();
					var categoryVMs = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDtos);
					ViewBag.Categories = new SelectList(categoryVMs, "Id", "Name");
					return View(model);
				}

				var cPDto = _mapper.Map<CreateProductDto>(model);
				await _productService.Create(cPDto, image);
				return RedirectToAction("Index");
			}

			var categoryDto = await _productService.GetAllCategories();
			var categoryVM = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDto);
			ViewBag.Categories = new SelectList(categoryVM, "Id", "Name");
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			if (id == null)
			{
				return NotFound();
			}

			ProductDto product = await _productService.GetById(id);
			var productVM = _mapper.Map<ProductViewModel>(product);

			if (productVM == null)
			{
				return NotFound();
			}
			return View(productVM);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if (id == null)
			{
				return NotFound();
			}

			ProductDto productDto = await _productService.GetById(id);
			var productVM = _mapper.Map<ProductViewModel>(productDto);

			if (productVM == null)
			{
				return NotFound();
			}

			var data = new ProductViewModel()
			{
				Name = productVM.Name,
				Description = productVM.Description,
				CategoryId = productVM.CategoryId,
				Price = productVM.Price,
				Quantity = productVM.Quantity,
				Image = productVM.Image,
			};

			var categoryDto = await _productService.GetAllCategories();
			var categoryVM = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDto);
			ViewBag.Categories = new SelectList(categoryVM, "Id", "Name");
			return View(data);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(EditProductViewModel model, IFormFile? image)
		{
			if (ModelState.IsValid)
			{
				var ePDto = _mapper.Map<EditProductDto>(model);
				await _productService.Update(ePDto, image);
				return RedirectToAction("Index");
			}

			var categoryDto = await _productService.GetAllCategories();
			var categoryVM = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDto);
			ViewBag.Categories = new SelectList(categoryVM, "Id", "Name");
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			if (id == null)
			{
				return NotFound();
			}

			ProductDto productDto = await _productService.GetById(id);
			var productVM = _mapper.Map<ProductViewModel>(productDto);

			if (productVM == null)
			{
				return NotFound();
			}
			return View(productVM);
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