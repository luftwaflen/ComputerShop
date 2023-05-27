using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopData.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public UserEntity User { get; set; }
        public ComponentEntity Component { get; set; }
        public decimal Coast { get; set; }
    }
}
