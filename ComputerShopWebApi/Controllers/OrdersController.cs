using AutoMapper;
using ComputerShopLogic.Dto;
using ComputerShopLogic.Services.Interfaces;
using ComputerShopWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrdersController(IOrderService orderService, IMapper mapper)
    {
        _mapper = mapper;
        _orderService = orderService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<OrderApiModel>> Get()
    {
        var dtos = _orderService.GetAll().ToList();
        var apis = new List<OrderApiModel>();
        foreach (var dto in dtos)
        {
            var api = _mapper.Map<OrderApiModel>(dto);
            apis.Add(api);
        }

        return apis;
    }

    [HttpGet("{id}")]
    public ActionResult<OrderApiModel> Get(int id)
    {
        var dto = _orderService.GetById(id);
        var api = _mapper.Map<OrderApiModel>(dto);
        return api;
    }

    [HttpPost]
    public ActionResult<OrderApiModel> Post(OrderApiModel componet)
    {
        if (componet == null)
        {
            return BadRequest();
        }

        var dto = _mapper.Map<OrderDto>(componet);
        _orderService.Create(dto);

        return Ok(componet);
    }

    [HttpPut]
    public ActionResult<OrderApiModel> Put(OrderApiModel componet)
    {
        if (componet == null)
        {
            return NotFound();
        }
        var dto = _mapper.Map<OrderDto>(componet);
        _orderService.Update(dto);

        return Ok(componet);
    }

    [HttpDelete("{id}")]
    public ActionResult<OrderDto> Delete(int id)
    {
        var component = _orderService.GetById(id);
        if (component == null)
        {
            return NotFound();
        }

        _orderService.Delete(id);

        return Ok(component);
    }
}