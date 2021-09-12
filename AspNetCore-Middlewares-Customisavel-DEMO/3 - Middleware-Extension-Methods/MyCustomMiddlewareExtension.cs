using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_Middlewares_Customisavel_DEMO.Middleware_Extension_Methods
{
    public static class MyCustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Inicio do primeiro middleware \n");
                await next.Invoke(); // Invoca o proximo Middleware
                await context.Response.WriteAsync("Final do primeiro middleware \n");

            });

            app.MapWhen((context => context.Request.Query.ContainsKey("condition")), CondicionalBranch);// Path: "/?condition=1"; BasePath : ""

            app.Map("/branch", ConfigureBranch);// Path: "/branch/first"; BasePath : ""

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Inicio do primeiro middleware \n");
                await next.Invoke(); // Invoca o proximo Middleware
                await context.Response.WriteAsync("Final do primeiro middleware \n");

            });

            app.MapWhen((context => context.Request.Query.ContainsKey("condition")), CondicionalBranch);// Path: "/?condition=1"; BasePath : ""

            app.Map("/branch", ConfigureBranch);// Path: "/branch/first"; BasePath : ""

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Inicio do segundo middleware \n");
                await next.Invoke(); // Invoca o proximo Middleware
                await context.Response.WriteAsync("Final do segundo middleware \n");

            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Inicio do segundo middleware \n");
                await next.Invoke(); // Invoca o proximo Middleware
                await context.Response.WriteAsync("Final do segundo middleware \n");

            });

            return app;
        }

        private static void CondicionalBranch(IApplicationBuilder app)
        {
            app.Run(async (context) => await context.Response.WriteAsync($"Valor da condição: {context.Request.Query["condition"]}!\n"));
        }

        private static void ConfigureBranch(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Inicio do primeiro middleware condicional \n");
                await next.Invoke(); // Invoca o proximo Middleware
                await context.Response.WriteAsync("Final do primeiro middleware condicional \n");

            });

            //Remificando Pipeline de acordo com a URL novamente
            //A cada nova ramificação é removido do Path a condicional
            app.Map("/first", ConfigureFirstBranch); //   Path: "/first";  BasePath: "/branch"
            app.Map("/second", ConfigureSecondBranch);//  Path: "/second"; BasePath: "/branch"

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Inicio do segundo middleware condicional \n");
                await next.Invoke(); // Invoca o proximo Middleware
                await context.Response.WriteAsync("Final do segundo middleware condicional \n");

            });


            app.Run(async (context) => await context.Response.WriteAsync("Final do Pipeline condicional!\n"));
        }

        private static void ConfigureSecondBranch(IApplicationBuilder app)
        {
            //  Path: ""; BasePath: "/branch/second"
            app.Run(async (context) => await context.Response.WriteAsync("segundo sub-branch condicional!\n"));
        }

        private static void ConfigureFirstBranch(IApplicationBuilder app)
        {
            //  Path: ""; BasePath: "/branch/first"
            app.Run(async (context) => await context.Response.WriteAsync("Primeiro sub-branch condicional!\n"));

        }
    }
}
