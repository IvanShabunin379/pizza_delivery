using AutoMapper;

using PizzaDelivery.BL.Pizzas.Entities;
using PizzaDelivery.DataAccess.Entities;

namespace BL.Mapper;

public class PizzasBLProfile : Profile
{
    public PizzasBLProfile()
    {
        CreateMap<PizzaEntity, PizzaModel>()
            .ForMember(pizza => pizza.Id, x => x.MapFrom(src => src.ExternalId))
            .ForMember(pizza => pizza.Name, x => x.MapFrom(src => src.Name))
            .ForMember(pizza => pizza.Price, x => x.MapFrom(src => src.Price))
            .ForMember(pizza => pizza.Description, x => x.MapFrom(src => src.Description))
            .ForMember(pizza => pizza.Ingredients, x => x.MapFrom(src => src.Ingredients))
            .ForMember(pizza => pizza.Weight, x => x.MapFrom(src => src.Weight))
            .ForMember(pizza => pizza.Calorific, x => x.MapFrom(src => src.Calorific));

        CreateMap<CreatePizzaModel, PizzaEntity>()
            .ForMember(pizza => pizza.Id, x => x.Ignore())
            .ForMember(pizza => pizza.ExternalId, x => x.Ignore())
            .ForMember(pizza => pizza.CreationTime, x => x.Ignore())
            .ForMember(pizza => pizza.ModificationTime, x => x.Ignore());
    }
}
