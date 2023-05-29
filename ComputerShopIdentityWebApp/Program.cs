using ComputerShopIdentity;
using ComputerShopIdentity.Models;
using ComputerShopIdentityWebApp.Mappers;
using ComputerShopLogic.DI;
using ComputerShopLogic.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = builder.Configuration
                .GetConnectionString("DefaultConnection");
builder.Services.AddServices(connection);

builder.Services.AddDbContext<IdentityContext>(options =>
{
    options
        .UseSqlite(connection)
        .LogTo(Console.WriteLine);
});

builder.Services.AddIdentity<UserIdentityModel, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.SignIn.RequireConfirmedEmail = false;
})
    .AddEntityFrameworkStores<IdentityContext>()
    .AddUserManager<UserManager<UserIdentityModel>>();

builder.Services.AddAutoMapper(
    typeof(ComponentDtoEntityMapper),
    typeof(UserDtoEntityMapper),
    typeof(OrderDtoEntityMapper),
    typeof(ComponentViewDtoMapper),
    typeof(OrderViewDtoMapper),
    typeof(UserIdentityDtoMapper)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();