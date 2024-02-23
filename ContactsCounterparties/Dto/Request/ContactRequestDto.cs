using System.ComponentModel.DataAnnotations;
using ContactsCounterparties.Attribute;
using Microsoft.AspNetCore.Mvc;

namespace ContactsCounterparties.Dto.Request;

public class ContactRequestDto
{
    [Required(AllowEmptyStrings = false)] public string FirstName { get; init; }
    [Required(AllowEmptyStrings = false)] public string LastName { get; init; }
    [Required(AllowEmptyStrings = false)] public string Patronymic { get; init; }

    [EmailAddress, UniqueEmail] public string Email { get; init; }

    [ExistingCounterpartyId] public int? CounterpartyId { get; init; }
}