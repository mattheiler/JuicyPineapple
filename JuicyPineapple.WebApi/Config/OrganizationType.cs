using HotChocolate.Types;
using JuicyPineapple.Core;

namespace JuicyPineapple.WebApi.Config
{
    internal class OrganizationType : ObjectType<Organization>
    {
        protected override void Configure(IObjectTypeDescriptor<Organization> descriptor)
        {
            descriptor.Field(organization => organization.Id).Type<UuidType>();
            descriptor.Field(organization => organization.Name).Type<StringType>();
            // descriptor.Field(organization => organization.Parent).Type<OrganizationType>();
            descriptor.Field(organization => organization.ParentId).Type<UuidType>();
            // descriptor.Field(organization => organization.Children).Type<ListType<OrganizationType>>();
            // descriptor.Field(organization => organization.Users).Type<ListType<OrganizationMembershipType>>();
        }
    }
}