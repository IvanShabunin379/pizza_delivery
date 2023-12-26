using AutoMapper;

using PizzaDelivery.BL.Orders.Entities;
using PizzaDelivery.DataAccess.Entities;

namespace BL.Mapper;

public class OrdersBLProfile : Profile
{
    public OrdersBLProfile()
    {
        CreateMap<OrderEntity, OrderModel>()
            .ForMember(Order => Order.Id, x => x.MapFrom(src => src.ExternalId))
            .ForMember(Order => Order.UserId, x => x.MapFrom(src => src.User.Id))
            .ForMember(Order => Order.OrderAmount, x => x.MapFrom(src => src.OrderAmount))
            .ForMember(Order => Order.DeliveryAddress, x => x.MapFrom(src => src.DeliveryAddress))
            .ForMember(Order => Order.OrderTime, x => x.MapFrom(src => src.OrderTime))
            .ForMember(Order => Order.Status, x => x.MapFrom(src => src.Status))
            .ForMember(Order => Order.PaymentTime, x => x.MapFrom(src => src.PaymentTime))
            .ForMember(Order => Order.MethodOfPayment, x => x.MapFrom(src => src.MethodOfPayment));

        CreateMap<CreateOrderModel, OrderEntity>()
            .ForMember(Order => Order.Id, x => x.Ignore())
            .ForMember(Order => Order.ExternalId, x => x.Ignore())
            .ForMember(Order => Order.CreationTime, x => x.Ignore())
            .ForMember(Order => Order.ModificationTime, x => x.Ignore());
    }
}
