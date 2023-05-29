using AutoMapper;
using ComputerShopIdentityWebApp.Models;
using ComputerShopLogic.Dto;

namespace ComputerShopIdentityWebApp.Mappers;

public class OrderViewDtoMapper : Profile
{
    public OrderViewDtoMapper()
    {
        CreateMap<OrderDto, OrderViewModel>().ReverseMap();
    }
}