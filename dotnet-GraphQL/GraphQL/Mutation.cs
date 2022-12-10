using dotnet_GraphQL.DataAccess;
using dotnet_GraphQL.DataAccess.Models;
using HotChocolate.Subscriptions;

namespace dotnet_GraphQL.GraphQL
{
    //This class is to allow clients to add, remove or modify.
    public class Mutation
    {
        public async Task<Author> CreateAuthor([Service] IAuthorRepository authorRepository, [Service] ITopicEventSender eventSender, int id, string firstName, string lastName)
        {
            Author author = new ()
            {
                FirstName = firstName,
                LastName = lastName,
                Id = id
            };

            var result = await authorRepository.Create(author);
            await eventSender.SendAsync("AuthorCreated", result);

            return result;
        }
    }
}
