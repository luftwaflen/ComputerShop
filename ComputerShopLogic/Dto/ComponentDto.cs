using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopLogic.Dto
{
    public class ComponentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Coast { get; set; }
        public string ImageUrl { get; set; }
        public override bool Equals(object? obj)
        {
            var isEqual = true;
            var commpare = obj as ComponentDto;

            if (this.Name != commpare.Name)
            {
                isEqual = false;
            }
            if (this.Description != commpare.Description)
            {
                isEqual = false;
            }
            if (this.Coast != commpare.Coast)
            {
                isEqual = false;
            }
            
            return isEqual;
        }
    }
}
