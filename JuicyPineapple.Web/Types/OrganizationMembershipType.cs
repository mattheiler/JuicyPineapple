using HotChocolate.Types;
using JuicyPineapple.Core;

namespace JuicyPineapple.Web.Types
{
    public class OrganizationMembershipType : ObjectType<OrganizationMembership>
    {
        protected override void Configure(IObjectTypeDescriptor<OrganizationMembership> descriptor)
        {
            // descriptor.Field(membership => membership.Organization).Type<OrganizationType>();
            descriptor.Field(membership => membership.OrganizationId).Type<UuidType>();
            // descriptor.Field(membership => membership.User).Type<UserType>();
            descriptor.Field(membership => membership.UserId).Type<UuidType>();
        }
    }
}