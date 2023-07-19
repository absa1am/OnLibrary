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

        public void DeleteBook(Guid id)
        {
            _unitOfWork.Books.Remove(id);
            _unitOfWork.Save();
        }

        public Book GetBooks(Guid id)
        {
            return _unitOfWork.Books.Get(id);
        }

        public async Task<(IList<Book> records, int total, int totalDisplay)> GetPagedBooksAsync(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            var data = await _unitOfWork.Books.GetTableDataAsync(b => b.Title.Contains(searchText) || b.Author.Contains(searchText) || b.Publication.Contains(searchText) || b.Genre.Contains(searchText), orderBy, pageIndex, pageSize);

            return data;
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
