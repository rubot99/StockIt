using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockIt.Core.Repositories
{
    public interface IRepository<T>
    {
        T Add(T t);
        bool Delete(T t);
        T Update(T t);
        T Get(string id, string tenant);

        List<T> GetAll(string tenant);
    }
}
