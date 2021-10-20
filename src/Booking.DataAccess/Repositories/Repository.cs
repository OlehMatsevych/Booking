using Booking.Core.Common;
using Booking.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private BookingContext Context;
        public Repository(BookingContext context)
        {
            Context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public Task DeleteAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            return Context.SaveChangesAsync();
        }
        public Task UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()=>
            await Context.Set<TEntity>().ToListAsync();
        
        public async Task<TEntity> GetByIdAsync(int id)=>
            await Context.Set<TEntity>().FindAsync(id);
        //TODO: params
        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate)=>
             Context.Set<TEntity>().Where(predicate).AsQueryable();

        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = Context.Set<TEntity>().AsQueryable();
            return includes.Aggregate(query, (q, w) => q.Include(w));
        }
    }
}
