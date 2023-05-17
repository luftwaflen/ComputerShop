using ComputerShopData.Entities;
using ComputerShopData.Repositories.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopData.Repositories.Implementation
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly AppDbContext _db;
        public ComponentRepository(AppDbContext db)
        {
            _db = db;
        }
        public void Create(ComponentEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ComponentEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public ComponentEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ComponentEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
