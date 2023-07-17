using Autofac;
using OnLibrary.Web.Areas.Admin.Models.Books;
using OnLibrary.Web.Areas.Admin.Models.Roles;
using OnLibrary.Web.Models;

namespace OnLibrary.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Login - Registration
            builder.RegisterType<RegisterModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<LoginModel>().AsSelf().InstancePerLifetimeScope();

            // Role
            builder.RegisterType<CreateRoleModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<AssignRoleModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ViewRoleModel>().AsSelf().InstancePerLifetimeScope();

            // Book
            builder.RegisterType<CreateBookModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UpdateBookModel>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
