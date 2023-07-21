using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VFT.CMS.Admin.Models.Categories;
using VFT.CMS.Application.Categories;
using VFT.CMS.Application.Categories.Dto;

namespace VFT.CMS.Admin.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoryController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

        [HttpGet]
        public async Task<IActionResult> Index()
		{
			var categoryDto = await _categoryService.GetAll();
			var categoryVM = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryDto);
			return View(categoryVM);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
			if (ModelState.IsValid)
			{
				var categoryDto = _mapper.Map<CategoryDto>(model);
				await _categoryService.Create(categoryDto);
				return RedirectToAction("Index");
			}
            return View();
        }

		[HttpGet]
		public async Task<IActionResult> Detail(int id)
		{
			var categoryDto = await _categoryService.GetById(id);
			var categoryVM = _mapper.Map<CategoryViewModel>(categoryDto);

			if (categoryVM != null)
			{
				return View(categoryVM);
			}
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			CategoryDto categoryDto = await _categoryService.GetById(id);
			var categoryVM = _mapper.Map<CategoryViewModel>(categoryDto);

			if (categoryVM != null)
			{
				return View(categoryVM);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Edit(CategoryViewModel model)
		{
			if (ModelState.IsValid)
			{
				var categoryDto = _mapper.Map<CategoryDto>(model);
				await _categoryService.Edit(categoryDto);
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			CategoryDto categoryDto = await _categoryService.GetById(id);
			var categoryVM = _mapper.Map<CategoryViewModel>(categoryDto);

			if (categoryVM != null)
			{
				return View(categoryVM);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(CategoryViewModel model)
		{
			var categoryDto = _mapper.Map<CategoryDto>(model);
			await _categoryService.Delete(categoryDto);
			return RedirectToAction("Index");
		}
    }
}
