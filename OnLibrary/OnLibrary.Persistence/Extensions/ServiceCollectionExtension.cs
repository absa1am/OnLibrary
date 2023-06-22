using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace OnLibrary.Persistence.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddIdentity(this IServiceCollection service)
        {
            service.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }
}
