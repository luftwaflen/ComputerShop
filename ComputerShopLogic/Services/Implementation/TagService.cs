using AutoMapper;
using ComputerShopData.Repositories.Interfases;
using ComputerShopLogic.Dto;
using ComputerShopLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopLogic.Services.Implementation
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;
        public TagService(IMapper mapper, ITagRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public void Create(TagDto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TagDto> GetAll()
        {
            var tags = _repository.GetAll();
            var tagsDto = new List<TagDto>();
            foreach (var tag in tags)
            {
                var tagDto = _mapper.Map<TagDto>(tags);
                tagsDto.Add(tagDto);
            }
            
            return tagsDto;
        }

        public TagDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TagDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
