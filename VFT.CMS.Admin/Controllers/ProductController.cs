using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VFT.CMS.Admin.ViewModels.Categories;
using VFT.CMS.Admin.ViewModels.Products;
using VFT.CMS.Application.Categories;
using VFT.CMS.Application.Categories.Dto;
using VFT.CMS.Application.Common.Dto;
using VFT.CMS.Application.Products;
using VFT.CMS.Application.Products.Dto;
using VFT.CMS.Core;
using VFT.CMS.Repository.Data;

namespace VFT.CMS.Admin.Controllers
{
	//[Authorize]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;
		private readonly AppDBContext _context;

		public ProductController(IProductService productService, IMapper mapper, ICategoryService categoryService, AppDBContext context)
		{
			_productService = productService;
			_categoryService = categoryService;
			_mapper = mapper;
			_context = context;
		}



		public async Task<IActionResult> Index()
		{
			var categoriesDto = await _categoryService.GetAll();
			var categoriesVM = _mapper.Map<IEnumerable<CategoryViewModel>>(categoriesDto);
			ViewBag.Categories = new SelectList(categoriesVM, "Id", "Name");

			return View();
		}

		public async Task<JsonResult> GetData()
		{
			var productsDto = await _productService.GetAll();
			var productsVM = _mapper.Map<IEnumerable<ProductViewModel>>(productsDto);

			return Json(productsVM);
		}

		public async Task<JsonResult> Create(CreateProductViewModel model)
		{
			if (ModelState.IsValid)
			{
				var productDto = _mapper.Map<CreateProductDto>(model);
				var product = await _productService.Create(productDto);
				if (product)
				{
					return Json(new { success = true, message = "Lưu sản phẩm thành công" });
				}

				return Json(new { success = false, message = "Sản phẩm đã tồn tại" });
			}

			return Json(new { success = false, message = "Lưu sản phẩm thất bại" });
		}

		public async Task<ActionResult> Edit(int id)
		{
			var productDto = await _productService.GetById(id);
			var productVM = _mapper.Map<EditProductViewModel>(productDto);

			var categoryDto = await _categoryService.GetAll();
			var categoryVM = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDto);
			ViewBag.Categories = new SelectList(categoryVM, "Id", "Name");

			return PartialView("_EditModal", productVM);
		}

		[HttpPost]
		public async Task<JsonResult> Edit(EditProductViewModel model)
		{
			if (ModelState.IsValid)
			{
				var productDto = _mapper.Map<EditProductDto>(model);
				var product = await _productService.Update(productDto);
				if (product)
				{
					return Json(new { success = true, message = "Cập nhật sản phẩm thành công" });
				}

				return Json(new { success = false, message = "Sản phẩm đã tồn tại" });
			}

			return Json(new { success = false, message = "Cập nhật sản phẩm thất bại" });
		}

		[HttpPost]
		public async Task<JsonResult> Delete(int id)
		{
			if (ModelState.IsValid)
			{
				await _productService.Delete(id);

				return Json(new { success = true, message = "Xóa thành công" });
			}
			return Json(new { success = false, message = "Xóa thất bại" });
		}

		public async Task<ActionResult> ViewModal(int id)
		{
			var productDto = await _productService.GetById(id);
			var productVM = _mapper.Map<ProductViewModel>(productDto);

			var categoryDto = await _categoryService.GetAll();
			var categoryVM = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDto);
			ViewBag.Categories = new SelectList(categoryVM, "Id", "Name");

			return PartialView("_ViewModal", productVM);
		}














		//[HttpGet]
		//public async Task<IActionResult> Index(string searchText = "", int pg = 1, int pageSize = 10)
		//{
		//	PagedResultRequestDto<ProductDto> productDto = await _productService.GetAll(searchText, pg, pageSize);

		//	var pageVM = new PagedViewModel(productDto.TotalRecords, pg, pageSize);
		//	ViewBag.PageViewModel = pageVM;

		//	var productVM = _mapper.Map<PagedResultRequestDto<ProductViewModel>>(productDto);

		//	return View(productVM);
		//}

		//[HttpGet]
		//public async Task<IActionResult> Create()
		//{
		//	var categoryDto = await _productService.GetAllCategories();
		//	var categoryVM = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDto);
		//	ViewBag.Categories = new SelectList(categoryVM, "Id", "Name");

		//	return View();
		//}

		//[HttpPost]
		//public async Task<IActionResult> Create(CreateProductViewModel model, IFormFile? image)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		// Kiểm tra xem sản phẩm đã tồn tại hay chưa
		//		var data = _mapper.Map<CreateProductDto>(model);
		//		var findProduct = _productService.FindProduct(data);
		//		if (findProduct)
		//		{
		//			ViewBag.message = "Sản phẩm đã tồn tại";
		//			var categoryDtos = await _productService.GetAllCategories();
		//			var categoryVMs = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDtos);
		//			ViewBag.Categories = new SelectList(categoryVMs, "Id", "Name");

		//			return View(model);
		//		}

		//		var cPDto = _mapper.Map<CreateProductDto>(model);
		//		await _productService.Create(cPDto, image);

		//		return RedirectToAction("Index");
		//	}

		//	var categoryDto = await _productService.GetAllCategories();
		//	var categoryVM = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDto);
		//	ViewBag.Categories = new SelectList(categoryVM, "Id", "Name");

		//	return View(model);
		//}

		//[HttpGet]
		//public async Task<IActionResult> Details(int id)
		//{
		//	if (id == null)
		//	{
		//		return NotFound();
		//	}

		//	ProductDto productDto = await _productService.GetById(id);
		//	var productVM = _mapper.Map<ProductViewModel>(productDto);

		//	if (productVM == null)
		//	{
		//		return NotFound();
		//	}
		//	return View(productVM);
		//}

		//[HttpGet]
		//public async Task<IActionResult> Edit(int id)
		//{
		//	if (id == null)
		//	{
		//		return NotFound();
		//	}

		//	ProductDto productDto = await _productService.GetById(id);
		//	var productVM = _mapper.Map<EditProductViewModel>(productDto);

		//	if (productVM == null)
		//	{
		//		return NotFound();
		//	}

		//	var categoryDto = await _productService.GetAllCategories();
		//	var categoryVM = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDto);
		//	ViewBag.Categories = new SelectList(categoryVM, "Id", "Name");

		//	return View(productVM);
		//}

		//[HttpPost]
		//public async Task<IActionResult> Edit(EditProductViewModel model)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		var categoryDto = await _productService.GetAllCategories();
		//		var categoryVM = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDto);
		//		ViewBag.Categories = new SelectList(categoryVM, "Id", "Name");

		//		return View(model);
		//	}

		//	var ePDto = _mapper.Map<EditProductDto>(model);
		//	await _productService.Update(ePDto);

		//	return RedirectToAction("Index");
		//}

		//[HttpGet]
		//public async Task<IActionResult> Delete(int id)
		//{
		//	if (id == null)
		//	{
		//		return NotFound();
		//	}

		//	ProductDto productDto = await _productService.GetById(id);
		//	var productVM = _mapper.Map<ProductViewModel>(productDto);

		//	if (productVM == null)
		//	{
		//		return NotFound();
		//	}

		//	return View(productVM);
		//}

		//[HttpPost]
		//public async Task<IActionResult> Delete(ProductViewModel model)
		//{
		//	var productDto = _mapper.Map<ProductDto>(model);
		//	await _productService.Delete(productDto);

		//	return RedirectToAction("Index");
		//}
	}
}