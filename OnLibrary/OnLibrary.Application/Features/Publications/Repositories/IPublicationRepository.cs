using OnLibrary.Domain.Entities;
using OnLibrary.Domain.Repositories;

namespace OnLibrary.Application.Features.Publications.Repositories
{
    public interface IPublicationRepository : IRepositoryBase<Publication, Guid>
    {
    }
}
