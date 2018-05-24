using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StoreOfBuild.DI;
using StoreOfBuild.Domain;
using StoreOfBuild.Web.Filters;

namespace StoreOfBuild.Web
{
    public class Startup
    {
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Bootstrap.Configure(services, Configuration.GetConnectionString("dbTest"));
            services.AddMvc(configue =>
            {
                configue.Filters.Add(typeof(CustomExceptionFilter));

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // I create this middleware to manage context's "SaveChanges" .. this because the context Life Cycle Application
            app.Use(async (context, next) =>
            {
                // execute request
                await next.Invoke();
                // execute response
                var unitOfWork = (IUnitOfWork) context.RequestServices.GetService(typeof(IUnitOfWork));
                await unitOfWork.Commit();
            });

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=Index}/{id?}");
            });
        }
    }
}
