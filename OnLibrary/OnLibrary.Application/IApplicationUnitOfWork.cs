using OnLibrary.Application.Features.Authors.Repositories;
using OnLibrary.Application.Features.Books.Repositories;
using OnLibrary.Application.Features.Publications.Repositories;
using OnLibrary.Domain.UnitOfWorks;

namespace OnLibrary.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IAuthorRepository Authors { get; set; }
        IBookRepository Books { get; set; }
        IPublicationRepository Publications { get; set; }
    }
}
