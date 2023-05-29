using System.Security.Claims;
using AutoMapper;
using ComputerShopIdentity.Models;
using ComputerShopIdentityWebApp.Models;
using ComputerShopLogic.Dto;
using ComputerShopLogic.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopIdentityWebApp.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly UserManager<UserIdentityModel> _userManager;
    private readonly IMapper _mapper;

    public OrderController(IOrderService orderService, IMapper mapper, UserManager<UserIdentityModel> userManager)
    {
        _orderService = orderService;
        _mapper = mapper;
        _userManager = userManager;
    }

    private UserIdentityModel GetCurrentUser()
    {
        ClaimsPrincipal currentUser = this.User;
        var currentUserID = Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
        var user = _userManager.Users.First(u => u.Id == currentUserID);

        return user;
    }

    public IActionResult Index()
    {
        var user = GetCurrentUser();
        IEnumerable<OrderDto> orderDtos = new List<OrderDto>();
        if (_userManager.IsInRoleAsync(user, "User").Result)
        {
            orderDtos = _orderService.GetAll().Where(o => o.UserId == user.Id);
        }
        else
        {
            orderDtos = _orderService.GetAll().ToList();
        }
        var orderViews = new List<OrderViewModel>();
        foreach (var orderDto in orderDtos)
        {
            var orderView = _mapper.Map<OrderViewModel>(orderDto);
            orderViews.Add(orderView);
        }

        return View(orderViews);
    }

    public IActionResult Delete(int id)
    {
        _orderService.Delete(id);
        return RedirectToAction("Index");
    }
}