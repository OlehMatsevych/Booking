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
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetWhereAsync(Expression<Func<TEntity,bool>> predicate);
    }
}
