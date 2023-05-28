using ComputerShopData.Entities;
using ComputerShopData.Repositories.Interfases;

namespace ComputerShopData.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public void Create(UserEntity entity)
        {
            _db.Users.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _db.Users.First(u => u.Id == id);
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return _db.Users.ToList();
        }

        public UserEntity GetById(int id)
        {
            var user = _db.Users.First(u => u.Id == id);
            return user;
        }

        public void Update(UserEntity entity)
        {
            _db.Users.Update(entity);
            _db.SaveChanges();
        }
    }
}