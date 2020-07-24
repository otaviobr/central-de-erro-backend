using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Repository.Interfaces
{
    public interface IService<T> where T : class
    {
        IList<T> GetAll();
        T GetById(int id);
    }
}
