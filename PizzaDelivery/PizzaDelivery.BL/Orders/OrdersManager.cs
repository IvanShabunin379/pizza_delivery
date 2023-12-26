using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaDelivery.DataAccess;
using PizzaDelivery.BL;
using PizzaDelivery.BL.Orders.Entities;
using PizzaDelivery.DataAccess.Entities;
using static PizzaDelivery.DataAccess.Entities.OrderEntity;

namespace OrderDelivery.BL.Orders
{
    public class OrdersManager(IRepository<OrderEntity> OrdersRepository, IMapper mapper) : IManager<OrderModel, CreateOrderModel>
    {
        private readonly IRepository<OrderEntity> _ordersRepository = OrdersRepository;
        private readonly IMapper _mapper = mapper;

        public OrderModel Create(CreateOrderModel model)
        {
            var entity = _mapper.Map<OrderEntity>(model);

            _ordersRepository.Save(entity);

            return _mapper.Map<OrderModel>(entity);
        }

        public OrderModel Update(Guid id, OrderModel model)
        {
            var order = Find(id);

            order.OrderAmount = model.OrderAmount;
            order.DeliveryAddress = model.DeliveryAddress;
            order.OrderTime = model.OrderTime;
            order.Status = model.Status;
            order.PaymentTime = model.PaymentTime;
            order.MethodOfPayment = model.MethodOfPayment;

            _ordersRepository.Save(order);

            return _mapper.Map<OrderModel>(order);
        }

        public void Delete(Guid id)
        {
            _ordersRepository.Delete(Find(id));
        }

        private OrderEntity Find(Guid id)
        {
            return _ordersRepository.GetById(id) ?? throw new InvalidOperationException($"Order with ID {id} not found.");
        }
    }
}

