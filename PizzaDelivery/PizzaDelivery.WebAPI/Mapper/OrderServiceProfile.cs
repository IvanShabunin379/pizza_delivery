using AutoMapper;

using PizzaDelivery.BL.Orders.Entities;
using PizzaDelivery.WebAPI.Controllers.Entities.Orders;
namespace Service.Mapper;

public class OrdersServiceProfile : Profile
{
    public OrdersServiceProfile()
    {
        CreateMap<OrdersFilter, OrdersModelFilter>();
        CreateMap<CreateOrderRequest, CreateOrderModel>();
        CreateMap<UpdateOrderRequest, UpdateOrderModel>();
    }
}