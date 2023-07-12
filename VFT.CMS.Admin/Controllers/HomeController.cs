using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VFT.CMS.Admin.Models;

namespace VFT.CMS.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}