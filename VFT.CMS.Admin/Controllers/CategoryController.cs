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
    }
}
