using System;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TimeLogger.AppService.Contract.Exceptions;
using TimeLogger.AppService.Contract.Logs;
using TimeLogger.AppService.Contract.Wrappers;

namespace TimeLogger.AppService.Contract.Middlewares
{
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static void CustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (IsOverLapException ex)
            {
                _logger.LogError(ex, "some thing happened. Error:" + ex.Message + ".");
                var result = new Response(ex.Message, false);
                var json = JsonConvert.SerializeObject(result);
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(json);
                //return NotFound(new Response<LogView>(null, ex.Message, false));
            }
            catch (ValidationException ex)
            {
                //return NotFound(new Response<LogView>(null, ex.Message, false));
                _logger.LogError(ex, "some thing happened. Error:" + ex.Message + ".");
                var result = new Response(ex.Message, false);
                var json = JsonConvert.SerializeObject(result);
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(json);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "some thing happened. Error:" + ex.Message + ".");
                var result = new Response(ex.Message, false);
                var json = JsonConvert.SerializeObject(result);
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(json);
            }
        }
    }
}