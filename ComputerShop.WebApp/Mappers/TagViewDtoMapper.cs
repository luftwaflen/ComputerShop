using AutoMapper;
using ComputerShop.WebApp.Models;
using ComputerShopLogic.Dto;

namespace ComputerShop.WebApp.Mappers
{
    public class TagViewDtoMapper : Profile
    {
        public TagViewDtoMapper()
        {
            CreateMap<TagDto, TagViewModel>().ReverseMap();
        }
    }
}
