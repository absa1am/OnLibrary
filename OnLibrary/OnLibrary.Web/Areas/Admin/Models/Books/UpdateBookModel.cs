using Autofac;
using AutoMapper;
using OnLibrary.Application.Features.Books.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnLibrary.Web.Areas.Admin.Models.Books
{
    public class UpdateBookModel
    {
        private IMapper _mapper;
        private IBookService _bookService;

        [Required]
        public Guid Id { get; set; }
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

        public UpdateBookModel() { }
        public UpdateBookModel(IBookService bookService, IMapper mapper)
        {
            _mapper = mapper;
            _bookService = bookService;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _mapper = scope.Resolve<IMapper>();
            _bookService = scope.Resolve<IBookService>();
        }

        internal void UpdateBook()
        {
            if (!string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Author) && !string.IsNullOrWhiteSpace(Publication) && !string.IsNullOrWhiteSpace(Genre))
                _bookService.UpdateBook(Id, Title, Author, Publication, Genre);
        }

        internal void Load(Guid id)
        {
            var book = _bookService.GetBooks(id);

            if (book != null) _mapper.Map(book, this);
        }
    }
}
