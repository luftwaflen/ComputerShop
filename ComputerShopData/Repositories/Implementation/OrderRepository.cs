using ComputerShopData.Entities;
using ComputerShopData.Repositories.Interfases;

namespace ComputerShopData.Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _db;

        public OrderRepository(AppDbContext db)
        {
            _db = db;
        }

        public void Create(OrderEntity entity)
        {
            _db.Orders.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = _db.Orders.First(o => o.Id == id);
            _db.Orders.Remove(order);
            _db.SaveChanges();
        }

        public IEnumerable<OrderEntity> GetAll()
        {
            return _db.Orders.ToList();
        }

        public OrderEntity GetById(int id)
        {
            var order = _db.Orders.First(o => o.Id == id);
            return order;
        }

        public void Update(OrderEntity entity)
        {
            _db.Orders.Update(entity);
            _db.SaveChanges();
        }
    }
}