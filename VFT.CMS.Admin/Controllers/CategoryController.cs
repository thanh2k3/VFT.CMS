using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VFT.CMS.Admin.ViewModels.Categories;
using VFT.CMS.Application.Categories;
using VFT.CMS.Application.Categories.Dto;
using VFT.CMS.Core;
using VFT.CMS.Repository.Data;

namespace VFT.CMS.Admin.Controllers
{
	[Authorize]
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoryController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<JsonResult> GetData()
		{
			var categoryDto = await _categoryService.GetAll();
			var categoryVM = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDto);

			return Json(categoryVM);
		}

		[HttpPost]
		public async Task<JsonResult> Create(CategoryViewModel model)
		{
			if (ModelState.IsValid)
			{
				var categoryDto = _mapper.Map<CategoryDto>(model);
				var category = await _categoryService.Create(categoryDto);
				if (category)
				{
					return Json(new { success = true, message = "Tạo danh mục thành công" });
				}

				return Json(new { success = false, message = "Danh mục đã tồn tại" });
			}

			return Json(new { success = false, message = "Tạo danh mục thất bại" });
		}

		public async Task<ActionResult> Edit(int id)
		{
			var categoryDto = await _categoryService.GetById(id);
			var categoryVM = _mapper.Map<CategoryViewModel>(categoryDto);

			return PartialView("_EditModal", categoryVM);
		}

		[HttpPost]
		public async Task<JsonResult> Edit(CategoryViewModel model)
		{
			if (ModelState.IsValid)
			{
				var categoryDto = _mapper.Map<CategoryDto>(model);
				await _categoryService.Update(categoryDto);

				return Json(new { success = true, message = "Cập nhật dữ liệu thành công" });
			}
			return Json(new { success = false, message = "Cập nhật dữ liệu thất bại" });
		}

		[HttpPost]
		public async Task<JsonResult> Delete(int id)
		{
			if (ModelState.IsValid)
			{
				await _categoryService.Delete(id);

				return Json(new { success = true, message = "Xóa thành công" });
			}
			return Json(new { success = false, message = "Xóa thất bại" });
		}
	}
}
