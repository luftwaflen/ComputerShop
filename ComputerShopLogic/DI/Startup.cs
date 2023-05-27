using ComputerShopData;
using ComputerShopData.Repositories.Implementation;
using ComputerShopData.Repositories.Interfases;
using ComputerShopLogic.Services.Implementation;
using ComputerShopLogic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerShopLogic.DI
{
    public static class Startup
    {
        public static void AddServices(this IServiceCollection services, string connection)
        {
            services.AddDbContext<AppDbContext>(
                options => options
                 .UseSqlite(connection)
                 .LogTo(Console.WriteLine)
                );

            services.AddScoped<IComponentRepository, ComponentRepository>();

            services.AddScoped<IComponentService,ComponentService>();
        }
    }
}
