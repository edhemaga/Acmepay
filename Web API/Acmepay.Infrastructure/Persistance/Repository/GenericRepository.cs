using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acmepay.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using WMS.Application.Interfaces.GenericRepository;

namespace Acmepay.Infrastructure.Persistance.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _dbContext;

        public GenericRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByGuidAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext.Set<T>().Skip(pageNumber - 1).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual IQueryable<T> IncludeAll()
        {
            var query = _dbContext.Set<T>().AsQueryable();
            foreach (var property in _dbContext.Model.FindEntityType(typeof(T)).GetNavigations())
                query = query.Include(property.Name);
            return query;
        }
    }
}