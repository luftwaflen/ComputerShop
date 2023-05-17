using AutoMapper;
using ComputerShopData.Entities;
using ComputerShopLogic.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopLogic.Mappers
{
    public class TagMappingProfile : Profile
    {
        public TagMappingProfile()
        {
            CreateMap<TagDto,TagEntity>().ReverseMap();
        }
    }
}
