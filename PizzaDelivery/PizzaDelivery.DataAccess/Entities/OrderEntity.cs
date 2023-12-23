using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.DataAccess.Entities
{
    public class OrderEntity : BaseEntity
    {
        public required UserEntity User { get; set; }
        public double OrderAmount {  get; set; }
        public required string DeliveryAddress { get; set; }
        public required DateTime OrderTime { get; set; }
        public OrderStatus Status {  get; set; }
        public DateTime PaymentTime { get; set; }
        public PaymentMethod MethodOfPayment { get; set; }
        public virtual required ICollection<PizzaInOrderEntity> PizzasInOrders { get; set; }


        public enum PaymentMethod 
        {
            Cash, Card
        }

        public enum OrderStatus
        {
            InProgress, IsReady
        }
    }

}
