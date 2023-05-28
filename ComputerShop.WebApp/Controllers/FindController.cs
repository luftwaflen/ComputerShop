using AutoMapper;
using ComputerShop.WebApp.Models;
using ComputerShopLogic.Dto;
using ComputerShopLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.WebApp.Controllers
{
    public class FindController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IComponentService _componentService;

        public FindController(IMapper mapper, IComponentService componentService)
        {
            _mapper = mapper;
            _componentService = componentService;
        }

        public IActionResult Index(FindViewModel findParams)
        {
            if (findParams.CoastFrom == null)
            {
                findParams.CoastFrom = 0;
            }
            if (findParams.CoastTo == null)
            {
                findParams.CoastTo = Decimal.MaxValue;
            }
            
            IEnumerable<ComponentDto> componentsByName = new List<ComponentDto>();
            if (findParams.Name is null)
            {
                componentsByName = _componentService.GetAll();
            }
            else
            {
                componentsByName = _componentService.FindByName(findParams.Name);
            }

            var componentByCoast = _componentService.FindByCoast(findParams.CoastFrom, findParams.CoastTo);
            var findedComponents = componentsByName.Intersect(componentByCoast);

            return View(findedComponents);
        }
    }
}