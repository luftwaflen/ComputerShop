using AutoMapper;
using ComputerShop.WebApp.Models;
using ComputerShopLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ComputerShop.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly ITagService _tagService;
        private readonly IComponentService _componentService;

        public HomeController(
            ILogger<HomeController> logger,
            IMapper mapper,
            ITagService tagService,
            IComponentService componentService)
        {
            _logger = logger;
            _mapper = mapper;
            _tagService = tagService;
            _componentService = componentService;
        }

        public IActionResult Index()
        {
            var componentsDto = _componentService.GetAll();
            var componentsView = new List<ComponentViewModel>();
            foreach (var component in componentsDto)
            {
                var view = _mapper.Map<ComponentViewModel>(component);
                view.Icon = "F:\\4k Hentai\\IgiLabs\\ComputerShop\\ComputerShop.WebApp\\wwwroot\\icons\\001.png";
                componentsView.Add(view);
            }
            return View(componentsView);
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