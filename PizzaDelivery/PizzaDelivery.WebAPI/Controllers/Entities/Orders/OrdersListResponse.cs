using PizzaDelivery.BL.Orders.Entities;

namespace PizzaDelivery.WebAPI.Controllers.Entities.Orders
{
    public class OrdersListResponse
    {
        public List<OrderModel>? Orders { get; set; }
    }
}
