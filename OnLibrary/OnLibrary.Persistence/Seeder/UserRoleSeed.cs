using OnLibrary.Persistence.Features.Membership;

namespace OnLibrary.Persistence.Seeder
{
    public static class UserRoleSeed
    {
        public static IList<ApplicationUserRole> UserRole()
        {
            return new List<ApplicationUserRole>
            {
                new ApplicationUserRole
                {
                    UserId = new Guid("E26967F0-CE4C-4C14-8A0B-45BEB8C9EB48"),
                    RoleId = new Guid("6505EC93-B8EE-418B-A3D7-13FC3E3FFC96")
                },
                new ApplicationUserRole
                {
                    UserId = new Guid("5F4C76D3-79B0-4923-86A7-511AC60C2AB9"),
                    RoleId = new Guid("459A979D-8358-4EBB-9758-D8AA35D7C7FF")
                }
            };
        }
    }
}
