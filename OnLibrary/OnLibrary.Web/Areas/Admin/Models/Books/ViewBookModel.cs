using OnLibrary.Application.Features.Books.Services;
using OnLibrary.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace OnLibrary.Web.Areas.Admin.Models.Books
{
    public class ViewBookModel
    {
        private IBookService _bookService;

        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publication { get; set; }
        [Required]
        public string Genre { get; set; }

        public ViewBookModel() { }

        public ViewBookModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        internal async Task<object> GetPagedBooksAsync(DataAjaxRequest dataTables)
        {
            var data = await _bookService.GetPagedBooksAsync(
                dataTables.PageIndex,
                dataTables.PageSize,
                dataTables.SearchText,
                dataTables.GetSortText(new string[] { "Title", "Author", "Publication", "Genre" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Title,
                            record.Author,
                            record.Publication,
                            record.Genre,
                            record.Id.ToString()
                        }).ToArray()
            };
        }

        internal void DeleteBook(Guid id)
        {
            _bookService.DeleteBook(id);
        }
    }
}
