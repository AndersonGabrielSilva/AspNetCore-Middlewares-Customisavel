using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetCore_Middlewares_Customisavel_DEMO.Middlewares
{
    public class MyConvertionBasedMiddleware
    {
        private readonly RequestDelegate _next;

        public MyConvertionBasedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("Início do meu Convertion Based Middlware\n");

            await _next.Invoke(context);

            await context.Response.WriteAsync("Termino do meu Convertion Based Middlware\n");
        }
    }
}
