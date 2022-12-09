using dotnet_GraphQL.DataAccess.Models;

namespace dotnet_GraphQL.GraphQL
{
    //GraphQL is not depend on any language so we need to define that types which we would like to expose.
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
