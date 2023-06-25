using Microsoft.EntityFrameworkCore;
using OnLibrary.Domain.Entities;

namespace OnLibrary.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Publication> Publications { get; set; }
    }
}
