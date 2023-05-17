using AutoMapper;
using ComputerShopData.Entities;
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
    public class ComponentService : IComponentService
    {
        private readonly IComponentRepository _repository;
        private readonly IMapper _mapper;

        public ComponentService(IMapper mapper , IComponentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Create(ComponentDto obj)
        {
            var entity = _mapper.Map<ComponentEntity>(obj);
            _repository.Create(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<ComponentDto> GetAll()
        {
            var entities = _repository.GetAll();
            var dtos = new List<ComponentDto>();
            foreach (var entity in entities)
            {
                var dto = _mapper.Map<ComponentDto>(entity);
                dtos.Add(dto);
            }

            return dtos;
        }

        public ComponentDto GetById(int id)
        {
            var entity = _repository.GetById(id);
            var dto = _mapper.Map<ComponentDto>(entity);

            return dto;
        }

        public void Update(ComponentDto obj)
        {
            var entity = _mapper.Map<ComponentEntity>(obj);
            _repository.Update(entity);
        }
    }
}
