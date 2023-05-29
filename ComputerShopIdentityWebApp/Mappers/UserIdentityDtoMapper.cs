using AutoMapper;
using ComputerShopIdentity.Models;
using ComputerShopLogic.Dto;

namespace ComputerShopIdentityWebApp.Mappers
{
    public class UserIdentityDtoMapper : Profile
    {
        public UserIdentityDtoMapper()
        {
            CreateMap<UserDto, UserIdentityModel>().ReverseMap();
        }
    }
}
