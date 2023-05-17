using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopLogic.Dto
{
    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ComponentDto> TagComponents { get; set; }
    }
}
