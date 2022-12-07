using dotnet_GraphQL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_GraphQL.DataAccess
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public AuthorRepository(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using var _applicationDbContext = _dbContextFactory.CreateDbContext();
            _applicationDbContext.Database.EnsureCreated();
        }

        public async Task<Author> Create(Author author)
        {
            using var applicationDbContext = _dbContextFactory.CreateDbContext();
            await applicationDbContext.Authors.AddAsync(author);
            await applicationDbContext.SaveChangesAsync();
            return author;
        }

        public Author GetById(int id)
        {
            using var applicationDbContext = _dbContextFactory.CreateDbContext();
            return applicationDbContext.Authors.SingleOrDefault(x => x.Id == id);
        }

        public List<Author> GetList()
        {
            using var applicationDbContext = _dbContextFactory.CreateDbContext();
            return applicationDbContext.Authors.ToList();
        }
    }
}
