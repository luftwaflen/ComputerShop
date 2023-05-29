using AutoMapper;
using ComputerShopLogic.Dto;
using ComputerShopWebApi.Models;

namespace ComputerShopWebApi.Mappers;

public class ComponentApiDtoMapper : Profile
{
    public ComponentApiDtoMapper()
    {
        CreateMap<ComponentDto, ComponentApiModel>().ReverseMap();
    }
}