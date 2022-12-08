using dotnet_GraphQL.DataAccess.Models;

namespace dotnet_GraphQL.GraphQL
{
    public class BlogPostType : ObjectType<BlogPost>
    {
        protected override void Configure(IObjectTypeDescriptor<BlogPost> descriptor)
        {
            descriptor.Field(f => f.Id).Type<IdType>();
            descriptor.Field(f => f.Title).Type<StringType>();
            descriptor.Field(f => f.AuthorId).Type<IdType>();
        }
    }
}
