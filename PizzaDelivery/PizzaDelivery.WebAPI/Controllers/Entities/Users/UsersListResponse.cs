using PizzaDelivery.BL.Users.Entities;

namespace PizzaDelivery.WebAPI.Controllers.Entities.Users
{
    public class UsersListResponse
    {
        public List<UserModel>? Users { get; set; }
    }
}
