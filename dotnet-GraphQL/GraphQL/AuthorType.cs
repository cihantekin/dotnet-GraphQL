using dotnet_GraphQL.DataAccess.Models;

namespace dotnet_GraphQL.GraphQL
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Field(f => f.Id).Type<IdType>();
            descriptor.Field(f => f.FirstName).Type<StringType>();
            descriptor.Field(f => f.LastName).Type<StringType>();
        }
    }
}
