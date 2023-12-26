using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PizzaDelivery.DataAccess.Entities.PizzaEntity;

namespace PizzaDelivery.BL.Pizzas.Entities
{
    public class PizzasModelFilter
    {
        public string? Name { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
    }
}
