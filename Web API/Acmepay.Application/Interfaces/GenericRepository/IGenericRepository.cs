using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.Application.Interfaces.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetPagedResponseAsync(int pageNumber, int pageSize);
        Task<T> GetByGuidAsync(Guid id);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        IQueryable<T> IncludeAll();
    }
}