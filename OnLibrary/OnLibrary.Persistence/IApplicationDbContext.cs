using Microsoft.EntityFrameworkCore;
using OnLibrary.Domain.Entities;

namespace OnLibrary.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Publication> Publications { get; set; }
    }
}
