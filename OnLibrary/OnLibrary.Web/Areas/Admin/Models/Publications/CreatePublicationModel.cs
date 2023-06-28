using Autofac;
using OnLibrary.Application.Features.Publications.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnLibrary.Web.Areas.Admin.Models.Publications
{
    public class CreatePublicationModel
    {
        private IPublicationService _publicationService;

        [Required]
        [DisplayName("Publication Name")]
        public string Name { get; set; }
        [Required, EmailAddress]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        public CreatePublicationModel() { }

        public CreatePublicationModel(IPublicationService publicationService)
        {
            _publicationService = publicationService;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _publicationService = scope.Resolve<IPublicationService>();
        }

        internal void CreatePublication()
        {
            if (!string.IsNullOrWhiteSpace(Name))
                _publicationService.CreatePublication(Name, Email);
        }
    }
}
