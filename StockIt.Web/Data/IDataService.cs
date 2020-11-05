using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockIt.Web.Data
{
    public interface IDataService<T>
    {
        Task<T> AddAsync(T t);

        Task<List<T>> GetAllAsync(string tenant);
    }
}
