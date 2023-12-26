using static PizzaDelivery.DataAccess.Entities.OrderEntity;

namespace PizzaDelivery.WebAPI.Controllers.Entities.Orders
{
    public class OrdersFilter
    {
        public double? MinOrderAmount { get; set; }
        public double? MaxOrderAmount { get; set; }
        public DateTime? MinOrderTime { get; set; }
        public DateTime? MaxOrderTime { get; set; }
        public OrderStatus? Status { get; set; }
    }
}
