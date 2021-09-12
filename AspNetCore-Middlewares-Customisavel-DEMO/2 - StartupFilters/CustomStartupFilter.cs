using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace AspNetCore_Middlewares_Customisavel_DEMO
{
    public class CustomStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return (IApplicationBuilder app) =>
            {
                app.Use(async (context, n) =>
                {
                    await context.Response.WriteAsync("Início do CustomStartupFilter\n");
                    await n.Invoke();
                    await context.Response.WriteAsync("Final do CustomStartupFilter\n");
                });

                next(app);
            };
        }
    }
}
