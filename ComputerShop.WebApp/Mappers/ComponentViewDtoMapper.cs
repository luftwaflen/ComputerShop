using AutoMapper;
using ComputerShop.WebApp.Models;
using ComputerShopLogic.Dto;

namespace ComputerShop.WebApp.Mappers
{
    public class ComponentViewDtoMapper : Profile
    {
        public ComponentViewDtoMapper()
        {
            CreateMap<ComponentDto, ComponentViewModel>().ReverseMap();
        }
    }
}
