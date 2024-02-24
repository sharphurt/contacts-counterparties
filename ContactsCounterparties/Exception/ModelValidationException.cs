using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContactsCounterparties.Exception;

public class ModelValidationException : BaseException
{
    public ModelValidationException(string serviceName, ModelStateDictionary modelState)
    {
        var failedFields = string.Join(", ", modelState.Keys);
        Message = string.Format(StringConstants.ExceptionBase, serviceName) +
                  string.Format(StringConstants.ModelValidationError, failedFields);
        
        StatusCode = StatusCodes.Status400BadRequest;
    }
}