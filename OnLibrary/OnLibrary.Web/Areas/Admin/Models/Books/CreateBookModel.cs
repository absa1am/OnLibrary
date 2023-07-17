using Autofac;
using OnLibrary.Application.Features.Books.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnLibrary.Web.Areas.Admin.Models.Books
{
    public class CreateBookModel
    {
        private IBookService _bookService;

        [Required]
        [DisplayName("Book Title")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Author Name")]
        public string Author { get; set; }
        [Required]
        [DisplayName("Publication")]
        public string Publication { get; set; }
        [Required]
        [DisplayName("Book Genre")]
        public string Genre { get; set; }

        public CreateBookModel() { }
        public CreateBookModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _bookService = scope.Resolve<IBookService>();
        }

        internal void CreateBook()
        {
            if (!string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Author) && !string.IsNullOrWhiteSpace(Publication) && !string.IsNullOrWhiteSpace(Genre))
                _bookService.CreateBook(Title, Author, Publication, Genre);
        }
    }
}
