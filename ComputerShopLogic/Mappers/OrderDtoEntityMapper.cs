using AutoMapper;
using ComputerShopData.Entities;
using ComputerShopLogic.Dto;

namespace ComputerShopLogic.Mappers;

public class OrderDtoEntityMapper : Profile
{
    public OrderDtoEntityMapper()
    {
        CreateMap<OrderDto, OrderEntity>().ReverseMap();
    }
}