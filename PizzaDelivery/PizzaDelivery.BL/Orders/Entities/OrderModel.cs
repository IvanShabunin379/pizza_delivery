using PizzaDelivery.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PizzaDelivery.DataAccess.Entities.OrderEntity;

namespace PizzaDelivery.BL.Orders.Entities
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public required Guid UserId { get; set; }
        public double OrderAmount { get; set; }
        public required string DeliveryAddress { get; set; }
        public required DateTime OrderTime { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime PaymentTime { get; set; }
        public PaymentMethod MethodOfPayment { get; set; }
        public List<Guid>? PizzasInOrdersId { get; set; }
    }
}
