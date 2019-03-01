using System.Linq;
using JuicyPineapple.Core;
using JuicyPineapple.Data;
using JuicyPineapple.WebApi.Types;
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

            services.AddJuicyPineapple(Configuration.GetConnectionString("JuicyPineapple"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            // TODO extract this
            // add some data
            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<JuicyPineappleDbContext>())
            {
                context.Database.Migrate();

                if (!context.Organizations.Any())
                {
                    context.AddRange(Enumerable.Range(1, 20).Select(number => new Organization { Name = $"Organization ({number})" }));
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.AddRange(Enumerable.Range(1, 20).Select(number => new User { Name = $"User ({number})" }));
                    context.SaveChanges();
                }
            }

            app.UseJuicyPineapple();

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                    spa.UseAngularCliServer("start");
            });
        }
    }
}