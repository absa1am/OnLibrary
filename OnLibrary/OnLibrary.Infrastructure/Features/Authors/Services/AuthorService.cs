using OnLibrary.Application;
using OnLibrary.Application.Features.Authors.Services;

namespace OnLibrary.Infrastructure.Features.Authors.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public AuthorService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
