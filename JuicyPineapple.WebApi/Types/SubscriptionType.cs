using HotChocolate.Types;

namespace JuicyPineapple.WebApi.Types
{
    public class SubscriptionType : ObjectType<Subscription>
    {
        protected override void Configure(IObjectTypeDescriptor<Subscription> descriptor)
        {
        }
    }
}