using AutoMapper;
using ComputerShop.WebApp.Models;
using ComputerShopLogic.Dto;

namespace ComputerShop.WebApp.Mappers;

public class OrderViewDtoMapper : Profile
{
    public OrderViewDtoMapper()
    {
        CreateMap<OrderDto, OrderViewModel>().ReverseMap();
    }
}