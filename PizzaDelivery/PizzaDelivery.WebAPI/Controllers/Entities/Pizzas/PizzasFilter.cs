namespace PizzaDelivery.WebAPI.Controllers.Entities.Pizzas
{
    public class PizzasFilter
    {
        public string? Name { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
    }
}
