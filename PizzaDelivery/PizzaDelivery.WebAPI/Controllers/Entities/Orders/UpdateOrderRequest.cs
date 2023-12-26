using static PizzaDelivery.DataAccess.Entities.OrderEntity;

namespace PizzaDelivery.WebAPI.Controllers.Entities.Orders
{
    public class UpdateOrderRequest
    {
        public double? OrderAmount { get; set; }
        public string? DeliveryAddress { get; set; }
        public DateTime? OrderTime { get; set; }
        public OrderStatus? Status { get; set; }
        public DateTime? PaymentTime { get; set; }
        public PaymentMethod? MethodOfPayment { get; set; }
    }
}
