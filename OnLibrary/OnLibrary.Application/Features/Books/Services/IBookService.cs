using OnLibrary.Domain.Entities;

namespace OnLibrary.Application.Features.Books.Services
{
    public interface IBookService
    {
        void CreateBook(string title, string author, string publication, string genre);
        Book GetBooks(Guid id);
        void UpdateBook(Guid id, string title, string author, string publication, string genre);
    }
}
