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

        public bool IsDuplicateName(Guid? id, string name)
        {
            int? records = null;

            if (id.HasValue) records = Count(p => p.Id == id.Value && p.Name == name);
            else records = Count(p => p.Name == name);

            return records > 0;
        }
    }
}
