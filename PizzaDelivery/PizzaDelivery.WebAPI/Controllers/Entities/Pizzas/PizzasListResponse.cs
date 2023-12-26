using PizzaDelivery.BL.Pizzas.Entities;

namespace PizzaDelivery.WebAPI.Controllers.Entities.Pizzas
{
    public class PizzasListResponse
    {
        public List<PizzaModel>? Pizzas { get; set; }
    }
}
