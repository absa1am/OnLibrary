using OnLibrary.Application.Features.Authors.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnLibrary.Web.Areas.Admin.Models.Authors
{
    public class CreateAuthorModel
    {
        private IAuthorService _authorService;

        [Required]
        [DisplayName("Author Name")]
        public string Name { get; set; }
        [Required, EmailAddress]
        [DisplayName("Author Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Author Address")]
        public string Address { get; set; }

        public CreateAuthorModel() { }
        public CreateAuthorModel(IAuthorService authorService)
        {
            _authorService = authorService;
        }
    }
}
