using AutoMapper;
using ComputerShop.WebApp.Models;
using ComputerShopLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.WebApp.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    private readonly IMapper _mapper;

    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var orderDtos = _orderService.GetAll();
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