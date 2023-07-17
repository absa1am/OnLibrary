using OnLibrary.Application;
using OnLibrary.Application.Features.Books.Services;
using OnLibrary.Domain.Entities;

namespace OnLibrary.Infrastructure.Features.Books.Services
{
    public class BookService : IBookService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public BookService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateBook(string title, string author, string publication, string genre)
        {
            var book = new Book
            {
                Title = title,
                Author = author,
                Publication = publication,
                Genre = genre
            };

            _unitOfWork.Books.Add(book);
            _unitOfWork.Save();
        }

        public Book GetBooks(Guid id)
        {
            return _unitOfWork.Books.Get(id);
        }

        public void UpdateBook(Guid id, string title, string author, string publication, string genre)
        {
            var book = _unitOfWork.Books.Get(id);

            book.Title = title;
            book.Author = author;
            book.Publication = publication;
            book.Genre = genre;

            _unitOfWork.Save();
        }
    }
}
