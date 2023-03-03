using System.Reflection;
using System.Security.Claims;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Duende.IdentityServer.EntityFramework.Storage;
using IdentityModel;
using IdentityServer.Data;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer;

public class SeedData
{
    public static void EnsureSeedData(string? connectionString)
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddDbContext<AuthDbContext>(opt => opt.UseSqlServer(connectionString))
            .AddOperationalDbContext(opt =>
            {
                opt.ConfigureDbContext = db => db.UseSqlServer(connectionString,
                    sql => sql.MigrationsAssembly(typeof(SeedData).GetTypeInfo().Assembly.GetName().Name));
            })
            .AddConfigurationDbContext(opt =>
            {
                opt.ConfigureDbContext = db => db.UseSqlServer(connectionString,
                    sql => sql.MigrationsAssembly(typeof(SeedData).GetTypeInfo().Assembly.GetName().Name));
            });

        services.AddIdentity<ApplicationUser, ApplicationRole>(opt =>
        {
            opt.Password.RequireDigit = false;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequiredLength = 4;
        })
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

        var serviceProvider = services.BuildServiceProvider();

        using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            scope.ServiceProvider.GetService<PersistedGrantDbContext>()?.Database.Migrate();

            var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            context.Database.Migrate();

            EnsureSeedData(context);

            var ctx = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
            ctx.Database.Migrate();
            EnsureUsers(scope);
        }
    }

    private static void EnsureUsers(IServiceScope scope)
    {
        var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var stasyan = userMgr.FindByNameAsync("stasyan").Result;

        if (stasyan is null)
        {
            stasyan = new ApplicationUser
            {
                UserName = "stasyan",
                Email = "StasyanBelov@gmail.com",
                EmailConfirmed = true
            };
            var result = userMgr.CreateAsync(stasyan, "1234").Result;

            if (!result.Succeeded) throw new Exception(result.Errors.First().Description);

            result = userMgr.AddClaimsAsync(stasyan, new[]
            {
                new Claim(JwtClaimTypes.Name, "Stasyan Belov"),
                new Claim(JwtClaimTypes.GivenName, "Stasyan"),
                new Claim(JwtClaimTypes.FamilyName, "Belov"),
                new Claim(JwtClaimTypes.WebSite, "http://stasyan.com")
            }).Result;

            if (!result.Succeeded) throw new Exception(result.Errors.First().Description);
        }

        var danilka = userMgr.FindByNameAsync("danilka").Result;

        if (danilka is null)
        {
            danilka = new ApplicationUser
            {
                UserName = "danilka",
                Email = "DanilkaFeo@gmail.com",
                EmailConfirmed = true
            };
            var result = userMgr.CreateAsync(danilka, "1234").Result;

            if (!result.Succeeded) throw new Exception(result.Errors.First().Description);

            result = userMgr.AddClaimsAsync(danilka, new[]
            {
                new Claim(JwtClaimTypes.Name, "Danilka Feo"),
                new Claim(JwtClaimTypes.GivenName, "Danilka"),
                new Claim(JwtClaimTypes.FamilyName, "Feo"),
                new Claim(JwtClaimTypes.WebSite, "http://danilka.com")
            }).Result;

            if (!result.Succeeded) throw new Exception(result.Errors.First().Description);
        }
    }

    private static void EnsureSeedData(ConfigurationDbContext context)
    {
        if (!context.Clients.Any())
        {
            foreach (var client in Configuration.GetClients())
            {
                context.Clients.Add(client.ToEntity());
            }
            context.SaveChanges();
        }

        if (!context.IdentityResources.Any())
        {
            foreach (var resource in Configuration.GetIdentityResources())
                context.IdentityResources.Add(resource.ToEntity());
            context.SaveChanges();
        }

        if (!context.ApiResources.Any())
        {
            foreach (var resource in Configuration.GetApiResources())
                context.ApiResources.Add(resource.ToEntity());
            context.SaveChanges();
        }

        if (!context.ApiScopes.Any())
        {
            foreach (var scope in Configuration.GetApiScopes())
                context.ApiScopes.Add(scope.ToEntity());
            context.SaveChanges();
        }
    }
}
