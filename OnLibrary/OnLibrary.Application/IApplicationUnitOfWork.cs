using OnLibrary.Application.Features.Publications.Repositories;
using OnLibrary.Domain.UnitOfWorks;

namespace OnLibrary.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IPublicationRepository Publications { get; set; }
    }
}
