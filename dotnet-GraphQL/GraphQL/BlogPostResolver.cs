using dotnet_GraphQL.DataAccess;
using dotnet_GraphQL.DataAccess.Models;
using HotChocolate.Resolvers;

namespace dotnet_GraphQL.GraphQL
{
    public class BlogPostResolver
    {
        private readonly IBlogRepository _blogRepository;

        public BlogPostResolver(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public IEnumerable<BlogPost> GetBlogPosts(Author author, IResolverContext ctx)
        {
            return _blogRepository.GetList().Where(b => b.AuthorId == author.Id);
        }
    }
}
