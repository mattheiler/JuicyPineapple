using HotChocolate.Types;

namespace JuicyPineapple.WebApi.Types
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
        }
    }
}