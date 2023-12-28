using PizzaDelivery.BL.Users.Entities;
using PizzaDelivery.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PizzaDelivery.DataAccess.Repository;

namespace PizzaDelivery.BL.Users
{
    public class UsersManager(IRepository<UserEntity> usersRepository, IMapper mapper) : IManager<UserModel, CreateUserModel>
    {
        private readonly IRepository<UserEntity> _usersRepository = usersRepository;
        private readonly IMapper _mapper = mapper;

        public UserModel Create(CreateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);

            _usersRepository.Save(entity);

            return _mapper.Map<UserModel>(entity);
        }

        public UserModel Update(Guid id, UserModel model)
        {
            var user = Find(id);

            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.Orders = (ICollection<OrderEntity>?)model.Orders;
            user.IsAdmin = model.IsAdmin;

            _usersRepository.Save(user);

            return _mapper.Map<UserModel>(user);
        }

        public void Delete(Guid id)
        {
            _usersRepository.Delete(Find(id));
        }

        private UserEntity Find(Guid id)
        {
            return _usersRepository.GetById(id) ?? throw new InvalidOperationException($"User with ID {id} not found.");
        }
    }
}
