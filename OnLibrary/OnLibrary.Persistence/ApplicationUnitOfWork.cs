using Microsoft.EntityFrameworkCore;
using OnLibrary.Application;

namespace OnLibrary.Persistence
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ApplicationUnitOfWork(IApplicationDbContext dbContext) : base((DbContext) dbContext)
        {

        }
    }
}
