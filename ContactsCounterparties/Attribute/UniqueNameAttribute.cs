using System.ComponentModel.DataAnnotations;
using ContactsCounterparties.Database;
using ContactsCounterparties.Exception;

namespace ContactsCounterparties.Attribute;

public class UniqueNameAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
            return new ValidationResult("Name cannot be null");

        var context = validationContext.GetService(typeof(ApplicationDbContext)) ?? throw new InternalServerException();

        return (context as ApplicationDbContext).Counterparties.Any(a => a.Name == value.ToString())
            ? new ValidationResult("Name exists")
            : ValidationResult.Success;
    }
}