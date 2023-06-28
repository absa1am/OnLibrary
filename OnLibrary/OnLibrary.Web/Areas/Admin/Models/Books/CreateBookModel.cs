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
        [DisplayName("Book Genre")]
        public string Genre { get; set; }

        public CreateBookModel() { }
        public CreateBookModel(IBookService bookService)
        {
            _bookService = bookService;
        }
    }
}
