using AutoMapper;
using ComputerShopLogic.Dto;
using ComputerShopLogic.Services.Interfaces;
using ComputerShopWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComponentsController : ControllerBase
{
    private readonly IComponentService _componentService;
    private readonly IMapper _mapper;

    public ComponentsController(IComponentService componentService, IMapper mapper)
    {
        _mapper = mapper;
        _componentService = componentService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ComponentApiModel>> Get()
    {
        var dtos = _componentService.GetAll().ToList();
        var apis = new List<ComponentApiModel>();
        foreach (var dto in dtos)
        {
            var api = _mapper.Map<ComponentApiModel>(dto);
            apis.Add(api);
        }

        return apis;
    }

    [HttpGet("{id}")]
    public ActionResult<ComponentApiModel> Get(int id)
    {
        var dto = _componentService.GetById(id);
        var api = _mapper.Map<ComponentApiModel>(dto);
        
        return api;
    }

    [HttpPost]
    public ActionResult<ComponentApiModel> Post(ComponentApiModel componet)
    {
        if (componet == null)
        {
            return BadRequest();
        }

        var dto = _mapper.Map<ComponentDto>(componet);
        _componentService.Create(dto);

        return Ok(componet);
    }
    
    [HttpPut]
    public ActionResult<ComponentApiModel> Put(ComponentApiModel componet)
    {
        if (componet == null)
        {
            return NotFound();
        }
        var dto = _mapper.Map<ComponentDto>(componet);
        _componentService.Update(dto);

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