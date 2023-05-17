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
    public class ComponentService : IComponentService
    {
        private readonly IComponentRepository _repository;
        private readonly IMapper _mapper;
        public ComponentService(IMapper mapper , IComponentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Create(ComponentDto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ComponentDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public ComponentDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ComponentDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
