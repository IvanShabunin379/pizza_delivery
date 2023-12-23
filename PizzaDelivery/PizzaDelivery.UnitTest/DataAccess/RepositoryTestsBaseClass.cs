using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.DataAccess;
using PizzaDelivery.WebAPI.Settings;

namespace PizzaDelivery.UnitTest.DataAccess
{
    public class RepositoryTestsBaseClass
    {
        public RepositoryTestsBaseClass()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            Settings = PizzaDeliverySettingsReader.Read(configuration);
            ServiceProvider = ConfigureServiceProvider();

            DbContextFactory = ServiceProvider.GetRequiredService<IDbContextFactory<PizzaDeliveryDbContext>>();
        }

        private IServiceProvider ConfigureServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContextFactory<PizzaDeliveryDbContext>(
                options => { options.UseSqlServer(Settings.PizzaDeliveryDbContextConnectionString); },
                ServiceLifetime.Scoped);
            return serviceCollection.BuildServiceProvider();
        }

        protected readonly PizzaDeliverySettings Settings;
        protected readonly IDbContextFactory<PizzaDeliveryDbContext> DbContextFactory;
        protected readonly IServiceProvider ServiceProvider;
    }
}
