using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnLibrary.Domain.Entities;
using OnLibrary.Persistence.Features.Membership;
using OnLibrary.Persistence.Seeder;

namespace OnLibrary.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
        ApplicationRole, Guid, ApplicationUserClaim, ApplicationUserRole,
        ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>, IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public ApplicationDbContext(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, option => option.MigrationsAssembly(_migrationAssembly));
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasData(UserSeed.Users());
            builder.Entity<ApplicationRole>().HasData(RoleSeed.Roles());
            builder.Entity<ApplicationUserRole>().HasData(UserRoleSeed.UserRole());
        }

        public DbSet<Book> Books { get; set; }
    }
}
