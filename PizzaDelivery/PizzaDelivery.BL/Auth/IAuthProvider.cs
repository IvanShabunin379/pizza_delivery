using PizzaDelivery.BL.Auth.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.BL.Auth
{
    public interface IAuthProvider
    {
        Task<TokensResponse> AuthorizeUser(string email, string password);
        Task RegisterUser(string name, string surname, string email, string password);
    }
}
