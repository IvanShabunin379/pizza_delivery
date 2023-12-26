using static PizzaDelivery.DataAccess.Entities.PizzaEntity;

namespace PizzaDelivery.WebAPI.Controllers.Entities.Pizzas
{
    public class UpdatePizzaRequest
    {
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
        public double? Weight { get; set; }
        public double? Calorific { get; set; }
    }
}
