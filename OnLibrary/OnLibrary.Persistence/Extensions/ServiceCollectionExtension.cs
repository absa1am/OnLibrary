using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OnLibrary.Persistence.Features.Membership;

namespace OnLibrary.Persistence.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddIdentity(this IServiceCollection service)
        {
            service.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserManager<ApplicationUserManager>()
                .AddRoleManager<ApplicationRoleManager>()
                .AddSignInManager<ApplicationSignInManager>()
                .AddDefaultTokenProviders();
        }
    }
}
