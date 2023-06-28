using Microsoft.EntityFrameworkCore;
using OnLibrary.Application;
using OnLibrary.Application.Features.Authors.Repositories;
using OnLibrary.Application.Features.Books.Repositories;
using OnLibrary.Application.Features.Publications.Repositories;

namespace OnLibrary.Persistence
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IBookRepository Books { get; set; }
        public IAuthorRepository Authors { get; set; }
        public IPublicationRepository Publications { get; set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext, IBookRepository bookRepository, IAuthorRepository authorRepository, IPublicationRepository publicationRepository) : base((DbContext) dbContext)
        {
            Books = bookRepository;
            Authors = authorRepository;
            Publications = publicationRepository;
        }
    }
}
