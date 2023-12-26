using PizzaDelivery.BL.Orders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.BL.Users.Entities
{
    public class UserModel
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public List<OrderModel>? Orders { get; set; }
        public required bool IsAdmin { get; set; }
    }
}
