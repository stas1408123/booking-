using System.Net;
using Booking.API.ViewModels;
using Microsoft.AspNetCore.Diagnostics;

namespace Booking.API.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
    {
        app.UseExceptionHandler(async appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    logger.LogError("Something went wrong: {error} \n", contextFeature.Error.Message);
                    logger.LogError("Error path: {path}", context.Request.Path);
                    logger.LogError("Stack Trace: {trace}", contextFeature.Error.StackTrace);

                    await context.Response.WriteAsync(new ErrorViewModel
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal Server Error",
                        Path = context.Request.Path
                    }.ToString());
                }
            });
        });
    }
}