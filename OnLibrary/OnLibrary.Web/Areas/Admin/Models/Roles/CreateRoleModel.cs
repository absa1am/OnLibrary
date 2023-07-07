using Autofac;
using Microsoft.AspNetCore.Identity;
using OnLibrary.Persistence.Features.Membership;
using System.ComponentModel.DataAnnotations;

namespace OnLibrary.Web.Areas.Admin.Models.Roles
{
    public class CreateRoleModel
    {
        [Required]
        public string Name { get; set; }

        private RoleManager<ApplicationRole> _roleManager { get; set; }
        private UserManager<ApplicationUser> _userManager { get; set; }

        public CreateRoleModel() { }

        public CreateRoleModel(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _roleManager = scope.Resolve<RoleManager<ApplicationRole>>();
            _userManager = scope.Resolve<UserManager<ApplicationUser>>();
        }

        internal async Task CreateRole()
        {
            if (!string.IsNullOrWhiteSpace(Name))
                await _roleManager.CreateAsync(new ApplicationRole(Name));
        }
    }
}
