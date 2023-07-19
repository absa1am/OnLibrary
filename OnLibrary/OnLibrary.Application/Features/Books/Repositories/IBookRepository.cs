using OnLibrary.Domain.Entities;
using OnLibrary.Domain.Repositories;
using System.Linq.Expressions;

namespace OnLibrary.Application.Features.Books.Repositories
{
    public interface IBookRepository : IRepositoryBase<Book, Guid>
    {
        Task<(IList<Book> records, int total, int totalDisplay)> GetTableDataAsync(Expression<Func<Book, bool>> predicate, string orderBy, int pageIndex, int pageSize);
    }
}
