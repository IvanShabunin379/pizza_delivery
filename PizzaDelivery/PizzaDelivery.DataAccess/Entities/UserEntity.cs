using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.DataAccess.Entities
{
    public class UserEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public virtual ICollection<OrderEntity>? Orders { get; set; }
        public required bool IsAdmin { get; set; }
    }
}
