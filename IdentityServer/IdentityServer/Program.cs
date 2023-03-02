using System.Reflection;
using Duende.IdentityServer.EntityFramework.Storage;
using IdentityServer;
using IdentityServer.Data;
using IdentityServer.Models;
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

builder.Services.AddControllers();

builder.Services.AddDbContext<AuthDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

SeedData.EnsureSeedData(connectionString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseIdentityServer();

app.MapControllers();

app.Run();