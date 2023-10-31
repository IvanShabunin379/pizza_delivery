namespace PizzaDelivery.WebAPI.Settings
{
    public class PizzaDeliverySettingsReader
    {
        public static PizzaDeliverySettings Read(IConfiguration configuration)
        {
            //здесь будет чтение настроек приложения из конфига
            return new PizzaDeliverySettings();
        }
    }
}
