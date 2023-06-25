using Autofac;
using OnLibrary.Application.Features.Publications.Services;
using OnLibrary.Infrastructure.Features.Publications.Services;

namespace OnLibrary.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PublicationService>()
                .As<IPublicationService>()
                .InstancePerLifetimeScope();
        }
    }
}
