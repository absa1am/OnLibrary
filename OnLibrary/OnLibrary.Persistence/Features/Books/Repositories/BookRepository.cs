using Microsoft.EntityFrameworkCore;
using OnLibrary.Application.Features.Books.Repositories;
using OnLibrary.Domain.Entities;
using System.Linq.Expressions;

namespace OnLibrary.Persistence.Features.Books.Repositories
{
    public class BookRepository : Repository<Book, Guid>, IBookRepository
    {
        public BookRepository(IApplicationDbContext dbContext) : base((DbContext) dbContext)
        {
            
        }

        public async Task<(IList<Book> records, int total, int totalDisplay)> GetTableDataAsync(Expression<Func<Book, bool>> predicate, string orderBy, int pageIndex, int pageSize)
        {
            var data = await GetDynamicAsync(predicate, orderBy, null, pageIndex, pageSize);

            return data;
        }
    }
}
