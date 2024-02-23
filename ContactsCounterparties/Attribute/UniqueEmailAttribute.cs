using System.ComponentModel.DataAnnotations;
using ContactsCounterparties.Database;
using ContactsCounterparties.Exception;

namespace ContactsCounterparties.Attribute;

public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
            return new ValidationResult("Email cannot be null");

        var context = validationContext.GetService(typeof(ApplicationDbContext)) ?? throw new InternalServerException();

        return (context as ApplicationDbContext).Contacts.Any(a => a.Email == value.ToString())
            ? new ValidationResult("Email exists")
            : ValidationResult.Success;
    }
}