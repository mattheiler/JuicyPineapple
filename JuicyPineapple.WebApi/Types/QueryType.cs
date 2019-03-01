using HotChocolate.Types;

namespace JuicyPineapple.WebApi.Types
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor
                .Field(query => query.GetOrganization(default))
                .Type<OrganizationType>()
                .Argument("id", arg => arg.Type<UuidType>());

            descriptor
                .Field(query => query.GetOrganizations())
                .Type<ListType<OrganizationType>>();
            //.UsePaging<OrganizationType>();

            descriptor
                .Field(query => query.GetUser(default))
                .Type<UserType>()
                .Argument("id", arg => arg.Type<UuidType>());

            descriptor
                .Field(query => query.GetUsers())
                .Type<ListType<UserType>>();
            //.UsePaging<UserType>();
        }
    }
}