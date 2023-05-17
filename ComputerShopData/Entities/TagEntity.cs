using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopData.Entities
{
    public class TagEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ComponentEntity> TagComponents { get; set; }
    }
}
