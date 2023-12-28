using AutoMapper;
using PizzaDelivery.BL.Pizzas.Entities;
using PizzaDelivery.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PizzaDelivery.DataAccess.Entities.PizzaEntity;
using PizzaDelivery.DataAccess.Repository;

namespace PizzaDelivery.BL.Pizzas
{
    public class PizzasProvider(IRepository<PizzaEntity> pizzasRepository, IMapper mapper) : IProvider<PizzaModel, PizzasModelFilter>
    {
        private readonly IRepository<PizzaEntity> _repository = pizzasRepository;
        private readonly IMapper _mapper = mapper;

        public IEnumerable<PizzaModel> Get(PizzasModelFilter? modelFilter = null)
        {
            string? name = modelFilter?.Name;
            double? minPrice = modelFilter?.MinPrice;
            double? maxPrice = modelFilter?.MaxPrice;

            var Pizzas = _repository.GetAll(Pizza => (
            (name == null || Pizza.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) &&
            (minPrice == null || Pizza.Price >= minPrice) &&
            (maxPrice == null || Pizza.Price <= maxPrice)
            ));

            return _mapper.Map<IEnumerable<PizzaModel>>(Pizzas);
        }

        public PizzaModel GetInfo(Guid id)
        {
            return _mapper.Map<PizzaModel>(Find(id));
        }

        private PizzaEntity Find(Guid id)
        {
            return _repository.GetById(id) ?? throw new InvalidOperationException($"Pizza with ID {id} not found.");
        }
    }
}

