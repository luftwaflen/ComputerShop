using AutoMapper;
using ComputerShopIdentityWebApp.Models;
using ComputerShopLogic.Dto;

namespace ComputerShopIdentityWebApp.Mappers
{
    public class ComponentViewDtoMapper : Profile
    {
        public ComponentViewDtoMapper()
        {
            CreateMap<ComponentDto, ComponentViewModel>().ReverseMap();
        }
    }
}
