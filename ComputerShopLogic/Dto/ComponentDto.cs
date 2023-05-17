﻿using System;
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
        public decimal Coast { get; set; }
        public List<TagDto> ComponentTags { get; set; }
    }
}