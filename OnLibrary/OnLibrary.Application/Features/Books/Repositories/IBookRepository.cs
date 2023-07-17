using OnLibrary.Domain.Entities;
using OnLibrary.Domain.Repositories;

namespace OnLibrary.Application.Features.Books.Repositories
{
    public interface IBookRepository : IRepositoryBase<Book, Guid>
    {
    }
}
