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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEntity>()
                .HasOne<ComponentEntity>()
                .WithMany()
                .HasForeignKey(o => o.ComponentId);

            modelBuilder.Entity<UserEntity>()
                .HasMany(u => u.Orders)
                .WithOne()
                .HasForeignKey(o => o.UserId);
        }
    }
}
