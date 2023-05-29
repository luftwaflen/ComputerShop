using ComputerShopLogic.Dto;
using ComputerShopLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<OrderDto>> Get()
    {
        return _orderService.GetAll().ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<OrderDto> Get(int id)
    {
        return _orderService.GetById(id);
    }

    [HttpPost]
    public ActionResult<OrderDto> Post(OrderDto componet)
    {
        if (componet == null)
        {
            return BadRequest();
        }

        _orderService.Create(componet);

        return Ok(componet);
    }
    
    [HttpPut]
    public ActionResult<OrderDto> Put(OrderDto componet)
    {
        if (componet == null)
        {
            return NotFound();
        }

        _orderService.Update(componet);

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