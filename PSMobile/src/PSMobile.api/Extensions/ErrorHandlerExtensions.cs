using System.Net;
using System.Text.Json;

namespace PSMobile.api.Extensions;

public static class ErrorHandlerExtensions
{
    public static void ConfigureCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<CustomExceptionMiddleware>();
    }
}

public class CustomExceptionMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<CustomExceptionMiddleware> logger;

    public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ApiException ex)
        {
            logger.LogError(ex, $"Exception - {ex.Message}");
            await HandleApiExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception handled by CustomExceptionMiddleware");
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleApiExceptionAsync(HttpContext context, ApiException exception)
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var details = new ErrorDetails(500, $"Erro Validação de Dados - Log {exception.Message}", exception.ListMessagesContent);

        var jsonResponse = JsonSerializer.Serialize(details);
        await context.Response.WriteAsync(jsonResponse);
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Lógica de tratamento para outras exceções
        // Você pode adicionar lógica aqui para lidar com diferentes tipos de exceções

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var details = new ErrorDetails(
            500,
            $"Erro Log",
            new List<string>()
            {
                exception.InnerException is Npgsql.PostgresException npgsqlEx
                    ? npgsqlEx.Hint
                    : exception.InnerException?.ToString(),

                exception.InnerException is Npgsql.PostgresException npgsqlEx1
                    ? npgsqlEx1.MessageText
                    : exception.InnerException?.Message
            });



        var jsonResponse = JsonSerializer.Serialize(details);

        await context.Response.WriteAsync(jsonResponse);
    }

}

public class ErrorDetails
{
    public ErrorDetails(int statusCode, string message, List<string> errors)
    {
        StatusCode = statusCode;
        Message = message;
        Errors = errors;
    }

    public int StatusCode { get; private set; }
    public string Message { get; private set; }
    public List<string> Errors { get; private set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}

public class ApiException : Exception
{
    public int ErrorCode { get; set; }
    public dynamic ErrorContent { get; private set; }
    public List<string> ListMessagesContent { get; set; } = new List<string>();
    public ApiException() { }

    public ApiException(int errorCode, string message) : base(message)
    {
        ErrorCode = errorCode;
    }

    public ApiException(int errorCode, string message, dynamic errorContent = null) : base(message)
    {
        ErrorCode = errorCode;
        ErrorContent = errorContent;
    }
}
