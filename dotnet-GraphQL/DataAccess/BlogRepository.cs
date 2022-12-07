using dotnet_GraphQL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_GraphQL.DataAccess
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;
        public BlogRepository(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using var applicationDbContext = _dbContextFactory.CreateDbContext();
            applicationDbContext.Database.EnsureCreated();
        }
        public BlogPost GetById(int id)
        {
            using var applicationDbContext = _dbContextFactory.CreateDbContext();
            return applicationDbContext.BlogPosts.SingleOrDefault(x => x.Id == id);
        }

        public List<BlogPost> GetList()
        {
            using var applicationDbContext = _dbContextFactory.CreateDbContext();
            return applicationDbContext.BlogPosts.ToList();
        }
    }
}
