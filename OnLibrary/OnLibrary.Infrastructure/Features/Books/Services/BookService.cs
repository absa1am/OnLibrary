using OnLibrary.Application;
using OnLibrary.Application.Features.Books.Services;

namespace OnLibrary.Infrastructure.Features.Books.Services
{
    public class BookService : IBookService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public BookService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
