using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;

namespace WebApplication3
{
    public class Startup
    {   

        public IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
            //services.AddRouting();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*  var routeBuilder = new RouteBuilder(app);
              routeBuilder.MapGet("", context => context.Response.WriteAsync("Hello from Routing"));
              routeBuilder.MapGet("default", context => context.Response.WriteAsync("Hello from default"));
              routeBuilder.MapGet("post/{postNumber:int}", context => context.Response.WriteAsync($"{context.GetRouteValue("postNumber")}"));
              app.UseRouter(routeBuilder.Build());*/




            //app.UseMvc();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template:"{controller=Default}/{action=abc}/{id?}");
            });

            //app.UseStaticFiles();
           /* app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Hello World from {Configuration["message"]}");
            });*/
            
        }
    }
}
