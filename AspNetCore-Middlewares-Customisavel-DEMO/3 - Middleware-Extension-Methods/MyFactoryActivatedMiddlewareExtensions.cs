using AspNetCore_Middlewares_Customisavel_DEMO._4_Factory_Activated;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore_Middlewares_Customisavel_DEMO
{
    public static class MyFactoryActivatedMiddlewareExtensions
    {
        public static IServiceCollection AddMyFactoryActivatedMiddleware(this IServiceCollection services) =>
            services.AddTransient<MyFactoryActivatedMiddleware>();


        public static IApplicationBuilder UseMyFactoryActivatedMiddleware(this IApplicationBuilder app) =>
            app.UseMiddleware<MyFactoryActivatedMiddleware>();
    }
}
