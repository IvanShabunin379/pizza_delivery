using AutoMapper;

using PizzaDelivery.BL.Users.Entities;
using PizzaDelivery.WebAPI.Controllers.Entities.Users;
namespace Service.Mapper;

public class UsersServiceProfile : Profile
{
    public UsersServiceProfile()
    {
        CreateMap<UsersFilter, UsersModelFilter>();
        CreateMap<CreateUserRequest, CreateUserModel>();
        CreateMap<UpdateUserRequest, UpdateUserModel>();
    }
}
