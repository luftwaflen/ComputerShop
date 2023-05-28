using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopData.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public List<OrderEntity> Orders { get; set; }
    }
}
