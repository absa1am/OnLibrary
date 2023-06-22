using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using OnLibrary.Domain.Entities;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OnLibrary.Persistence
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TKey : IComparable where TEntity : class, IEntity<TKey>
    {
        protected DbContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (predicate != null)
                query = _dbSet.Where(predicate);

            return query.Count();
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (predicate != null)
                query = _dbSet.Where(predicate);

            return await query.CountAsync();
        }

        public virtual void Edit(TEntity entityToEdit)
        {
            _dbSet.Attach(entityToEdit);
            _dbContext.Entry(entityToEdit).State = EntityState.Modified;
        }

        public virtual async Task EditAsync(TEntity entityToEdit)
        {
            await Task.Run(() =>
            {
                _dbSet.Attach(entityToEdit);
                _dbContext.Entry(entityToEdit).State = EntityState.Modified;
            });
        }

        public virtual TEntity Get(TKey id)
        {
            return _dbSet.Find(id);
        }

        public virtual IList<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _dbSet;

            return query.ToList();
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            IQueryable<TEntity> query = _dbSet;

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual (IList<TEntity> data, int total, int totalDisplay) GetDynamic(Expression<Func<TEntity, bool>> predicate = null,
            string orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false)
        {
            IQueryable<TEntity> query = _dbSet;
            var total = query.Count();
            var totalDisplay = total;
            var skipSize = (pageIndex - 1) * pageSize;

            if (predicate != null)
            {
                query = query.Where(predicate);
                totalDisplay = query.Count();
            }

            if (include != null)
                query = include(query);

            if (orderBy != null)
            {
                var result = query.OrderBy(orderBy).Skip(skipSize).Take(pageSize);

                if (isTrackingOff)
                    return (result.AsNoTracking().ToList(), total, totalDisplay);

                return (result.ToList(), total, totalDisplay);
            }
            else
            {
                var result = query.Skip(skipSize).Take(pageSize);

                if (isTrackingOff)
                    return (result.AsNoTracking().ToList(), total, totalDisplay);

                return (result.ToList(), total, totalDisplay);
            }
        }

        public virtual async Task<(IList<TEntity> data, int total, int totalDisplay)> GetDynamicAsync(Expression<Func<TEntity, bool>> predicate = null,
            string orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false)
        {
            IQueryable<TEntity> query = _dbSet;
            var total = query.Count();
            var totalDisplay = total;
            var skipSize = (pageIndex - 1) * pageSize;

            if (predicate != null)
            {
                query = query.Where(predicate);
                totalDisplay = query.Count();
            }

            if (include != null)
                query = include(query);

            IList<TEntity> data;

            if (orderBy != null)
            {
                var result = query.OrderBy(orderBy).Skip(skipSize).Take(pageSize);

                if (isTrackingOff)
                    data = await result.AsNoTracking().ToListAsync();
                else data = await result.ToListAsync();
            }
            else
            {
                var result = query.Skip(skipSize).Take(pageSize);

                if (isTrackingOff)
                    data = await result.AsNoTracking().ToListAsync();
                else data = await result.ToListAsync();
            }

            return (data, total, totalDisplay);
        }

        public virtual void Remove(TEntity entityToRemove)
        {
            if (_dbContext.Entry(entityToRemove).State == EntityState.Detached)
                _dbSet.Attach(entityToRemove);

            _dbSet.Remove(entityToRemove);
        }

        public virtual void Remove(TKey id)
        {
            var entityToRemove = _dbSet.Find(id);

            Remove(entityToRemove);
        }

        public virtual void Remove(Expression<Func<TEntity, bool>> predicate)
        {
            var entitiesToRemove = _dbSet.Where(predicate);

            _dbSet.RemoveRange(entitiesToRemove);
        }

        public virtual async Task RemoveAsync(TEntity entityToRemove)
        {
            await Task.Run(() =>
            {
                if (_dbContext.Entry(entityToRemove).State == EntityState.Detached)
                    _dbSet.Attach(entityToRemove);

                _dbSet.Remove(entityToRemove);
            });
        }

        public virtual async Task RemoveAsync(TKey id)
        {
            var entityToRemove = _dbSet.Find(id);

            await RemoveAsync(entityToRemove);
        }

        public virtual async Task RemoveAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entitiesToRemove = _dbSet.Where(predicate);

            await Task.Run(() =>
            {
                _dbSet.RemoveRange(entitiesToRemove);
            });
        }
    }
}
