using Api.Models.Models.Entities;
using Application.Models;
using System.Collections.Generic;

namespace Api.Repository.Interfaces
{
    public interface IServiceUser
    {
        User Get(string email, string password);
        IList<User> GetAll();
        User GetByEmail(string email);
        User GetById(int id);
        User FirstStepRecover(string email);
        User SecondStepRecover(Recover rec);

        User NewUser(User user);

    }
}
