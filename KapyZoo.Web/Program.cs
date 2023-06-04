using KapyZoo.DAL.Context;
using KapyZoo.DAL.Repositories.IRepository;
using KapyZoo.DAL.Repositories;
using KapyZoo.DAL.UnitOfWork.Contract;
using KapyZoo.DAL.UnitOfWork;
using KapyZoo.Shared.Models;
using Microsoft.EntityFrameworkCore;
using KapyZoo.Business.Services.IServices;
using KapyZoo.Business.Services;
using Microsoft.AspNetCore.Identity;
using KapyZoo.Web.Areas.Identity.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

var builder = WebApplication.CreateBuilder(args);

//Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddSimpleConsole(i => i.ColorBehavior = LoggerColorBehavior.Disabled);
});

var logger = loggerFactory.CreateLogger<Program>();

//Identity context configuration
var connectionString = builder.Configuration.GetConnectionString("IdentityDataContextConnection");
builder.Services.AddDbContext<IdentityDataContext>(options =>
    options.UseSqlServer(connectionString)); builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityDataContext>().AddDefaultTokenProviders();

//MVC
builder.Services.AddControllersWithViews();

// Dependency Injections
builder.Services.AddScoped<IZooRepository, ZooRepository>();
builder.Services.AddScoped<ISeedIdentityData, SeedIdentityData>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICapybaraService, CapybaraService>();
builder.Services.AddScoped<IGalleryPicturesService, GalleryPicturesService>();
builder.Services.AddScoped<IZooService, ZooService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//Razor pages
builder.Services.AddRazorPages();

//Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

//DB context config
builder.Services.AddDbContext<ZooDbContext>(opts =>
{
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:ZooConnection"], b => b.MigrationsAssembly("KapyZoo.Web"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseSession();

app.MapRazorPages();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Seed data in Db contexts
SeedData.EnsurePopulated(app);
SeedIdentityDatabase();

app.Run();


void SeedIdentityDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<ISeedIdentityData>();
        dbInitializer.EnsurePopulated(app);
    }
}