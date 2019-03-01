using HotChocolate.Types;

namespace JuicyPineapple.WebApi.Config
{
    internal class SubscriptionType : ObjectType<Subscription>
    {
        protected override void Configure(IObjectTypeDescriptor<Subscription> descriptor)
        {
        }
    }
}