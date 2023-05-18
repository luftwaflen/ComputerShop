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
            _db.Tags.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var tag = GetById(id);
            _db.Tags.Remove(tag);
            _db.SaveChanges();
        }

        public IEnumerable<TagEntity> GetAll()
        {
            var tags = _db.Tags.ToList();
            return tags;
        }

        public TagEntity GetById(int id)
        {
            var tag = _db.Tags.Find(id);
            return tag;
        }

        public void Update(TagEntity entity)
        {
            _db.Tags.Update(entity);
            _db.SaveChanges();
        }
    }
}
