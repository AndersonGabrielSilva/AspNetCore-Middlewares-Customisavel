using AspNetCore_Middlewares_Customisavel_DEMO.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace AspNetCore_Middlewares_Customisavel_DEMO
{
    public static  class MyConventionBasedMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyConversionBasedMiddleware(this IApplicationBuilder app)=>
            app.UseMiddleware<MyConvertionBasedMiddleware>();
        
    }
}
