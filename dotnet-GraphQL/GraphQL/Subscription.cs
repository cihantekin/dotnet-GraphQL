using dotnet_GraphQL.DataAccess.Models;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace dotnet_GraphQL.GraphQL
{
    // using with that class GraphQL notify subscribers in real time when an event occurs.
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Author>> OnAuthorCreated([Service] ITopicEventReceiver topicEventReceiver, CancellationToken cancellationToken= default)
        {
            return await topicEventReceiver.SubscribeAsync<Author>("AuthorCreated", null, null, cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<List<Author>>> OnAuthorsGet([Service] ITopicEventReceiver topicEventReceiver, CancellationToken cancellationToken = default)
        {
            return await topicEventReceiver.SubscribeAsync<List<Author>>("ReturnedAuthors", null, null, cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Author>> OnAuthorGet([Service] ITopicEventReceiver topicEventReceiver, CancellationToken cancellationToken = default)
        {
            return await topicEventReceiver.SubscribeAsync<Author>("ReturnedAuthor", null, null, cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<List<BlogPost>>> OnBlogPostsGet([Service] ITopicEventReceiver topicEventReceiver, CancellationToken cancellationToken = default)
        {
            return await topicEventReceiver.SubscribeAsync<List<BlogPost>>("ReturnedBlogPosts", null, null, cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<BlogPost>> OnBlogPostGet([Service] ITopicEventReceiver topicEventReceiver, CancellationToken cancellationToken = default)
        {
            return await topicEventReceiver.SubscribeAsync<BlogPost>("ReturnedBlogPost", null, null, cancellationToken);
        }
    }
}
