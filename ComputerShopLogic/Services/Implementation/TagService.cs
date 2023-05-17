using AutoMapper;
using ComputerShopData.Entities;
using ComputerShopData.Repositories.Interfases;
using ComputerShopLogic.Dto;
using ComputerShopLogic.Services.Interfaces;

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

        public void Create(TagDto obj)
        {
            var entity = _mapper.Map<TagEntity>(obj);
            _repository.Create(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
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
            var entity = _repository.GetById(id);
            var dto = _mapper.Map<TagDto>(entity);

            return dto;
        }

        public void Update(TagDto obj)
        {
            var entity = _mapper.Map<TagEntity>(obj);
            _repository.Update(entity);
        }
    }
}
