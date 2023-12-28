namespace PizzaDelivery.WebAPI.Settings
{
    public class PizzaDeliverySettingsReader
    {
        public static PizzaDeliverySettings Read(IConfiguration configuration)
        {
            return new PizzaDeliverySettings()
            {
                ServiceUri = configuration.GetValue<Uri>("Uri"),
                PizzaDeliveryDbContextConnectionString = configuration.GetValue<string>("PizzaDeliveryDbContext"),
                IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
                ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
                ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
            };
        }
    }
}
