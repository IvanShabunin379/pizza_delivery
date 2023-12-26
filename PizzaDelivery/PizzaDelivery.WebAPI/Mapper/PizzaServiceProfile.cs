using AutoMapper;

using PizzaDelivery.BL.Pizzas.Entities;
using PizzaDelivery.WebAPI.Controllers.Entities.Pizzas;
namespace Service.Mapper;

public class PizzasServiceProfile : Profile
{
    public PizzasServiceProfile()
    {
        CreateMap<PizzasFilter, PizzasModelFilter>();
        CreateMap<CreatePizzaRequest, CreatePizzaModel>();
        CreateMap<UpdatePizzaRequest, UpdatePizzaModel>();
    }
}