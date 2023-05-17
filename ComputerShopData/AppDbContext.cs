﻿using ComputerShopData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopData
{
    public class AppDbContext : DbContext
    {
        DbSet<ComponentEntity> Components { get; set; }
        DbSet<TagEntity> Tags { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
    }
}
