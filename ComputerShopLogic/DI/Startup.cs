using ComputerShopData;
using ComputerShopData.Repositories.Implementation;
using ComputerShopData.Repositories.Interfases;
using ComputerShopLogic.Mappers;
using ComputerShopLogic.Services.Implementation;
using ComputerShopLogic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IComponentRepository, ComponentRepository>();

            services.AddScoped<ITagService,TagService>();
            services.AddScoped<IComponentService,ComponentService>();

            services.AddAutoMapper(typeof (ComponentMappingProfile), typeof (TagMappingProfile));
        }
    }
}
