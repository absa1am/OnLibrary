using OnLibrary.Application;
using OnLibrary.Application.Features.Publications.Services;
using OnLibrary.Domain.Entities;

namespace OnLibrary.Infrastructure.Features.Publications.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public PublicationService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreatePublication(string name)
        {
            if (_unitOfWork.Publications.IsDuplicateName(null, name))
                throw new Exception($"Publication name already exist.");

            var publication = new Publication { Name = name };

            _unitOfWork.Publications.Add(publication);
            _unitOfWork.Save();
        }
    }
}
