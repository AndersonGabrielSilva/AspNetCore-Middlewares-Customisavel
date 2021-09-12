using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AspNetCore_Middlewares_Customisavel_DEMO._4_Factory_Activated
{
    public class MyFactoryActivatedMiddleware : IMiddleware
    {
        private readonly IConfiguration _config;
        public MyFactoryActivatedMiddleware(IConfiguration config)
        {
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Inicio do meu Factoty Activated Middleware \n");
            await next.Invoke(context); // Invoca o proximo Middleware
            await context.Response.WriteAsync("Termino do meu Factoty Activated Middleware \n");
        }
    }
}
