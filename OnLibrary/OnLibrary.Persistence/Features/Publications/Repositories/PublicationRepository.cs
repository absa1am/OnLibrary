using Microsoft.EntityFrameworkCore;
using OnLibrary.Application.Features.Publications.Repositories;
using OnLibrary.Domain.Entities;

namespace OnLibrary.Persistence.Features.Publications.Repositories
{
    public class PublicationRepository : Repository<Publication, Guid>, IPublicationRepository
    {
        public PublicationRepository(IApplicationDbContext dbContext) : base((DbContext) dbContext)
        {

        }
    }
}
