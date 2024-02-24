using System.ComponentModel.DataAnnotations;
using ContactsCounterparties.Database;
using ContactsCounterparties.Exception;

namespace ContactsCounterparties.Attribute;

public class ExistingCounterpartyIdAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
            return ValidationResult.Success;

        var context = validationContext.GetService(typeof(ApplicationDbContext)) 
                      ?? throw new InternalServerException(nameof(ExistingCounterpartyIdAttribute), "Cannot get ApplicationDbContext");

        return (context as ApplicationDbContext).Counterparties.Any(a => a.Id == (int) value)
            ? ValidationResult.Success
            : new ValidationResult($"Counterparty with id [{value}] does not exist");
    }
}