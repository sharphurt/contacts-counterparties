using System.Resources;

namespace ContactsCounterparties.Exception;

public class BaseException : System.Exception
{
    public string Message { get; protected init; }
    public int StatusCode { get; protected init; }
}