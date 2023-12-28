using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PizzaDelivery.DataAccess.Entities
{
    public class UserEntity : IdentityUser<int>, IBaseEntity
    {
        public Guid ExternalId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }

        public required string Name { get; set; }
        public required string Surname { get; set; }
        public virtual ICollection<OrderEntity>? Orders { get; set; }
        public required bool IsAdmin { get; set; }
    }

    public class UserRoleEntity : IdentityRole<int> { }
}
