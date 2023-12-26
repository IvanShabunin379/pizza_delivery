using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PizzaDelivery.DataAccess.Entities.OrderEntity;

namespace PizzaDelivery.BL.Orders.Entities
{
    public class OrdersModelFilter
    {
        public double? MinOrderAmount { get; set; }
        public double? MaxOrderAmount { get; set; }
        public DateTime? MinOrderTime { get; set; }
        public DateTime? MaxOrderTime { get; set; }
        public OrderStatus? Status { get; set; }
    }
}
