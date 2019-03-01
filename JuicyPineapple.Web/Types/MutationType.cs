using HotChocolate.Types;

namespace JuicyPineapple.Web.Types
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
        }
    }
}