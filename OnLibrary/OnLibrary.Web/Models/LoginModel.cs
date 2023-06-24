using System.ComponentModel.DataAnnotations;

namespace OnLibrary.Web.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me ?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
