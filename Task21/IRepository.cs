using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepository<T> where T : IIdentifiable
{
    Task<T?> GetAsync(string id);
    Task<List<T>> GetAllAsync();
    Task AddAsync(T item);
    Task UpdateAsync(T item);
    Task DeleteAsync(string id);
    Task<List<T>> FilterAsync(Func<T, bool> condition);
}