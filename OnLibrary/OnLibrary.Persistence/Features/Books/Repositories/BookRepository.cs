using Microsoft.EntityFrameworkCore;
using OnLibrary.Application.Features.Books.Repositories;
using OnLibrary.Domain.Entities;

namespace OnLibrary.Persistence.Features.Books.Repositories
{
    public class BookRepository : Repository<Book, Guid>, IBookRepository
    {
        public BookRepository(IApplicationDbContext dbContext) : base((DbContext) dbContext)
        {
            
        }
    }
}
