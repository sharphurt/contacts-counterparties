namespace ContactsCounterparties.Exception;

public class InternalServerException : BaseException
{
    public InternalServerException(string serviceName, string message)
    {
        Message = string.Format(StringConstants.ExceptionBase, serviceName) +
                  string.Format(StringConstants.ExceptionInternalServerError, message);
    }
}