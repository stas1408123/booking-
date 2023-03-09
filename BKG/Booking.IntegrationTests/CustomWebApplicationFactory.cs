using Booking.DAL;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.IntegrationTests;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram>
    where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor =
                services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<BookingDbContext>));

            if (dbContextDescriptor != null) services.Remove(dbContextDescriptor);

            services.AddDbContext<BookingDbContext>(options => options.UseInMemoryDatabase("InMemoryDbForTesting"));

            services.AddSingleton<IPolicyEvaluator, FakeAuthEvaluator>();

            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<BookingDbContext>();

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();


                db.SaveChanges();
            }
        });
    }
}