using PizzaDelivery.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PizzaDelivery.DataAccess.Entities.PizzaEntity;

namespace PizzaDelivery.BL.Pizzas.Entities
{
    public class PizzaModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }
        public required string Description { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
        public double Weight { get; set; }
        public double Calorific { get; set; }
        public List<Guid>? PizzasInOrdersId { get; set; }
    }
}
