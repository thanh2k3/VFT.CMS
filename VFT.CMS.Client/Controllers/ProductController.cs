//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using VFT.CMS.Application.Common.Dto;
//using VFT.CMS.Application.Products;
//using VFT.CMS.Application.Products.Dto;
//using VFT.CMS.Client.ViewModels.Products;

//namespace VFT.CMS.Client.Controllers
//{
//	public class ProductController : Controller
//	{
//		private readonly ILogger<HomeController> _logger;
//		public readonly IProductService _productService;
//		public readonly IMapper _mapper;

//		public ProductController(ILogger<HomeController> logger, IProductService productService, IMapper mapper)
//		{
//			_logger = logger;
//			_productService = productService;
//			_mapper = mapper;
//		}

//		//public async Task<IActionResult> Index(string searchText = "", int page = 1, int pageSize = 12)
//		//{
//		//	PagedResultRequestDto<ProductDto> productDto = await _productService.GetAll(searchText, page, pageSize);

//		//	var pageVM = new PagedViewModel(productDto.TotalRecords, page, pageSize);
//		//	ViewBag.PagedViewModel = pageVM;

//		//	var productVM = _mapper.Map<PagedResultRequestDto<ProductViewModel>>(productDto);

//		//	return View(productVM);
//		//}

//		public async Task<IActionResult> Details(int id)
//		{
//			if (id == null)
//			{
//				return NotFound();
//			}

//			ProductDto productDto = await _productService.GetById(id);
//			var productVM = _mapper.Map<ProductViewModel>(productDto);

//			if (productVM == null)
//			{
//				return NotFound();
//			}
//			return View(productVM);
//		}
//	}
//}
