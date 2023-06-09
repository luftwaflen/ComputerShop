﻿using ComputerShopLogic.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopLogic.Services.Interfaces
{
    public interface IComponentService : IService<ComponentDto>
    {
        public IEnumerable<ComponentDto> FindByName(string name);
        public IEnumerable<ComponentDto> FindByCoast(decimal from, decimal to);
    }
}
