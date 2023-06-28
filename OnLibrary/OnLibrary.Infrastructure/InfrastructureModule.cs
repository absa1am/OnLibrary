using Autofac;
using OnLibrary.Application.Features.Authors.Services;
using OnLibrary.Application.Features.Books.Services;
using OnLibrary.Application.Features.Publications.Services;
using OnLibrary.Infrastructure.Features.Authors.Services;
using OnLibrary.Infrastructure.Features.Books.Services;
using OnLibrary.Infrastructure.Features.Publications.Services;

namespace OnLibrary.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookService>()
                .As<IBookService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AuthorService>()
                .As<IAuthorService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PublicationService>()
                .As<IPublicationService>()
                .InstancePerLifetimeScope();
        }
    }
}
