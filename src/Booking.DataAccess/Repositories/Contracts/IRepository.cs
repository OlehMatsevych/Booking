using Booking.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Booking.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity: BaseEntity
    {
        Task<TEntity> GetByIdAsync<T>(T id);
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity,bool>> predicate);
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity,object>>[] includes);
    }
}
