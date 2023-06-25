using OnLibrary.Application;
using OnLibrary.Application.Features.Publications.Services;

namespace OnLibrary.Infrastructure.Features.Publications.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public PublicationService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
