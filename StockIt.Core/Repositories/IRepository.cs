namespace StockIt.Core.Repositories
{
    public interface IRepository<T>
    {
        T AddAsync(T t, string tenant);
        bool DeleteAsync(T t, string tenant);
        T UpdateAsync(T t, string tenant);
    }
}
