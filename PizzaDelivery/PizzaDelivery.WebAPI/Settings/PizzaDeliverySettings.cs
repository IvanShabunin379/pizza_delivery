namespace PizzaDelivery.WebAPI.Settings
{
    public class PizzaDeliverySettings
    {
        public required Uri ServiceUri { get; set; }
        public required string PizzaDeliveryDbContextConnectionString { get; set; }
        public required string IdentityServerUri { get; set; }
        public required string ClientId { get; set; }
        public required string ClientSecret { get; set; }
    }
}
