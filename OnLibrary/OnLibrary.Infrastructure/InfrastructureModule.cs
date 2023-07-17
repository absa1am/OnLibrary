using Autofac;
using OnLibrary.Application.Features.Books.Services;
using OnLibrary.Infrastructure.Features.Books.Services;

namespace OnLibrary.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookService>()
                .As<IBookService>()
                .InstancePerLifetimeScope();
        }
    }
}
