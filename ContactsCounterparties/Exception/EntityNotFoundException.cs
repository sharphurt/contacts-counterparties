namespace ContactsCounterparties.Exception;

public class EntityNotFoundException : BaseException
{
    public EntityNotFoundException(string serviceName, string entityId)
    {
        Message = string.Format(StringConstants.ExceptionBase, serviceName) +
                  string.Format(StringConstants.ExceptionEntityNotFound, entityId);

        StatusCode = StatusCodes.Status404NotFound;
    }
}