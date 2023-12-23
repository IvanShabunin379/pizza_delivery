using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.DataAccess.Entities
{
    public class PizzaEntity : BaseEntity
    {
        public required string Name {  get; set; }
        public double Price { get; set; }
        public required string Description { get; set; }
        public virtual ICollection<Ingredient>? Ingredients { get; set; }
        public double Weight { get; set; }
        public double Calorific { get; set; }
        public virtual ICollection<PizzaInOrderEntity>? PizzasInOrders { get; set; }

        public enum Ingredient
        {
            Ham, 
            Chicken, 
            Pineapple, 
            Cherry, 
            Parmesan, 
            Mozzarella, 
            Gherkins, 
            Onion
        }
    }
}
