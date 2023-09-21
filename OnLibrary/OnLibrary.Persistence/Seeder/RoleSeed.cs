using OnLibrary.Persistence.Features.Membership;

namespace OnLibrary.Persistence.Seeder
{
    public static class RoleSeed
    {
        public static IList<ApplicationRole> Roles()
        {
            return new List<ApplicationRole>
            {
                new ApplicationRole
                {
                    Id = new Guid("6505EC93-B8EE-418B-A3D7-13FC3E3FFC96"),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "6505EC93-B8EE-418B-A3D7-13FC3E3FFC96"
                },
                new ApplicationRole
                {
                    Id = new Guid("459A979D-8358-4EBB-9758-D8AA35D7C7FF"),
                    Name = "Manager",
                    NormalizedName = "MANAGER",
                    ConcurrencyStamp = "459A979D-8358-4EBB-9758-D8AA35D7C7FF"
                },
                new ApplicationRole
                {
                    Id = new Guid("0E7949B4-0A2B-43F7-9DDC-E8822A4B60C0"),
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "0E7949B4-0A2B-43F7-9DDC-E8822A4B60C0"
                }
            };
        }
    }
}
