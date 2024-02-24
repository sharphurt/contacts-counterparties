using System.Text.Json;
using Azure.Core;
using ContactsCounterparties.Dto;
using Microsoft.AspNetCore.Diagnostics;

namespace ContactsCounterparties.Exception;

public static class GlobalExceptionHandler
{
    public static async Task HandleException(HttpContext context)
    {
        var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;

        var response = exception is BaseException e
            ? new ApiResponse<object>(e.Message, e.StatusCode)
            : new ApiResponse<object>(exception?.Message ?? "Unexpected server error", 500);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = response.StatusCode.Value;
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}