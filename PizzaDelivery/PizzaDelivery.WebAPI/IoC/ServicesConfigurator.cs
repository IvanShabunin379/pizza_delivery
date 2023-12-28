using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OrderDelivery.BL.Orders;
using PizzaDelivery.BL;
using PizzaDelivery.BL.Auth;
using PizzaDelivery.BL.Orders.Entities;
using PizzaDelivery.BL.Pizzas;
using PizzaDelivery.BL.Pizzas.Entities;
using PizzaDelivery.BL.Users;
using PizzaDelivery.BL.Users.Entities;
using PizzaDelivery.DataAccess.Entities;
using PizzaDelivery.DataAccess.Repository;
using PizzaDelivery.WebAPI.Settings;

namespace PizzaDelivery.Service.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureService(IServiceCollection services, PizzaDeliverySettings settings)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IProvider<UserModel, UsersModelFilter>>(x => new UserProvider(x.GetRequiredService<IRepository<UserEntity>>(), x.GetRequiredService<IMapper>()));

        services.AddScoped<IAuthProvider>(x =>
                new AuthProvider(x.GetRequiredService<SignInManager<UserEntity>>(),
                x.GetRequiredService<UserManager<UserEntity>>(),
                x.GetRequiredService<IHttpClientFactory>(),
                settings.IdentityServerUri,
                settings.ClientId,
                settings.ClientSecret));

        services.AddScoped<IManager<OrderModel, CreateOrderModel>, OrdersManager>();
        services.AddScoped<IManager<PizzaModel, CreatePizzaModel>, PizzasManager>();
        services.AddScoped<IManager<UserModel, CreateUserModel>, UsersManager>();
    }
}