using HotChocolate.Types;

namespace JuicyPineapple.WebApi.Config
{
    internal class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
        }
    }
}