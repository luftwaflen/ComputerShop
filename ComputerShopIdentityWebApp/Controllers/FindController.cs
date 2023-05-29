using AutoMapper;
using ComputerShopIdentityWebApp.Models;
using ComputerShopLogic.Dto;
using ComputerShopLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopIdentityWebApp.Controllers;

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

        var componentsByCoast = _componentService.FindByCoast(findParams.CoastFrom, findParams.CoastTo);
        var findedComponents = new List<ComponentDto>();
        foreach (var componentByName in componentsByName)
        {
            foreach (var componentByCoast in componentsByCoast)
            {
                if (componentByName.Name == componentByCoast.Name &&
                    componentByName.Description == componentByName.Description &&
                    componentByName.Id == componentByName.Id &&
                    componentByName.Coast == componentByName.Coast)
                {
                    findedComponents.Add(componentByName);
                }
            }
        }

        var findViews = new List<ComponentViewModel>();
        foreach (var component in findedComponents)
        {
            var view = _mapper.Map<ComponentViewModel>(component);
            findViews.Add(view);
        }

        ViewData["Components"] = findViews;

        return View(findParams);
    }
}