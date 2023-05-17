﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopData.Entities
{
    public class ComponentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Coast { get; set; }
        public List<TagEntity> ComponentTags { get; set; }
    }
}