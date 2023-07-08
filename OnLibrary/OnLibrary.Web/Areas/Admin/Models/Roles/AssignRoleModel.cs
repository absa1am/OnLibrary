using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnLibrary.Persistence.Features.Membership;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnLibrary.Web.Areas.Admin.Models.Roles
{
    public class AssignRoleModel
    {
        [Required]
        [DisplayName("User Email")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("User Role")]
        public string RoleName { get; set; }
        public List<SelectListItem>? Users { get; private set; }
        public List<SelectListItem>? Roles { get; private set; }

        private RoleManager<ApplicationRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;

        public AssignRoleModel() { }

        public AssignRoleModel(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _roleManager = scope.Resolve<RoleManager<ApplicationRole>>();
            _userManager = scope.Resolve<UserManager<ApplicationUser>>();
        }

        internal async Task LoadData()
        {
            Users = await (from user in _userManager.Users
                           select new SelectListItem(user.Email, user.UserName)).ToListAsync();

            Roles = await (from role in _roleManager.Roles
                           select new SelectListItem(role.Name, role.Name)).ToListAsync();
        }

        internal async Task AssignRole()
        {
            var user = await _userManager.FindByNameAsync(UserName);

            await _userManager.AddToRoleAsync(user, RoleName);
        }
    }
}
