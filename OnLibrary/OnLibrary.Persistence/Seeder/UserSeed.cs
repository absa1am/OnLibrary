using Microsoft.AspNetCore.Identity;
using OnLibrary.Persistence.Features.Membership;

namespace OnLibrary.Persistence.Seeder
{
    public static class UserSeed
    {
        public static IList<ApplicationUser> Users()
        {
            var passHasher = new PasswordHasher<ApplicationUser>();

            var admin = new ApplicationUser()
            {
                Id = new Guid("E26967F0-CE4C-4C14-8A0B-45BEB8C9EB48"),
                UserName = "admin@onlibrary.com",
                NormalizedUserName = "ADMIN@ONLIBRARY.COM",
                Email = "admin@onlibrary.com",
                NormalizedEmail = "ADMIN@ONLIBRARY.COM",
                EmailConfirmed = true,
                PhoneNumber = "+8801856817465",
                SecurityStamp = "BFCC7B453A8B4B6C8A4C93EE28A3B4A8",
                LockoutEnabled = true
            };

            admin.PasswordHash = passHasher.HashPassword(admin, "123456");

            var manager = new ApplicationUser()
            {
                Id = new Guid("5F4C76D3-79B0-4923-86A7-511AC60C2AB9"),
                UserName = "manager@onlibrary.com",
                NormalizedUserName = "MANAGER@ONLIBRARY.COM",
                Email = "manager@onlibrary.com",
                NormalizedEmail = "MANAGER@ONLIBRARY.COM",
                EmailConfirmed = true,
                PhoneNumber = "+8801856817465",
                SecurityStamp = "FC37C84E276C4D978DF9054129D0CB23",
                LockoutEnabled = true
            };

            manager.PasswordHash = passHasher.HashPassword(manager, "123456");

            return new List<ApplicationUser> { admin, manager };
        }
    }
}
