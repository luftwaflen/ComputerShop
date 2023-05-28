using AutoMapper;
using ComputerShopData.Entities;
using ComputerShopLogic.Dto;

namespace ComputerShopLogic.Mappers;

public class UserDtoEntityMapper : Profile
{
    public UserDtoEntityMapper()
    {
        CreateMap<UserDto, UserEntity>().ReverseMap();
    }
}