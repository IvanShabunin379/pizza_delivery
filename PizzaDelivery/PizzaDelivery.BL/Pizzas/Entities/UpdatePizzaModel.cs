using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PizzaDelivery.DataAccess.Entities.PizzaEntity;

namespace PizzaDelivery.BL.Pizzas.Entities
{
    public class UpdatePizzaModel
    {
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
        public double? Weight { get; set; }
        public double? Calorific { get; set; }
    }
}
