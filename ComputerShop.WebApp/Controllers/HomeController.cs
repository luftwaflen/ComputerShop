using ComputerShop.WebApp.Models;
using ComputerShopLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ComputerShop.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITagService _tagService;

        public HomeController(ILogger<HomeController> logger, ITagService tagService)
        {
            _logger = logger;
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            var tags = _tagService.GetAll();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}