using Microsoft.EntityFrameworkCore;
using OnLibrary.Application.Features.Authors.Repositories;
using OnLibrary.Domain.Entities;

namespace OnLibrary.Persistence.Features.Authors.Repositories
{
    public class AuthorRepository : Repository<Author, Guid>, IAuthorRepository
    {
        public AuthorRepository(IApplicationDbContext dbContext) : base((DbContext) dbContext)
        {

        }
    }
}
