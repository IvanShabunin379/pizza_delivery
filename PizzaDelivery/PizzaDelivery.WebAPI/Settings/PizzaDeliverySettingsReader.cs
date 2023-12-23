namespace PizzaDelivery.WebAPI.Settings
{
    public class PizzaDeliverySettingsReader
    {
        public static PizzaDeliverySettings Read(IConfiguration configuration)
        {
            return new PizzaDeliverySettings()
            {
                PizzaDeliveryDbContextConnectionString = configuration.GetValue<string>("PizzaDeliveryDbContext")
            };
        }
    }
}
