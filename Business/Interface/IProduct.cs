using Domain;
using System.Collections.Generic;

namespace Business.Interface
{
    public interface IProduct : IRepository<Product>
    {
        List<Product> GetByName(string name);
    }
}
