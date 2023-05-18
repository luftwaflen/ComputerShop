using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopLogic.Services.Interfaces
{
    public interface IService<T>
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Create(T obj);
        public void Update(T obj);
        public void Delete(int id);
    }
}
