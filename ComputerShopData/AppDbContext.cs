using ComputerShopData.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerShopData
{
    public class AppDbContext : DbContext
    {
        public DbSet<ComponentEntity> Components { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
    }
}
