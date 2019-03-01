using HotChocolate.Types;
using JuicyPineapple.Core;

namespace JuicyPineapple.WebApi.Config
{
    internal class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(user => user.Id).Type<UuidType>();
            descriptor.Field(user => user.Name).Type<StringType>();
            // descriptor.Field(user => user.Organizations).Type<ListType<OrganizationMembershipType>>();
        }
    }
}