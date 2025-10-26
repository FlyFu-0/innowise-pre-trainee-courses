using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using task_4_library_manger.Exceptions;

namespace task_4_library_manger.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/problem+json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    // Определяем статус код
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    };


                    var problemDetails = new ProblemDetails
                    {
                        Status = context.Response.StatusCode,
                        Title = GetTitle(contextFeature.Error),
                        Detail = contextFeature.Error.Message,
                        Instance = context.Request.Path
                    };

                    await context.Response.WriteAsJsonAsync(problemDetails);
                }
            });
        });
    }

    private static string GetTitle(Exception exception) => exception switch
    {
        NotFoundException => "Resource not found",
        _ => "Internal server error"
    };
}
