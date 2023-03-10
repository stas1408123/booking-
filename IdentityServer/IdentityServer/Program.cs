using System.Reflection;
using Duende.IdentityServer.EntityFramework.Storage;
using IdentityServer;
using IdentityServer.Data;
using IdentityServer.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var assembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(opt =>
    {
        opt.Password.RequireDigit = false;
        opt.Password.RequireLowercase = false;
        opt.Password.RequireUppercase = false;
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequiredLength = 4;
    })
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AuthDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddIdentityServer()
    .AddInMemoryIdentityResources(Configuration.GetIdentityResources())
    .AddInMemoryApiResources(Configuration.GetApiResources())
    .AddInMemoryClients(Configuration.GetClients())
    .AddInMemoryApiScopes(Configuration.GetApiScopes())
    .AddAspNetIdentity<ApplicationUser>();

builder.Services.AddDbContext<AuthDbContext>(opt => { opt.UseSqlServer(connectionString); })
    .AddOperationalDbContext(opt =>
    {
        opt.ConfigureDbContext = o => o.UseSqlServer(connectionString,
            sql => sql.MigrationsAssembly(assembly));
    })
    .AddConfigurationDbContext(opt =>
    {
        opt.ConfigureDbContext = o => o.UseSqlServer(connectionString,
            sql => sql.MigrationsAssembly(assembly));
    });

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
    });

SeedData.EnsureSeedData(connectionString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseStaticFiles();

app.UseIdentityServer();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();