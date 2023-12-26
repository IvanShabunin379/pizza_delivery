using OrderDelivery.BL.Orders;
using PizzaDelivery.BL;
using PizzaDelivery.BL.Orders.Entities;
using PizzaDelivery.BL.Pizzas;
using PizzaDelivery.BL.Pizzas.Entities;
using PizzaDelivery.BL.Users;
using PizzaDelivery.BL.Users.Entities;
using PizzaDelivery.DataAccess;

namespace PizzaDelivery.Service.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureService(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IProvider<UserModel, UsersModelFilter>>();
        services.AddScoped<IManager<UserModel, CreateUserModel>, UsersManager>();

        services.AddScoped<IProvider<OrderModel, OrdersModelFilter>>();
        services.AddScoped<IManager<OrderModel, CreateOrderModel>, OrdersManager>();

        services.AddScoped<IProvider<PizzaModel, PizzasModelFilter>>();
        services.AddScoped<IManager<PizzaModel, CreatePizzaModel>, PizzasManager>();
    }
}