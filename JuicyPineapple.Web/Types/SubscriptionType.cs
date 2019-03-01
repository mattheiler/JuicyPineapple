using HotChocolate.Types;

namespace JuicyPineapple.Web.Types
{
    public class SubscriptionType : ObjectType<Subscription>
    {
        protected override void Configure(IObjectTypeDescriptor<Subscription> descriptor)
        {
        }
    }
}