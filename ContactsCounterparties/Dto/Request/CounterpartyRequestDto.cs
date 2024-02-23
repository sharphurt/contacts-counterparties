using System.ComponentModel.DataAnnotations;
using ContactsCounterparties.Attribute;

namespace ContactsCounterparties.Dto.Request;

public class CounterpartyRequestDto
{
    [Required, UniqueName] public string Name { get; init; }
}