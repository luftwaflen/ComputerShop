using AutoMapper;
using ComputerShopIdentity.Models;
using ComputerShopIdentityWebApp.Models;
using ComputerShopLogic.Dto;
using ComputerShopLogic.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ComputerShopIdentityWebApp.Controllers;

public class ComponentController : Controller
{
    private readonly IMapper _mapper;
    private readonly IComponentService _componentService;
    private readonly IOrderService _orderService;
    private readonly IUserService _userService;
    private readonly UserManager<UserIdentityModel> _userManager;

    public ComponentController(
        IMapper mapper,
        IComponentService componentService,
        IOrderService orderService,
        IUserService userService,
        UserManager<UserIdentityModel> userManager)
    {
        _mapper = mapper;
        _componentService = componentService;
        _orderService = orderService;
        _userService = userService;
        _userManager = userManager;
    }

    private UserIdentityModel GetCurrentUser()
    {
        ClaimsPrincipal currentUser = this.User;
        var currentUserID = Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
        var user = _userManager.Users.First(u => u.Id == currentUserID);

        return user;
    }

    public ActionResult Index()
    {
        var componentsDto = _componentService.GetAll();
        var componentsView = new List<ComponentViewModel>();
        foreach (var component in componentsDto)
        {
            var view = _mapper.Map<ComponentViewModel>(component);
            componentsView.Add(view);
        }

        return View(componentsView);
    }

    public IActionResult Order(int id)
    {
        var order = new OrderDto();
        var component = _componentService.GetById(id);
        order.Coast = component.Coast;
        order.ComponentId = component.Id;
        var user = GetCurrentUser();
        order.UserId = user.Id;
        _orderService.Create(order);
        return RedirectToAction("Details", new { id = id });
    }

    public ActionResult Details(int id)
    {
        var dto = _componentService.GetById(id);
        var view = _mapper.Map<ComponentViewModel>(dto);
        return View(view);
    }

    public ActionResult Create()
    {
        return PartialView();
    }

    [HttpPost]
    public ActionResult Create(ComponentViewModel component)
    {
        var dto = _mapper.Map<ComponentDto>(component);
        _componentService.Create(dto);
        return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
        var dto = _componentService.GetById(id);
        var view = _mapper.Map<ComponentViewModel>(dto);
        return PartialView(view);
    }

    [HttpPost]
    public ActionResult Edit(ComponentViewModel component)
    {
        var dto = _mapper.Map<ComponentDto>(component);
        _componentService.Update(dto);
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        _componentService.Delete(id);
        return RedirectToAction("Index");
    }
}