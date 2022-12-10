using dotnet_GraphQL.DataAccess;
using dotnet_GraphQL.DataAccess.Models;
using HotChocolate.Subscriptions;

namespace dotnet_GraphQL.GraphQL
{
    // This class is to fetch author and blog related data
    public class Query
    {
        public async Task<List<Author>> GetAllAuthors([Service] IAuthorRepository authorRepository, [Service] ITopicEventSender eventSender)
        {
            var authors = authorRepository.GetList();
            await eventSender.SendAsync("ReturnedAuthors", authors);
            return authors;
        }

        public async Task<Author> GetAuthorById([Service] IAuthorRepository authorRepository, [Service] ITopicEventSender eventSender, int id)
        {
            Author author = authorRepository.GetById(id);
            await eventSender.SendAsync("ReturnedAuthor", author);
            return author;
        }

        public async Task<List<BlogPost>>
        GetAllBlogPosts([Service] IBlogRepository blogPostRepository, [Service] ITopicEventSender eventSender)
        {
            List<BlogPost> blogPosts = blogPostRepository.GetList();
            await eventSender.SendAsync("ReturnedBlogPosts", blogPosts);
            return blogPosts;
        }
        public async Task<BlogPost> GetBlogPostById([Service] IBlogRepository blogPostRepository, [Service] ITopicEventSender eventSender, int id)
        {
            BlogPost blogPost = blogPostRepository.GetById(id);
            await eventSender.SendAsync("ReturnedBlogPost", blogPost);
            return blogPost;
        }
    }
}
