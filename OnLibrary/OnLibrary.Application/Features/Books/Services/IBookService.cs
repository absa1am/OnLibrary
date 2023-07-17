namespace OnLibrary.Application.Features.Books.Services
{
    public interface IBookService
    {
        void CreateBook(string title, string author, string publication, string genre);
    }
}
