using AutoMapper;
using PizzaDelivery.BL.Users.Entities;
using PizzaDelivery.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaDelivery.BL.Pizzas.Entities;
using static PizzaDelivery.DataAccess.Entities.PizzaEntity;
using PizzaDelivery.DataAccess.Repository;

namespace PizzaDelivery.BL.Pizzas
{
    public class PizzasManager(IRepository<PizzaEntity> pizzasRepository, IMapper mapper) : IManager<PizzaModel, CreatePizzaModel>
    {
        private readonly IRepository<PizzaEntity> _pizzasRepository = pizzasRepository;
        private readonly IMapper _mapper = mapper;

        public PizzaModel Create(CreatePizzaModel model)
        {
            var entity = _mapper.Map<PizzaEntity>(model);

            _pizzasRepository.Save(entity);

            return _mapper.Map<PizzaModel>(entity);
        }

        public PizzaModel Update(Guid id, PizzaModel model)
        {
            var pizza = Find(id);


            pizza.Name = model.Name;
            pizza.Price = model.Price;
            pizza.Description = model.Description;
            pizza.Weight = model.Weight;
            pizza.Calorific = model.Calorific;

            _pizzasRepository.Save(pizza);

            return _mapper.Map<PizzaModel>(pizza);
        }

        public void Delete(Guid id)
        {
            _pizzasRepository.Delete(Find(id));
        }

        private PizzaEntity Find(Guid id)
        {
            return _pizzasRepository.GetById(id) ?? throw new InvalidOperationException($"Pizza with ID {id} not found.");
        }
    }
}

