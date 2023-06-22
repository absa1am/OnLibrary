using Microsoft.EntityFrameworkCore;
using OnLibrary.Domain.UnitOfWorks;

namespace OnLibrary.Persistence
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void Dispose()
        {
            _dbContext?.Dispose();
        }

        public async virtual Task DisposeAsync()
        {
            _dbContext?.DisposeAsync();
        }

        public virtual void Save()
        {
            _dbContext?.SaveChanges();
        }

        public virtual async Task SaveAsync()
        {
            _dbContext?.SaveChangesAsync();
        }
    }
}
