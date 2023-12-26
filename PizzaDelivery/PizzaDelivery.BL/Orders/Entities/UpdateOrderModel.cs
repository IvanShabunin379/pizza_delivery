using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PizzaDelivery.DataAccess.Entities.OrderEntity;

namespace PizzaDelivery.BL.Orders.Entities
{
    public class UpdateOrderModel
    {
        public double? OrderAmount { get; set; }
        public string? DeliveryAddress { get; set; }
        public DateTime? OrderTime { get; set; }
        public OrderStatus? Status { get; set; }
        public DateTime? PaymentTime { get; set; }
        public PaymentMethod? MethodOfPayment { get; set; }
    }
}
