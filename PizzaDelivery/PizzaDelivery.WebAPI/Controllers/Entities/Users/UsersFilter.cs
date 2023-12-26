namespace PizzaDelivery.WebAPI.Controllers.Entities.Users
{
    public class UsersFilter
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? MinOrdersCount { get; set; }
        public int? MaxOrdersCount { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
