using OnLibrary.Domain.Entities;

namespace OnLibrary.Application.Features.Books.Services
{
    public interface IBookService
    {
        void CreateBook(string title, string author, string publication, string genre);
        void DeleteBook(Guid id);
        Book GetBooks(Guid id);
        Task<(IList<Book> records, int total, int totalDisplay)> GetPagedBooksAsync(int pageIndex, int pageSize, string searchText, string orderBy);
        void UpdateBook(Guid id, string title, string author, string publication, string genre);
        
    }
}
