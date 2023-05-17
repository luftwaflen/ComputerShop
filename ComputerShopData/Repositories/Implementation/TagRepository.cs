using ComputerShopData.Entities;
using ComputerShopData.Repositories.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopData.Repositories.Implementation
{
    public class TagRepository : ITagRepository
    {
        private readonly AppDbContext _db;
        public TagRepository(AppDbContext db)
        {
            _db = db;
        }
        public void Create(TagEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TagEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TagEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TagEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
