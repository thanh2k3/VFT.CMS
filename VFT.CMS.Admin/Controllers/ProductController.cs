using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VFT.CMS.Admin.ViewModels.Categories;
using VFT.CMS.Admin.ViewModels.Products;
using VFT.CMS.Application.Categories;
using VFT.CMS.Application.Categories.Dto;
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

		public ProductController(IProductService productService, IMapper mapper, ICategoryService categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
			_mapper = mapper;
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

        public async Task<JsonResult> Create(CreateProductViewModel model, IFormFile? image)
        {
            if (ModelState.IsValid)
            {
                var productDto = _mapper.Map<CreateProductDto>(model);
                var product = await _productService.Create(productDto, image);
                if (product)
                {
                    return Json(new { success = true, message = "Thêm mới sản phẩm thành công" });
                }

                return Json(new { success = false, message = "Sản phẩm đã tồn tại" });
            }

            return Json(new { success = false, message = "Thêm mới sản phẩm thất bại" });
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
		public async Task<JsonResult> Edit(EditProductViewModel model, IFormFile? image)
		{
			if (ModelState.IsValid)
			{
				var productDto = _mapper.Map<EditProductDto>(model);
				await _productService.Update(productDto, image);

				return Json(new { success = true, message = "Cập nhật sản phẩm thành công" });
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
	}
}