using Microsoft.EntityFrameworkCore;
using OnLibrary.Application;
using OnLibrary.Application.Features.Books.Repositories;

namespace OnLibrary.Persistence
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IBookRepository Books { get; set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext, IBookRepository bookRepository) : base((DbContext) dbContext)
        {
            Books = bookRepository;
        }
    }
}
