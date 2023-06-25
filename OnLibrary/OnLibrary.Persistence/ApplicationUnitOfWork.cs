using Microsoft.EntityFrameworkCore;
using OnLibrary.Application;
using OnLibrary.Application.Features.Publications.Repositories;

namespace OnLibrary.Persistence
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IPublicationRepository Publications { get; set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext, IPublicationRepository publicationRepository) : base((DbContext) dbContext)
        {
            Publications = publicationRepository;
        }
    }
}
