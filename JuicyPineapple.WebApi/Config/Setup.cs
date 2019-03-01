using System.Security.Claims;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.Subscriptions;
using JuicyPineapple.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JuicyPineapple.WebApi.Config
{
    public static class Setup
    {
        public static void AddJuicyPineapple(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<JuicyPineappleDbContext>(config => { config.UseSqlServer(connectionString); });

            services.AddScoped<Query>();
            services.AddScoped<Mutation>();
            services.AddScoped<Subscription>();

            // Add in-memory event provider
            var eventRegistry = new InMemoryEventRegistry();
            services.AddSingleton<IEventRegistry>(eventRegistry);
            services.AddSingleton<IEventSender>(eventRegistry);

            // Add GraphQL Services
            services.AddGraphQL(provider => Schema.Create(config =>
            {
                config.RegisterServiceProvider(provider);

                // Adds the authorize directive and
                // enables the authorization middleware.
                config.RegisterAuthorizeDirectiveType();

                config.RegisterQueryType<QueryType>();
                config.RegisterMutationType<MutationType>();
                config.RegisterSubscriptionType<SubscriptionType>();

                config.RegisterType<OrganizationType>();
                config.RegisterType<OrganizationMembershipType>();
                config.RegisterType<UserType>();
            }));

            services.AddAuthorization(options => { options.AddPolicy("Authenticated", policy => policy.RequireAssertion(context => context.User.HasClaim(claim => claim.Type == ClaimTypes.Authentication))); });
        }

        public static void UseJuicyPineapple(this IApplicationBuilder app)
        {
            app.UseWebSockets();
            app.UseGraphQL("/api");
            app.UseGraphiQL();
            app.UsePlayground(new PlaygroundOptions { QueryPath = "/api" });
        }
    }
}