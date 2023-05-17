using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopData.Repositories.Interfases
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(int id);
    }
}
