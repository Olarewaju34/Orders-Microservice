using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Order.Api.MiddleWare;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ExceptionHandlingMiddlewares
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddlewares> _logger;

    public ExceptionHandlingMiddlewares(RequestDelegate next, ILogger<ExceptionHandlingMiddlewares> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred while processing the request.");
            if (ex.InnerException is not null)
            {
                _logger.LogError(ex.InnerException, "An unhandled exception occurred while processing the request.");
            }
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(new { Message = ex.Message, Type = ex.GetType().ToString() });
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ExceptionHandlingMiddlewaresExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddlewares(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddlewares>();
    }
}

