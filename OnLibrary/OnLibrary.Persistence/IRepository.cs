using Microsoft.EntityFrameworkCore.Query;
using OnLibrary.Domain.Entities;
using OnLibrary.Domain.Repositories;
using System.Linq.Expressions;

namespace OnLibrary.Persistence
{
    public interface IRepository<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : IComparable
    {
        (IList<TEntity> data, int total, int totalDisplay) GetDynamic(Expression<Func<TEntity, bool>> predicate = null,
            string orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        Task<(IList<TEntity> data, int total, int totalDisplay)> GetDynamicAsync(Expression<Func<TEntity, bool>> predicate = null,
            string orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);
    }
}
