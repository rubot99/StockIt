﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockIt.Mvc.Services
{
    public interface IDataService<T>
    {
        Task<T> AddAsync(T t);
        Task<bool> DeleteAsync(string id);
        Task<bool> UpdateAsync(T t);
    }
}
