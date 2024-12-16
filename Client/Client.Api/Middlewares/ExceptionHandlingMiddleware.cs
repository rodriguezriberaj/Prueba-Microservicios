using System.Net;
using System.Text.Json;
using Domain.Exceptions;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); 
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode status;
        string message;

        switch (exception)
        {
            case DomainException domainEx: 
                status = HttpStatusCode.BadRequest;
                message = domainEx.Message; 
                break;

            case InvalidDataException dataEx: 
                status = HttpStatusCode.UnprocessableEntity; 
                message = dataEx.Message;
                break;

            default: 
                status = HttpStatusCode.InternalServerError;
                message = "An unexpected error occurred.";
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;

        var response = new
        {
            StatusCode = context.Response.StatusCode,
            Message = message,
            Details = exception is not DomainException && exception is not InvalidDataException
                ? exception.StackTrace
                : null 
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
