using AutoMapper;
using ComputerShopLogic.Dto;
using ComputerShopWebApi.Models;

namespace ComputerShopWebApi.Mappers;

public class OrderApiDtoMapper : Profile
{
    public OrderApiDtoMapper()
    {
        CreateMap<OrderDto, OrderApiModel>().ReverseMap();
    }
}