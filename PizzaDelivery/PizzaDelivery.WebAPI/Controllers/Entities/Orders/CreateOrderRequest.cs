using static PizzaDelivery.DataAccess.Entities.OrderEntity;

namespace PizzaDelivery.WebAPI.Controllers.Entities.Orders
{
    public class CreateOrderRequest
    {
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
