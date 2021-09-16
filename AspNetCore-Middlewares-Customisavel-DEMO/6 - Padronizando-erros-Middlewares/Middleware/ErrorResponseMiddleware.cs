using AspNetCore_Middlewares_Customisavel_DEMO._6___Padronizando_erros_Middlewares.ViewModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AspNetCore_Middlewares_Customisavel_DEMO._6___Padronizando_erros_Middlewares.Middleware
{
    public class ErrorResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                throw;
            }

        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ErrorResponseViewModel errorResponseViewModel;

            if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIOMENT") == "Development")
            {
                errorResponseViewModel = new ErrorResponseViewModel(HttpStatusCode.InternalServerError.ToString(),
                                                                    $"{ex.Message} {ex?.InnerException?.Message}");
            }else
            {
                errorResponseViewModel = new ErrorResponseViewModel(HttpStatusCode.InternalServerError.ToString(),
                                                                    $"An internal server error has ocurrend.");
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(errorResponseViewModel);
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsJsonAsync(result);
        }
    }
}
