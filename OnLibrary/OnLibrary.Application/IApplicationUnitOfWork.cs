using OnLibrary.Application.Features.Books.Repositories;
using OnLibrary.Domain.UnitOfWorks;

namespace OnLibrary.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IBookRepository Books { get; set; }
    }
}
