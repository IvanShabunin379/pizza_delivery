using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaDelivery.DataAccess.Entities;
using PizzaDelivery.BL.Orders.Entities;
using PizzaDelivery.BL;
using static PizzaDelivery.DataAccess.Entities.OrderEntity;
using PizzaDelivery.DataAccess.Repository;

namespace OrderDelivery.BL.Orders
{
    public class OrdersProvider(IRepository<OrderEntity> ordersRepository, IMapper mapper) : IProvider<OrderModel, OrdersModelFilter>
    {
        private readonly IRepository<OrderEntity> _repository = ordersRepository;
        private readonly IMapper _mapper = mapper;

        public IEnumerable<OrderModel> Get(OrdersModelFilter? modelFilter = null)
        {
            double? minOrderAmount = modelFilter?.MinOrderAmount;
            double? maxOrderAmount = modelFilter?.MaxOrderAmount;
            DateTime? minOrderTime = modelFilter?.MinOrderTime;
            DateTime? maxOrderTime = modelFilter?.MaxOrderTime;
            OrderStatus? status = modelFilter?.Status;

            var Orders = _repository.GetAll(Order => (
            (minOrderAmount == null || Order.OrderAmount >= minOrderAmount) &&
            (maxOrderAmount == null || Order.OrderAmount <= maxOrderAmount) &&
            (minOrderAmount == null || Order.OrderAmount >= minOrderAmount) &&
            (maxOrderAmount == null || Order.OrderAmount <= maxOrderAmount) &&
            (status == null || Order.Status == status)
            ));

            return _mapper.Map<IEnumerable<OrderModel>>(Orders);
        }

        public OrderModel GetInfo(Guid id)
        {
            return _mapper.Map<OrderModel>(Find(id));
        }

        private OrderEntity Find(Guid id)
        {
            return _repository.GetById(id) ?? throw new InvalidOperationException($"Order with ID {id} not found.");
        }
    }
}
