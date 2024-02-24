using System.Text.Json.Serialization;

namespace ContactsCounterparties.Dto;

public class ApiResponse<T> : IStatusCodeHttpResult
{
    public bool Success { get; }
    public T? Result { get; }
    public string? Error { get; }

    [JsonIgnore] public int? StatusCode { get; }

    public ApiResponse(T? result)
    {
        Success = true;
        Result = result;
        Error = null;

        StatusCode = 200;
    }

    public ApiResponse(string error, int errorCode)
    {
        Success = false;
        Result = default;
        Error = error;

        StatusCode = errorCode;
    }
}