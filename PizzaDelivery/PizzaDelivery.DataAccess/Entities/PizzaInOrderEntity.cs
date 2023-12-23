using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.DataAccess.Entities
{
    public class PizzaInOrderEntity : BaseEntity
    {
        public required PizzaEntity Pizza { get; set; }
        public required OrderEntity Order { get; set; }
        public int Count { get; set; }

    }
}
