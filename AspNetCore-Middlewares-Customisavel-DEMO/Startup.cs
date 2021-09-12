using AspNetCore_Middlewares_Customisavel_DEMO.Middleware_Extension_Methods;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_Middlewares_Customisavel_DEMO
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IStartupFilter, CustomStartupFilter>();
            services.AddMyFactoryActivatedMiddleware();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Formas para adicionar um novo Middlware
            app.UseMyFactoryActivatedMiddleware(); // Factory Activated
            app.UseMyCustomMiddleware(); // Custom Middlware Extensions
            app.UseMyConversionBasedMiddleware(); // Conversion Based

            app.Run(async (context) => await context.Response.WriteAsync("Final do Pipeline!\n")); 
        }

        
    }
}
