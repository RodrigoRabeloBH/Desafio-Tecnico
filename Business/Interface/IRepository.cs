using Domain;
using System.Collections.Generic;

namespace Business.Interface
{
    public interface IRepository<T> where T : Entity
    {
        void Create(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        List<T> GetAll();        
        T GetById(int id);
    }
}
