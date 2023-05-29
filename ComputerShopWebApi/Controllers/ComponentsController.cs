using ComputerShopLogic.Dto;
using ComputerShopLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComponentsController : ControllerBase
{
    private readonly IComponentService _componentService;

    public ComponentsController(IComponentService componentService)
    {
        _componentService = componentService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ComponentDto>> Get()
    {
        return _componentService.GetAll().ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<ComponentDto> Get(int id)
    {
        return _componentService.GetById(id);
    }

    [HttpPost]
    public ActionResult<ComponentDto> Post(ComponentDto componet)
    {
        if (componet == null)
        {
            return BadRequest();
        }

        _componentService.Create(componet);

        return Ok(componet);
    }
    
    [HttpPut]
    public ActionResult<ComponentDto> Put(ComponentDto componet)
    {
        if (componet == null)
        {
            return NotFound();
        }

        _componentService.Update(componet);

        return Ok(componet);
    }
    
    [HttpDelete("{id}")]
    public ActionResult<ComponentDto> Delete(int id)
    {
        var component = _componentService.GetById(id);
        if (component == null)
        {
            return NotFound();
        }
        _componentService.Delete(id);

        return Ok(component);
    }
}