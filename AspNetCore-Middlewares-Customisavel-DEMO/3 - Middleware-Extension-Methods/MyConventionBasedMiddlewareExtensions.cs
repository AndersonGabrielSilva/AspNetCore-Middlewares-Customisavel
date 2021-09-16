using AspNetCore_Middlewares_Customisavel_DEMO._6___Padronizando_erros_Middlewares.Middleware;
using AspNetCore_Middlewares_Customisavel_DEMO.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace AspNetCore_Middlewares_Customisavel_DEMO
{
    public static  class MyConventionBasedMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyConversionBasedMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<MyConvertionBasedMiddleware>();
            app.UseMiddleware<ErrorResponseMiddleware>();

            return app;
        }
        
    }
}
