using ComputerShop.WebApp.Mappers;
using ComputerShopLogic.DI;
using ComputerShopLogic.Dto;
using ComputerShopLogic.Mappers;
using ComputerShopLogic.Services.Interfaces;

namespace ComputerShop.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connection = builder.Configuration
                .GetConnectionString("DefaultConnection");
            builder.Services.AddServices(connection);

            builder.Services.AddAutoMapper(
                typeof(ComponentDtoEntityMapper),
                typeof(UserDtoEntityMapper),
                typeof(OrderDtoEntityMapper),
                typeof(ComponentViewDtoMapper),
                typeof(OrderViewDtoMapper)
            );

            var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Component}/{action=Index}/{id?}");

            app.Run();
        }
    }
}