using dotnet_GraphQL.DataAccess;
using dotnet_GraphQL.DataAccess.Models;
using HotChocolate.Resolvers;

namespace dotnet_GraphQL.GraphQL
{
    // this class is value of a type in a schema
    public class AuthorResolver
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorResolver(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Author GetAuthor(BlogPost blog, IResolverContext resolverContext)
        {
            return _authorRepository.GetList().Where(s => s.Id == blog.AuthorId)?.FirstOrDefault();
        }
    }
}
