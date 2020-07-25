using Api.Models.Models.Entities;
using Api.Repository.Interfaces;
using Application.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.Services
{
    public class UserService : IServiceUser
    {
        private readonly ApiContext _context;

        public UserService(ApiContext context)
        {
            _context = context;
        }

        public dynamic Create(User model)
        {
            try
            {
                _context.Users.Add(model);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return _context.Users.FirstOrDefault(f => f.Email == model.Email && f.Password == model.Password);
        }

        public User Get(string email, string password)
        {
            return _context.Users.FirstOrDefault(f => f.Email == email && f.Password == password);
        }

        public IList<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(w => w.Email == email);
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public User FirstStepRecover(string email)
        {
            var user = _context.Users.FirstOrDefault(f => f.Email == email);
            
            if (user != null)
                user.Password = "";

            return user;
        }

        public User SecondStepRecover(Recover rec)
        {

            _context.Users.Find(rec.id).Password = rec.password;

            _context.SaveChanges();

            return _context.Users.Find(rec.id);
        }
    }
}
