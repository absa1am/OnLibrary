using Autofac;
using OnLibrary.Web.Areas.Admin.Models.Authors;
using OnLibrary.Web.Areas.Admin.Models.Books;
using OnLibrary.Web.Areas.Admin.Models.Publications;
using OnLibrary.Web.Models;

namespace OnLibrary.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<LoginModel>().AsSelf().InstancePerLifetimeScope();

            // Book
            builder.RegisterType<CreateBookModel>().AsSelf().InstancePerLifetimeScope();

            // Author
            builder.RegisterType<CreateAuthorModel>().AsSelf().InstancePerLifetimeScope();

            // Publications
            builder.RegisterType<CreatePublicationModel>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
