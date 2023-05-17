using ComputerShopData.Entities;
using ComputerShopData.Repositories.Interfases;

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
            _db.Components.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var component = GetById(id);
            _db.Components.Remove(component);
            _db.SaveChanges();
        }

        public IEnumerable<ComponentEntity> GetAll()
        {
            var components = _db.Components.ToList();
            return components;
        }

        public ComponentEntity GetById(int id)
        {
            var component = _db.Components.Find(id);
            return component;
        }

        public void Update(ComponentEntity entity)
        {
            _db.Components.Update(entity);
            _db.SaveChanges();
        }
    }
}
