using Microsoft.EntityFrameworkCore;
using PizzaDelivery.WebAPI.Settings;
using PizzaDelivery.DataAccess;

namespace PizzaDelivery.WebAPI.IoC
{
    public static class DbContextConfigurator
    {
        public static void ConfigureService(IServiceCollection services, PizzaDeliverySettings settings)
        {
            services.AddDbContextFactory<PizzaDeliveryDbContext>(
                options => { options.UseSqlServer(settings.PizzaDeliveryDbContextConnectionString); },
                ServiceLifetime.Scoped);
        }

        public static void ConfigureApplication(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<PizzaDeliveryDbContext>>();
            using var context = contextFactory.CreateDbContext();
            context.Database.Migrate(); //makes last migrations to db and creates database if it doesn't exist
        }
    }
}
