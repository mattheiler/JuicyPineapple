using System.Linq;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.Subscriptions;
using JuicyPineapple.Core;
using JuicyPineapple.Data;
using JuicyPineapple.Web.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JuicyPineapple.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });

            services.AddDbContext<JuicyPineappleDbContext>(config =>
            {
                config.UseSqlServer(Configuration.GetConnectionString("JuicyPineapple"));
            });

            services.AddScoped<Query>();
            // TODO services.AddScoped<Mutation>();
            // TODO services.AddScoped<Subscription>();

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
                // TODO config.RegisterAuthorizeDirectiveType();

                config.RegisterQueryType<QueryType>();
                // TODO config.RegisterMutationType<MutationType>();
                // TODO config.RegisterSubscriptionType<SubscriptionType>();

                config.RegisterType<OrganizationType>();
                config.RegisterType<OrganizationMembershipType>();
                config.RegisterType<UserType>();
            }));

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Authenticated", policy => policy.RequireAssertion(context => context.User.HasClaim(claim => claim.Type == ClaimTypes.Authentication)));
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<JuicyPineappleDbContext>())
            {
                context.Database.Migrate();

                if (!context.Organizations.Any())
                {
                    context.AddRange(Enumerable.Range(1, 20).Select(number => new Organization { Name = $"Organization ({number})" }));
                    context.SaveChanges();
                }
            }

            app.UseWebSockets();
            app.UseGraphQL("/api");
            app.UseGraphiQL();
            app.UsePlayground(new PlaygroundOptions { QueryPath = "/api" });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment()) spa.UseAngularCliServer("start");
            });
        }
    }
}